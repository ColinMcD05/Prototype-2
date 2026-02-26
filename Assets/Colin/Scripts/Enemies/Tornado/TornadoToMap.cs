using UnityEngine;
using System.Collections;

public class MoveOverTime : MonoBehaviour
{
    public Transform targetPosition;
    public float duration = 90f;

    void Start()
    {
        // Start the movement coroutine
        StartCoroutine(MoveToPosition(targetPosition.position, duration));
    }

    IEnumerator MoveToPosition(Vector3 target, float time)
    {
        float elapsedTime = 0;
        Vector3 startingPos = transform.position;

        while (elapsedTime < time)
        {
            // Move a percentage of the way based on time passed
            transform.position = Vector3.Lerp(startingPos, target, (elapsedTime / time));
            elapsedTime += Time.deltaTime;
            yield return null; // Wait for the next frame
        }

        // Ensure the object finishes exactly at the target
        transform.position = target;
    }

    void Update()
    {
        if (transform.position == targetPosition.position)
        {
            GetComponent<TornadoMovement>().enabled = true;
            enabled = false;
        }
    }
}