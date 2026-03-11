using UnityEngine;

public class VoiceLineTrigger : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip voiceLine;

    bool hasPlayed = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !hasPlayed)
        {
            hasPlayed = true;
            audioSource.PlayOneShot(voiceLine);

            GetComponent<Collider>().enabled = false;
        }
    }
}