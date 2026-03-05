using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using static Unity.Entities.SystemBaseDelegates;

public class handrun : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private Animator animator;
    [SerializeField] private Rigidbody playerrigid;
    
    void Start()
    {
        animator.SetBool("isMoving", false);
    }
    void Update()
    {
        {
            if (playerrigid.linearVelocity.magnitude > 0.0000001f)
            {
                animator.SetBool("isMoving", true);
            }
            else 
            {
                animator.SetBool("isMoving", false);
            }
        }
    }
}
