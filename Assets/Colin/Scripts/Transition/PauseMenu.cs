using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] InputActionReference pauseAction;
    [SerializeField] GameObject pauseMenu;
    PlayerCam playerCam;

    bool isPaused;

    private void Awake()
    {
        pauseAction.action.performed += Pausing;
        playerCam = Camera.main.GetComponent<PlayerCam>();
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
            playerCam.enabled = false;
        }
        else
        {
            pauseMenu.SetActive(false);
            Time.timeScale = 1;
            playerCam.enabled = true;
        }
    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
        isPaused = !isPaused;
        playerCam.enabled = true;
    }

    public void Quitting()
    {
        Application.Quit();
    }
}
