using UnityEngine;

public class Barrel : MonoBehaviour
{
    // 

    public float destroyTime;

    private void OnEnable()
    {
        Destroy(gameObject, destroyTime);
    }
}
