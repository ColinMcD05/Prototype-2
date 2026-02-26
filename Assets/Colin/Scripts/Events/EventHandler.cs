using UnityEngine;

public class EventHandler : MonoBehaviour
{
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
}
