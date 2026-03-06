using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class CowboyMovement : MonoBehaviour
{
    // Get Cowboy components
    [Header("Cowboy Components")]
    [SerializeField] NavMeshAgent agent;
    [SerializeField] AudioSource cowboyAudio, cowboySteps;
    [SerializeField] AudioClip[] cowboySpeaking;

    // Get other GameObject components
    private GameObject player;

    // Mutable Variables
    [Header("Mutable Variables")]
    public float enemySpeed = 5;


    // Mutable Variables in script only

    private void OnEnable()
    {
        agent.isStopped = false;
        cowboySteps.enabled = true;
        StartCoroutine(PlayAudio());
    }

    private void OnDisable()
    {
        cowboySteps.enabled = false;
    }

    void Start()
    {
        player = GameObject.Find("Player");

        // Set agent speed equal to the speed of player
        agent.speed = enemySpeed;
        agent.updateRotation = false;
    }

    void Update()
    {
        // Setting destination of Cowboy to current position of the player
        agent.SetDestination(player.transform.position);
    }

    IEnumerator PlayAudio()
    {
        while (enabled)
        {
            int chosenAudio = UnityEngine.Random.Range(0, cowboySpeaking.Length);
            float speakTimer = UnityEngine.Random.Range(8f, 15f);
            cowboyAudio.PlayOneShot(cowboySpeaking[chosenAudio]);
            yield return new WaitForSeconds(speakTimer);
        }
    }
}
