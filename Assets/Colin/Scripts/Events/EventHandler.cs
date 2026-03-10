using UnityEngine;

public class EventHandler : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip audioClip;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Cart"))
        {
            Debug.Log("Boo");
            other.GetComponentInChildren<Cart>().enabled = true;
            other.GetComponent<Collider>().enabled = false;
        }
        else if (other.CompareTag("BarrelSpawner"))
        {
            other.GetComponent<BarrelSpawn>().SpawnBarrel();
        }
        else
        {
            return;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("ExitDoor"))
        {
            audioSource.Stop();
            audioSource.PlayOneShot(audioClip);
        }
    }
}
