using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class VisibleCheck : MonoBehaviour
{
    public static bool IsInView(Vector3 worldPos)
    {
        Transform camTransform = Camera.main.transform;
        Vector2 viewPos = Camera.main.WorldToViewportPoint(worldPos);
        Vector3 dir = (worldPos - camTransform.position).normalized;
        float dot = Vector3.Dot(camTransform.forward, dir);     //判断物体是否在相机前面


        if (dot > 0 && viewPos.x >= 0 && viewPos.x <= 1 && viewPos.y >= 0 && viewPos.y <= 1)
            return true;
        else
            return false;


    }
    public static bool ColliderInView(GameObject gameObject, List<Plane> otherPlanes = null)
    {
        var targetPlanes = GeometryUtility.CalculateFrustumPlanes(Camera.main).ToList<Plane>();
        if (otherPlanes != null)
        {
            targetPlanes.AddRange(otherPlanes);
        }
        Plane[] planes = targetPlanes.ToArray();
        return GeometryUtility.TestPlanesAABB(planes, gameObject.GetComponent<Collider2D>().bounds);
    }

    public static bool WorldPosToPlayer(GameObject gameObject)
    {
        Vector2 player = FindObjectOfType<Player>().transform.position;
        Vector2 target = gameObject.transform.position;
        bool xInRange = target.x < player.x + 34 && target.x > player.x - 34;
        bool yInRange = target.y < player.y + 20 && target.y > player.y - 20;
        return xInRange && yInRange;
    }
}
