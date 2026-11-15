
using UnityEngine;

public class BrickExplosionFeedback : MonoBehaviour
{
    [SerializeField] private ParticleSystem brickExplosionPrefab;

    private void OnEnable()
    {
        GameEvents.BrickDestroyed += OnBrickDestroyed;
    }

    private void OnDisable()
    {
        GameEvents.BrickDestroyed -= OnBrickDestroyed;
    }

    private void OnBrickDestroyed(ImpactInfo info)
    {
        if (brickExplosionPrefab == null) return;

        ParticleSystem effect = Instantiate(
            brickExplosionPrefab,
            info.Point,
            Quaternion.identity
        );

        var main = effect.main;
        float lifetime = main.duration + main.startLifetime.constantMax;

        Destroy(effect.gameObject, lifetime + 0.5f);
    }
}
