using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Playables;
using UnityEngine.Timeline;

public class SkipCutScene : MonoBehaviour
{
    [SerializeField] InputActionReference skipAction;

    [SerializeField] PlayableDirector playerTimeline, cowboyTimeline;

    private void OnEnable()
    {
        skipAction.action.performed += SkipScene;
    }

    private void OnDisable()
    {
        skipAction.action.performed -= SkipScene;
    }

    private void SkipScene(InputAction.CallbackContext obj)
    {
        playerTimeline.time = 16.30f;
        cowboyTimeline.time = 16.30f;
        skipAction.action.performed -= SkipScene;
    }

    private void Update()
    {
        if (playerTimeline.time >= 16.30f)
        {
            skipAction.action.performed -= SkipScene;
        }
    }
}
