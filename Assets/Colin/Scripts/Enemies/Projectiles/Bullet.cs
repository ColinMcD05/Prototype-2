using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Bullet References
    [Header("GameObject References")]

    // Mutable Variables
    [Header("Mutable Variables")]
    public float bulletSpeed;


    // Immutable Variable
    [HideInInspector] public Vector3 target;
    private void Update()
    {
        Movement();
    }

    void Movement()
    {
        transform.Translate(Vector3.up * bulletSpeed * Time.deltaTime, Space.Self);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Player death script
        }
        Destroy(this.gameObject);
    }
}

