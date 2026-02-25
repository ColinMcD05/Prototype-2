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
        transform.Translate(target * bulletSpeed * Time.deltaTime, Space.World);
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(this.gameObject);
    }
}
