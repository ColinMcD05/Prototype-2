using UnityEngine;

public class BarrelSpawn : MonoBehaviour
{

    // Game object references
    [Header("References")]
    [SerializeField] GameObject barrelPrefab;

    // Sound references
    [Header("Sounds")]
    [SerializeField] AudioSource barrelAudioSource;
    [SerializeField] AudioSource glassAudioSource;
    [SerializeField] AudioClip[] barrelClips;
    [SerializeField] AudioClip glassClip;

    // Mutable variables
    [Header("Mutable Variables")]
    [SerializeField] Transform barrelSpawnPoint;


    public void SpawnBarrel()
    {
        glassAudioSource.PlayOneShot(glassClip);
        int chosenClip = Random.Range(0, barrelClips.Length);
        barrelAudioSource.PlayOneShot(barrelClips[chosenClip]);
        GameObject barrel = Instantiate(barrelPrefab, barrelSpawnPoint.position, Quaternion.Euler(90, 0,0));
        barrel.GetComponent<Barrel>().enabled = true;
        barrel.GetComponent<EnemyHitPlayer>().enabled = true;
    }
}
