using UnityEngine;
using UnityEngine.InputSystem;

public class Yeehaw : MonoBehaviour
{
    [SerializeField] InputActionReference yeehaw;
    [SerializeField] AudioSource playerSpeaking;
    [SerializeField] AudioClip yeehawClip;
    private void Awake()
    {
        yeehaw.action.performed += SpeakYeehaw;
    }

    private void OnDestroy()
    {
        yeehaw.action.performed -= SpeakYeehaw;
    }

    void SpeakYeehaw(InputAction.CallbackContext obj)
    {
        playerSpeaking.Stop();
        playerSpeaking.PlayOneShot(yeehawClip);
    }
}
