using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExclamationMark : MonoBehaviour
{
    
    public static GameObject SpawnExclamationMark(Transform input, float yChange = 0)
    {
        GameObject pref = Resources.Load<GameObject>("Art/Exclamation Mark/Yellow Exclamation mark");
        GameObject output;
        output = Instantiate(pref, input);
        output.transform.position = new Vector3(0f, yChange, 0f);
        return output;

    }
}
