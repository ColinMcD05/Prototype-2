using UnityEngine;
using UnityEngine.AI;

public class CowboyStamina : MonoBehaviour
{

    [SerializeField] CowboyMovement cowboyMovement;
    [SerializeField] NavMeshAgent agent;

    public float stamina = 25;
    public float regainStaminaTime = 5;
    public float staminaTimer;

    private void Update()
    {
        if (staminaTimer > 0 && cowboyMovement.enabled && agent.velocity.magnitude >= 0.0001f)
        {
            staminaTimer -= Time.deltaTime;
            if (staminaTimer <= 0)
            {
                cowboyMovement.enabled = false;
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
