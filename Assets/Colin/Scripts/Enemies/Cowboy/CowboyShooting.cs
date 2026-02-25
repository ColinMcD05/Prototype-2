using Unity.VisualScripting;
using UnityEngine;
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
    public int bulletAmount = 6;
    public float shootTimer;

    void Update()
    {
        if (Vector3.Distance(player.position, transform.position) < shootingRange && bulletAmount != 0 && shootTimer <= 0)
        {
            Shoot();
        }
        else
        {
            shootTimer -= Time.deltaTime;
        }
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, transform.position + new Vector3(0, 0, 2), Quaternion.identity);
        bullet.transform.forward = (player.position - transform.position).normalized;
        bulletAmount--;
        shootTimer = shootBufferTime;
        if (bulletAmount == 0)
        {
            GetComponent<CowboyMovement>().enabled = false;
            Invoke("Reload", reloadTimer);
        }
    }

    void Reload()
    {
        GetComponent<CowboyMovement>().enabled = true;
        bulletAmount = 6;
    }
}
