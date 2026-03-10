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

    private void OnCollisionEnter(Collision other)
    {
        if (gameObject.GetComponent<Rigidbody>().linearVelocity.magnitude >= 0.4f)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                gameManager.whatKilled = this.tag;
                SceneManager.LoadScene(2);
            }
        }
    }
}
