using UnityEngine;
using UnityEngine.AI;

public class CowboyStamina : MonoBehaviour
{

    [SerializeField] CowboyMovement cowboyMovement;
    [SerializeField] AudioSource cowboyAudio;
    [SerializeField] AudioClip[] cowboyTired;
    [SerializeField] NavMeshAgent agent;

    public float stamina = 25;
    public float regainStaminaTime = 5;
    [HideInInspector]public float staminaTimer;

    private void Update()
    {
        if (staminaTimer > 0 && cowboyMovement.enabled && agent.velocity.magnitude >= 0.0001f)
        {
            staminaTimer -= Time.deltaTime;
            if (staminaTimer <= 0)
            {
                int playedClip = UnityEngine.Random.Range(0, cowboyTired.Length);
                cowboyAudio.PlayOneShot(cowboyTired[playedClip]);
                cowboyMovement.enabled = false;
                GetComponent<NavMeshAgent>().isStopped = true;
                Invoke("RegainStamina", regainStaminaTime);
            }
        }
        else if (staminaTimer > 0 && cowboyMovement.enabled)
        {
            staminaTimer = stamina;
        }
    }

    void RegainStamina()
    {
        cowboyMovement.enabled = true;
        staminaTimer = stamina;
    }
}
