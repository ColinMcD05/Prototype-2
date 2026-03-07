using UnityEngine;

public class HorseFacePlayer : MonoBehaviour
{
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

        Quaternion targetRotation =
            Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z), Vector3.up);

        transform.rotation = targetRotation * Quaternion.Euler(0, 180, 0);
    }
}