using System.Collections;
using UnityEngine;

public class CactusRising : MonoBehaviour
{
    public GameObject cactusWall;
    public GameObject cactusGroup;
    public float duration;
    private Vector3 newPos;
    private Vector3 prevPos;
    private int lockPos = 0;
    void Awake()
    {
        newPos = new Vector3(cactusWall.transform.position.x, 0, cactusWall.transform.position.z);
        prevPos = new Vector3(cactusWall.transform.position.x, cactusWall.transform.position.y, cactusWall.transform.position.z);
    }
    void OnTriggerEnter(Collider other)
    {
        // Check if the object we hit has the "player" tag
        if (other.CompareTag("Player"))
        {
            //if it hasn't run before, move wall into place.
            if (lockPos == 0)
            {
                StartCoroutine(moveSlowly());
            }
        }
    }
    // uses lerp to slowly move the wall from the old position to the new position
    IEnumerator moveSlowly()
    {
        Vector3 startPos = transform.position;
        float elapsed = 0f;

        while (elapsed < duration) 
        {
            cactusWall.transform.position = Vector3.Lerp(prevPos, newPos, (elapsed / duration));
            elapsed += Time.deltaTime;
            
            yield return null;
        }
        cactusWall.transform.position = newPos;
        lockPos = 1;

    }

}
