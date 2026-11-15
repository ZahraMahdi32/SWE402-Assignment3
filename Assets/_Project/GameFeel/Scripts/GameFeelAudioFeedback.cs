
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class GameFeelAudioFeedback : MonoBehaviour
{
    [Header("Audio Clips")]
    [SerializeField] private AudioClip paddleHitClip;
    [SerializeField] private AudioClip brickDestroyClip;
    [SerializeField] private AudioClip ballLostClip;

    [Header("Volume")]
    [Range(0f, 1f)]
    [SerializeField] private float volume = 0.7f;

    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.playOnAwake = false;
        audioSource.spatialBlend = 0f;
    }

    private void OnEnable()
    {
        GameEvents.BallHitPaddle += OnPaddleHit;
        GameEvents.BrickDestroyed += OnBrickDestroyed;
        GameEvents.BallLost += OnBallLost;
    }

    private void OnDisable()
    {
        GameEvents.BallHitPaddle -= OnPaddleHit;
        GameEvents.BrickDestroyed -= OnBrickDestroyed;
        GameEvents.BallLost -= OnBallLost;
    }

    private void OnPaddleHit(ImpactInfo info)
    {
        PlaySound(paddleHitClip);
    }

    private void OnBrickDestroyed(ImpactInfo info)
    {
        PlaySound(brickDestroyClip);
    }

    private void OnBallLost()
    {
        PlaySound(ballLostClip);
    }

    private void PlaySound(AudioClip clip)
    {
        if (clip != null)
            audioSource.PlayOneShot(clip, volume);
    }
}
