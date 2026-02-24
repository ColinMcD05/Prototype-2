using UnityEditor;
using UnityEngine;

public class SeeEnemyVision : MonoBehaviour
{
    private void OnDrawGizmos()
    {
        // Draw sphere indicating range
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(transform.position, GetComponent<SheriffVision>().visionRange);

        Vector3 angleOne = DirectionFromAngle(transform.eulerAngles.y, -GetComponent<SheriffVision>().detectionAngle * 0.5f);
        Vector3 angleTwo = DirectionFromAngle(transform.eulerAngles.y, GetComponent<SheriffVision>().detectionAngle * 0.5f);

        // Draw two lines indicating field of view
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + angleOne * GetComponent<SheriffVision>().visionRange);
        Gizmos.DrawLine(transform.position, transform.position + angleTwo * GetComponent<SheriffVision>().visionRange);

        Vector3 leftBoundary = Quaternion.Euler(0, -GetComponent<SheriffVision>().detectionAngle * 0.5f, 0) * transform.forward;

        Gizmos.color = Color.yellow;
        Handles.DrawSolidArc(
            transform.position,
            Vector3.up,
            leftBoundary,
            GetComponent<SheriffVision>().detectionAngle,
            GetComponent<SheriffVision>().visionRange
        );

    }

    private Vector3 DirectionFromAngle(float eulerY, float angleInDegrees)
    {
        angleInDegrees += eulerY;

        return new Vector3(Mathf.Sin(angleInDegrees * Mathf.Deg2Rad), 0, Mathf.Cos(angleInDegrees * Mathf.Deg2Rad));
    }
}
