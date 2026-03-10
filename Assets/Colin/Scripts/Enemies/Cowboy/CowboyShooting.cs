using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
using static UnityEngine.GraphicsBuffer;

public class CowboyShooting : MonoBehaviour
{
    // Other object references
    [Header("References")]
    [SerializeField] Transform player;
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] GameManager gameManager;
    [SerializeField] AudioSource gunAudio, cowboyAudio;
    [SerializeField] AudioClip[] shooting;
    [SerializeField] AudioClip speaking;

    // Mutable variables
    [Header("Mutable variables")]
    [SerializeField] float shootingRange;
    public float shootBufferTime;
    public float reloadTimer;
    public float shootSpreadTime;

    // Mutable variables referenced and changed in script only
    int bulletAmount = 12;
    float shootTimer;

    private void Awake()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    private void OnEnable()
    {
        Vector3 direction = player.position - transform.position;
        RaycastHit hit;
        gunAudio.PlayOneShot(shooting[0]);
        if (Physics.Raycast(transform.position, direction, out hit, direction.magnitude, LayerMask.GetMask("Player", "Default")))
        {
            if (hit.collider.gameObject.CompareTag("Player"))
            {
                SceneManager.LoadScene(2);
                gameManager.whatKilled = "Bullet";
            }
        }
    }

    void Update()
    {
        if (Vector3.Distance(player.position, transform.position) < shootingRange && bulletAmount > 0 && shootTimer <= 0)
        {
            gunAudio.PlayOneShot(shooting[1]);
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
        angle = UnityEngine.Random.Range(angle - 5, angle + 5);
        GameObject bullet = Instantiate(bulletPrefab, transform.position + new Vector3(0, 0, 0), Quaternion.Euler(0, angle, -90));
        bulletAmount--;
        if (bulletAmount <= 0)
        {
            cowboyAudio.PlayOneShot(speaking);
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
