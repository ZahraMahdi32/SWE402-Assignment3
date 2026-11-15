
using System.Collections;
using UnityEngine;

public class ScoreFeedback : MonoBehaviour
{
    [SerializeField] private Transform scoreVisual;

    private Vector3 originalScale;
    private Coroutine animationRoutine;

    private void Awake()
    {
        if (scoreVisual != null)
            originalScale = scoreVisual.localScale;
    }

    private void OnEnable()
    {
        GameEvents.ScoreChanged += OnScoreChanged;
    }

    private void OnDisable()
    {
        GameEvents.ScoreChanged -= OnScoreChanged;

        if (animationRoutine != null)
            StopCoroutine(animationRoutine);

        if (scoreVisual != null)
            scoreVisual.localScale = originalScale;
    }

    private void OnScoreChanged(int newScore)
    {
        if (scoreVisual == null) return;

        if (animationRoutine != null)
            StopCoroutine(animationRoutine);

        animationRoutine = StartCoroutine(PlayPop());
    }

    private IEnumerator PlayPop()
    {
        Vector3 enlarged = originalScale * 1.3f;

        yield return ScaleTo(enlarged, 0.1f);
        yield return ScaleTo(originalScale, 0.2f);

        animationRoutine = null;
    }

    private IEnumerator ScaleTo(Vector3 target, float duration)
    {
        Vector3 start = scoreVisual.localScale;
        float elapsed = 0f;

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;

            scoreVisual.localScale = Vector3.Lerp(
                start,
                target,
                Mathf.Clamp01(elapsed / duration)
            );

            yield return null;
        }

        scoreVisual.localScale = target;
    }
}
