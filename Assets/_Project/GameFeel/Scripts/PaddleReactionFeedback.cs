
using System.Collections;
using UnityEngine;

public class PaddleReactionFeedback : MonoBehaviour
{
    [SerializeField] private Transform visual;

    private Vector3 originalScale;
    private Coroutine animationRoutine;

    private void Awake()
    {
        if (visual != null)
            originalScale = visual.localScale;
    }

    private void OnEnable()
    {
        GameEvents.BallHitPaddle += OnPaddleHit;
    }

    private void OnDisable()
    {
        GameEvents.BallHitPaddle -= OnPaddleHit;

        if (animationRoutine != null)
            StopCoroutine(animationRoutine);

        if (visual != null)
            visual.localScale = originalScale;
    }

    private void OnPaddleHit(ImpactInfo info)
    {
        if (visual == null) return;

        if (animationRoutine != null)
            StopCoroutine(animationRoutine);

        animationRoutine = StartCoroutine(PlayReaction());
    }

    private IEnumerator PlayReaction()
    {
        Vector3 compressed = new Vector3(
            originalScale.x * 1.12f,
            originalScale.y * 0.85f,
            originalScale.z
        );

        yield return ScaleTo(compressed, 0.07f);
        yield return ScaleTo(originalScale, 0.12f);

        animationRoutine = null;
    }

    private IEnumerator ScaleTo(Vector3 target, float duration)
    {
        Vector3 start = visual.localScale;
        float elapsed = 0f;

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            visual.localScale = Vector3.Lerp(
                start,
                target,
                Mathf.Clamp01(elapsed / duration)
            );

            yield return null;
        }

        visual.localScale = target;
    }
}
