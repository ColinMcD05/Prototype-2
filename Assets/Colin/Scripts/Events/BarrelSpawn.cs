using UnityEngine;

public class BarrelSpawn : MonoBehaviour
{

    // Game object references
    [Header("References")]
    [SerializeField] GameObject barrelPrefab;

    // Mutable variables
    [Header("Mutable Variables")]
    public Vector3 barrelSpawnPoint;


    public void SpawnBarrel()
    {
        GameObject barrel = Instantiate(barrelPrefab, barrelSpawnPoint, Quaternion.identity);
        barrel.GetComponent<Barrel>().enabled = true;
    }
}
