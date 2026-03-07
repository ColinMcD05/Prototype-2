using UnityEngine;
using UnityEngine.EventSystems;

public class ChangeButton : MonoBehaviour
{
    [SerializeField] EventSystem eventSystem;
    void OnMouseOver()
    {
        eventSystem.SetSelectedGameObject(gameObject);
    }
}
