using UnityEngine;

public class SheriffEnalbeAndDoorDestroy : MonoBehaviour
{
    public GameObject sheriffEyes;
    public GameObject sheriffDoor;
    public MonoBehaviour sheriffVision;
    void OnTriggerEnter(Collider other)
    {
        // Check if the object we hit has the "player" tag
        if (other.CompareTag("Player"))
        {

            sheriffEyes.GetComponent<SheriffVision>().enabled = true;
            Destroy(sheriffDoor);
        }
    }
}
