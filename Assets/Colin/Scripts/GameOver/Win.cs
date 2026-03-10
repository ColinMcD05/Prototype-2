using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Win : MonoBehaviour
{
    [SerializeField] AudioSource audioSource, music;
    [SerializeField] AudioClip[] bulletAudio;
    [SerializeField] CanvasGroup canvas;
    [SerializeField] EventSystem eventSystem;
    [SerializeField] Button mainMenuButton;

    private void Awake()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        eventSystem.firstSelectedGameObject = mainMenuButton.gameObject;
    }

    public void Retry()
    {
        StartCoroutine(FadeOut());
        int num = UnityEngine.Random.Range(0, bulletAudio.Length);
        audioSource.PlayOneShot(bulletAudio[num], 0.6f);
        Invoke("RestartGame", 2);
    }

    void RestartGame()
    {
        SceneManager.LoadScene(0);
    }

    public void Quit()
    {
        Application.Quit();
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
