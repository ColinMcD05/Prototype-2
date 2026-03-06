using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PauseFirstSelection : MonoBehaviour
{

    [SerializeField] GameObject resume;

    private void OnEnable()
    {
        gameObject.GetComponent<EventSystem>().firstSelectedGameObject = resume;
    }
}
