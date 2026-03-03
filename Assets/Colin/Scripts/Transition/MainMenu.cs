using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    void Awake()
    {
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            if (GameObject.Find("GameManager") != null)
            {
                Destroy(GameObject.Find("GameManager"));
            }
        }
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
