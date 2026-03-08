using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Playables;
using UnityEngine.Timeline;

public class SkipCutScene : MonoBehaviour
{
    [SerializeField] InputActionReference skipAction;

    [SerializeField] PlayableDirector playerTimeline, cowboyTimeline;

    private void Awake()
    {
        skipAction.action.performed += SkipScene;
    }

    private void OnDestroy()
    {
        skipAction.action.performed -= SkipScene;
    }

    private void SkipScene(InputAction.CallbackContext obj)
    {
        playerTimeline.time = 16.30f;
        cowboyTimeline.time = 16.30f;
    }
}
