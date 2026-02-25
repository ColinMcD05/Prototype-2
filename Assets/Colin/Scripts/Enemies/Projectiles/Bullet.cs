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
        transform.Translate(Vector3.forward * bulletSpeed * Time.deltaTime, Space.Self);
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(this.gameObject);
    }
}
