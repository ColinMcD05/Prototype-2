using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToStart : MonoBehaviour
{

    void Awake()
    {
        Invoke("ChangeScene", 3);
    }

    void ChangeScene()
    {
        SceneManager.LoadScene(0);
    }

}
