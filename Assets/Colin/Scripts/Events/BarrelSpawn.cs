using UnityEngine;

public class BarrelSpawn : MonoBehaviour
{

    // Game object references
    [Header("References")]
    [SerializeField] GameObject barrelPrefab;

    // Mutable variables
    [Header("Mutable Variables")]
    [SerializeField] Transform barrelSpawnPoint;


    public void SpawnBarrel()
    {
        GameObject barrel = Instantiate(barrelPrefab, barrelSpawnPoint.position, Quaternion.Euler(90, 0,0));
        barrel.GetComponent<Barrel>().enabled = true;
    }
}
