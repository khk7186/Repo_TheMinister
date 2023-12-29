using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateHolderAnimationPlayer : MonoBehaviour
{
    public List<GameObject> animations = new List<GameObject>();
    public IEnumerator StartAnimationSequence()
    {
        yield return null;
    }
    
}
