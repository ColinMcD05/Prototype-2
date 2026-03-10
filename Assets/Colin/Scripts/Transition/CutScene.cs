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
            Camera.main.gameObject.transform.rotation = Quaternion.Euler(0, 180, 0);
            other.GetComponentInParent<PlayerMovement>().enabled = false;
            other.transform.parent.GetChild(1).transform.rotation = Quaternion.Euler(0, 180, 0);
            other.GetComponentInParent<AudioSource>().Stop();
            other.GetComponentInParent<SkipCutScene>().enabled = true;
            GetComponent<Collider>().enabled = false;
        }
    }
}
