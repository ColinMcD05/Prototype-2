using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI killedInfo;
    [SerializeField] AudioSource audioSource, music;
    [SerializeField] AudioClip[] sheriff, cowboy, bullet, movingWagon, barrel, tornado, cactus, bulletAudio;
    [SerializeField] CanvasGroup canvas;
    [SerializeField] EventSystem eventSystem;
    [SerializeField] Button retryButton;
    GameManager gameManager;

    private void Awake()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        killedInfo.text = gameManager.whatKilled;
        PlaySound();
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        eventSystem.firstSelectedGameObject = retryButton.gameObject;
    }

    void PlaySound()
    {
        int playedClip;
        switch (gameManager.whatKilled)
        {
            case "Sheriff":
                playedClip = UnityEngine.Random.Range(0, sheriff.Length);
                audioSource.PlayOneShot(sheriff[playedClip]);
                return;
            case "Cowboy":
                playedClip = UnityEngine.Random.Range(0, cowboy.Length);
                audioSource.PlayOneShot(cowboy[playedClip]);
                return;
            case "Bullet":
                playedClip = UnityEngine.Random.Range(0, bullet.Length);
                audioSource.PlayOneShot(bullet[playedClip]);
                return;
            case "Moving Wagon":
                playedClip = UnityEngine.Random.Range(0, movingWagon.Length);
                audioSource.PlayOneShot(movingWagon[playedClip]);
                return;
            case "Barrel":
                playedClip = UnityEngine.Random.Range(0, barrel.Length);
                audioSource.PlayOneShot(barrel[playedClip]);
                return;
            case "Tornado":
                playedClip = UnityEngine.Random.Range(0, tornado.Length);
                audioSource.PlayOneShot(tornado[playedClip]);
                return;
            case "Cactus":
                playedClip = UnityEngine.Random.Range(0, cactus.Length);
                audioSource.PlayOneShot(cactus[playedClip]);
                return;
        }
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
        SceneManager.LoadScene(1);
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
            canvas.alpha -= 0.002f;
            yield return null;
        }
    }
}
