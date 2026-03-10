using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{

    [SerializeField] AudioSource audioSource, music;
    [SerializeField] AudioClip[] playAudio;
    [SerializeField] CanvasGroup canvas;
    [SerializeField] EventSystem eventSystem;
    [SerializeField] Button playButton;

    private void Update()
    {
        if (eventSystem.currentSelectedGameObject == null)
        {
            eventSystem.SetSelectedGameObject(playButton.gameObject);
        }
    }

    void Awake()
    {
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            if (GameObject.Find("GameManager") != null)
            {
                Destroy(GameObject.Find("GameManager"));
            }
        }
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        eventSystem.firstSelectedGameObject = playButton.gameObject;
    }

    public void PlayGame()
    {
        int num = UnityEngine.Random.Range(0, playAudio.Length);
        audioSource.PlayOneShot(playAudio[num], 0.6f);
        StartCoroutine(FadeOut());
        Invoke("Play", 2f);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void Play()
    {
        SceneManager.LoadScene(1);
    }

    IEnumerator FadeOut()
    {
        while (canvas.alpha > 0)
        {
            music.volume -= 0.001f;
            canvas.alpha -= 0.0008f;
            yield return null;
        }
    }
}
