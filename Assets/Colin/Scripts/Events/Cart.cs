using Unity.VisualScripting;
using UnityEngine;

public class Cart : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip[] crash;

    // Mutable ariabels in inspector
    [Header("Mutable Variables")]
    public Transform stopPoint;
    public float cartSpeed;

    private void OnEnable()
    {
        GetComponent<Collider>().enabled = true;
    }

    private void OnDisable()
    {
        GetComponent<Collider>().enabled = false;
        int pickedAudio = Random.Range(0, crash.Length);
    }

    void Update()
    {
        Move();
    }

    public void Move()
    {
        transform.position = Vector3.Lerp(transform.position, new Vector3(stopPoint.position.x, transform.position.y, transform.position.z), cartSpeed * Time.deltaTime);
        Debug.Log("Moving");
        if ((transform.position - new Vector3(stopPoint.position.x, transform.position.y, transform.position.z)).sqrMagnitude < 0.1f * 0.1f)
        {
            Disable();
        }
    }

    private void Disable()
    {
        enabled = false;
    }
}
