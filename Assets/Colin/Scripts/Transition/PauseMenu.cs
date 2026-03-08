using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] InputActionReference pauseAction;
    [SerializeField] GameObject pauseMenu;

    bool isPaused;

    private void Awake()
    {
        pauseAction.action.performed += Pausing;

    }

    private void OnDestroy()
    {
        pauseAction.action.performed -= Pausing;
    }

    private void Pausing(InputAction.CallbackContext obj)
    {
        isPaused = !isPaused;
        if (isPaused)
        {
            pauseMenu.SetActive(true);
            Time.timeScale = 0;
        }
        else
        {
            pauseMenu.SetActive(false);
            Time.timeScale = 1;
        }
    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
        isPaused = !isPaused;
    }

    public void Quitting()
    {
        Application.Quit();
    }
}
