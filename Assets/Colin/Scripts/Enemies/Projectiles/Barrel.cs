using UnityEngine;

public class Barrel : MonoBehaviour
{
    // Game object references
    [Header("References")]
    [SerializeField] Rigidbody barrelRigidbody;

    // Mutable Variables
    [Header("Mutable Variables")]
    public float destroyTime;
    public float barrelForce;

    private void OnEnable()
    {
        Destroy(gameObject, destroyTime);
        barrelRigidbody.AddForce(new Vector3(barrelForce, 0, 0), ForceMode.Impulse);
    }
}
