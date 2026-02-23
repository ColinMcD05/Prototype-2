using UnityEngine;

public class SheriffDebug : MonoBehaviour
{
    private void OnDrawGizmos()
    {
        // Draw sphere indicating range
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(transform.position, GetComponent<SheriffVision>().visionRange);

        Vector3 angleOne = DirectionFromAngle(-transform.eulerAngles.y, -GetComponent<SheriffVision>().detectionAngle * 0.5f);
        Vector3 angleTwo = DirectionFromAngle(-transform.eulerAngles.y, GetComponent<SheriffVision>().detectionAngle * 0.5f);
        Vector3 angleThree = DirectionFromAngle(-transform.eulerAngles.y, -GetComponent<SheriffVision>().detectionAngle * 0.5f);
        Vector3 angleFour = DirectionFromAngle(-transform.eulerAngles.y, GetComponent<SheriffVision>().detectionAngle * 0.5f);

        // Draw two lines indicating field of view
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + angleOne * GetComponent<SheriffVision>().visionRange);
        Gizmos.DrawLine(transform.position, transform.position + angleTwo * GetComponent<SheriffVision>().visionRange);

        Gizmos.color = Color.yellow;
    }

    private Vector3 DirectionFromAngle(float eulerY, float angleInDegrees)
    {
        angleInDegrees += eulerY;

        return new Vector3(Mathf.Sin(angleInDegrees * Mathf.Deg2Rad), 0, Mathf.Cos(angleInDegrees * Mathf.Deg2Rad));
    }
}
