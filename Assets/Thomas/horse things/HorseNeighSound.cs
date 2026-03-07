using UnityEngine;

public class HorseNeighSound : MonoBehaviour
{
    public AudioSource audioSource;
    public float neighInterval = 10f;

    void Start()
    {
        InvokeRepeating(nameof(PlayNeigh), neighInterval, neighInterval);
    }

    void PlayNeigh()
    {
        if (!audioSource.isPlaying)
        {
            audioSource.Play();
        }
    }
}