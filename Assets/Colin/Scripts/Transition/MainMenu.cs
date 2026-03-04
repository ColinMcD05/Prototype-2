using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    [SerializeField] AudioSource audioSource, music;
    [SerializeField] AudioClip[] playAudio;
    [SerializeField] CanvasGroup canvas;

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
        int num = UnityEngine.Random.Range(0, playAudio.Length);
        audioSource.PlayOneShot(playAudio[num], 0.6f);
        StartCoroutine(FadeOut());
        Invoke("Play", 2.5f);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void Play()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    IEnumerator FadeOut()
    {
        while (canvas.alpha > 0)
        {
            music.volume -= 0.001f;
            canvas.alpha -= 0.002f;
            yield return null;
        }
    }
}
