using UnityEngine;

public class EnemyFacePlayer : MonoBehaviour
{
    // Reference to other game objects
    Transform player;

    void Awake()
    {
        player = GameObject.Find("Player").GetComponent<Transform>();
    }

    void LateUpdate()
    {
        Rotate();
    }

    void Rotate()
    {
        Vector3 direction = (player.position - transform.position).normalized;
        Quaternion targetRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z), Vector3.up);
        transform.rotation = targetRotation;
    }
}
