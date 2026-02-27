using UnityEngine;

public class TornadoPull : MonoBehaviour
{
    // Game Object references
    Rigidbody playerRigidbody;
    Transform player;

    // Mutable Variables
    public float pullIntensity;
    public float pullRadius;

    // Mutable in scipt only
    float distanceTo;
    Vector3 direction;
    Vector3 pullForce;
    LayerMask layerMask;


    void Start()
    {
        playerRigidbody = GameObject.Find("Player").GetComponent<Rigidbody>();
        player = GameObject.Find("Player").GetComponent<Transform>();
        layerMask = LayerMask.GetMask("Player", "Default");
    }

    private void FixedUpdate()
    {
        if (CheckIsHidden())
        {
            direction = transform.position - player.position;
            direction.y = player.position.y;

            distanceTo = direction.magnitude;
            pullForce = (direction.normalized) / distanceTo * pullIntensity;
            playerRigidbody.AddForce(pullForce, ForceMode.Force);
            Debug.Log("See player");
        }
    }

    bool CheckIsHidden()
    {
        Vector3 direction = player.position - transform.position;
        RaycastHit hit;
        if(Physics.Raycast(transform.position, direction, out hit, direction.magnitude, layerMask))
        { 
            return hit.collider.CompareTag("Player");
        }
        return false;
    }
}
