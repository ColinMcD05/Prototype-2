using UnityEngine;
using UnityEngine.Playables;

public class CutScene : MonoBehaviour
{
    [SerializeField] PlayableDirector timeline;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            timeline.Play();
            other.GetComponent<PlayerMovement>().enabled = false;
            GetComponent<Collider>().enabled = false;
        }
    }
}
