using UnityEngine;
using UnityEngine.AI;

public class CowboyMovement : MonoBehaviour
{
    [SerializeField] NavMeshAgent agent;
    private GameObject player;

    public float enemySpeed;

    void Start()
    {
        player = GameObject.Find("Player");
        agent.speed = enemySpeed;
    }

    void Update()
    {
        agent.SetDestination(player.transform.position);
    }
}
