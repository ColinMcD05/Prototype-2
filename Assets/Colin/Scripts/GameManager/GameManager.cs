using UnityEngine;

public class GameManager : MonoBehaviour
{
    [HideInInspector] public string whatKilled;

    void Awake()
    {
        DontDestroyOnLoad(this);
    }
}
