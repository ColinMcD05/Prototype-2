using System.Collections;
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
    public float shootSpreadTime;

    // Mutable variables referenced and changed in script only
    int bulletAmount = 6;
    float shootTimer;

    void Update()
    {
        if (Vector3.Distance(player.position, transform.position) < shootingRange && bulletAmount > 0 && shootTimer <= 0)
        {
            StartCoroutine(ShootVolley());
        }
        else
        {
            shootTimer -= Time.deltaTime;
        }
    }

    IEnumerator ShootVolley()
    {
        shootTimer = shootBufferTime;

        float[] angles = { 45, 0, -45 };

        foreach (float angle in angles)
        {
            Shoot(angle);
            yield return new WaitForSeconds(shootSpreadTime);
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
        GetComponent<CowboyStamina>().staminaTimer = GetComponent<CowboyStamina>().stamina;
        bulletAmount = 6;
    }
}
