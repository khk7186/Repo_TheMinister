using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class PathPoint : MonoBehaviour
{
    public PathPoint[] ApproachablePoints
    {
        get => GetPointsInRange(transform.position, radius);
    }
    public PathPoint[] UnApproachablePoints;
    public CircleCollider2D circleCollider;
    public short radius = 1;
    public float colliderRadius = 1;
    public bool roit = false;

    private void Reset()
    {
        radius = 1;
        colliderRadius = 1;
    }

    private void OnEnable()
    {
        if (!TryGetComponent(out circleCollider))
        {
            circleCollider = gameObject.AddComponent<CircleCollider2D>();
        }
        circleCollider.radius = colliderRadius;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        //if (nextPoint != null)
        //{
        //    Gizmos.DrawLine(transform.position, nextPoint.transform.position);
        //}
        foreach (var point in ApproachablePoints)
        {
            Gizmos.DrawLine(transform.position, point.transform.position);
        }
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, 0.5f);
    }

    public void OnNotify(object value, NotificationType notificationType)
    {
        if (roit) return;
        float distance = CharacterMovement.playerSpeed * (int)value;
        float maxSpeed = PathManager.Instance.maxSpeed;
        radius = (short)(distance / maxSpeed);
    }

    public PathPoint[] GetPointsInRange(Vector3 center, float distance)
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(center, radius);
        List<PathPoint> approachablePoints = new List<PathPoint>();
        foreach (var collider in colliders)
        {
            if (collider.TryGetComponent(out PathPoint pp))
            {
                if (!UnApproachablePoints.Contains(pp))
                {
                    approachablePoints.Add(pp);
                }
            }
        }
        if (approachablePoints.Count <= 0)
        {
            //Debug.Log(0);
        }
        return approachablePoints.ToArray();
    }
}
