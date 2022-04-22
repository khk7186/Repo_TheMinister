using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatLine : MonoBehaviour
{
    public LineRenderer line;
    public SpriteRenderer arrow;

    private void Update()
    {
        var dir = line.GetPosition(0) - line.GetPosition(1);
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        arrow.transform.rotation = Quaternion.AngleAxis(angle+180, Vector3.forward);
        
        var targetPos = Vector2.Lerp(line.GetPosition(0), line.GetPosition(1), 1f);

        arrow.transform.position = targetPos;
    }
}
