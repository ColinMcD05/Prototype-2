using TMPro;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI killedInfo;
    GameManager gameManager;

    private void Awake()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        killedInfo.text = gameManager.whatKilled;
    }
}
