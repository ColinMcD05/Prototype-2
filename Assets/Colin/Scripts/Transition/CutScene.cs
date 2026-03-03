using UnityEngine;
using UnityEngine.Playables;

public class CutScene : MonoBehaviour
{
    [SerializeField] PlayableDirector playerTimeline, cowboyTimeline;

    private void Start()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerTimeline.Play();
            cowboyTimeline.Play();
            Camera.main.GetComponent<PlayerCam>().enabled = false;
            other.GetComponentInParent<PlayerMovement>().enabled = false;
            GetComponent<Collider>().enabled = false;
        }
    }
}
