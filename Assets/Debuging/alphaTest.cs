using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class alphaTest : MonoBehaviour
{
    public float alpha = 0.5f;

    private void Update()
    {
        GetComponentInChildren<MeshRenderer>().material.color = new Color(1f, 1f, 1f, alpha);

    }

    // Update is called once per frame
}
