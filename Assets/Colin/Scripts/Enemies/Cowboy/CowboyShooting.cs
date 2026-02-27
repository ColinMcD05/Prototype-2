using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using static UnityEngine.GraphicsBuffer;

public class CowboyShooting : MonoBehaviour
{
    // Other object references
    [Header("References")]
    [SerializeField] Transform player;
    [SerializeField] GameObject bulletPrefab;

    // Mutable variables
    [Header("Mutable variables")]
    [SerializeField] float shootingRange;
    public float shootBufferTime;
    public float reloadTimer;

    // Mutable variables referenced and changed in script only
    int bulletAmount = 6;
    float shootTimer;

    void Update()
    {
        if (Vector3.Distance(player.position, transform.position) < shootingRange && bulletAmount > 0 && shootTimer <= 0)
        {
            Shoot(-45);
            Shoot(0);
            Shoot(45);
            shootTimer = shootBufferTime;
        }
        else
        {
            shootTimer -= Time.deltaTime;
        }
    }

    void Shoot(float angle)
    {
        angle += transform.eulerAngles.y - 90;
        GameObject bullet = Instantiate(bulletPrefab, transform.position + new Vector3(0, 0, 0), Quaternion.Euler(0, angle, -90));
        bulletAmount--;
        if (bulletAmount <= 0)
        {
            GetComponent<CowboyMovement>().enabled = false;
            GetComponent<NavMeshAgent>().isStopped = true;
            Invoke("Reload", reloadTimer);
        }
    }

    void Reload()
    {
        GetComponent<CowboyMovement>().enabled = true;
        GetComponent<NavMeshAgent>().isStopped = false;
        bulletAmount = 6;
    }
}
