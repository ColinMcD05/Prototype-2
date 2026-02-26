using UnityEngine;

public class EventHandler : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Cart"))
        {
            other.GetComponent<Cart>().Move();
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
