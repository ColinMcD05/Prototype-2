using System.Collections;
using UnityEngine;

public class TumbleweedScript : MonoBehaviour
{
    public float startTimer = 10f;
    public float endTimer = 10f;
    public GameObject tumbleweedSlide;
    public GameObject tumbleweedSpawner;

    private void Start()
    {
        StartCoroutine(deactivate());
    }
    IEnumerator activate()
    {
        tumbleweedSlide.SetActive(true);
        tumbleweedSpawner.SetActive(true);
        yield return new WaitForSeconds(endTimer);
        StartCoroutine(deactivate());
    }
    IEnumerator deactivate()
    {
        tumbleweedSlide.SetActive(false);
        tumbleweedSpawner.SetActive(false);
        yield return new WaitForSeconds(startTimer);
        StartCoroutine(activate());
    }
}
