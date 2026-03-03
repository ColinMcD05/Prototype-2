using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyHitPlayer : MonoBehaviour
{
    GameManager gameManager;

    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            gameManager.whatKilled = this.tag;
            SceneManager.LoadScene(2);
        }
    }
}
