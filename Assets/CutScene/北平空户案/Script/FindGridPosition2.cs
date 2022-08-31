using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindGridPosition2 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var target = FindObjectOfType<MovementGrid>();
        string output = "";
        for(int i = 0; i < MovementGrid.PlayerMovementBlocks.Count; i++)
        {
            output += ($"{MovementGrid.PlayerMovementBlocks[i].ToString()} is in place of {target.GetComponent<Grid>().GetCellCenterWorld(MovementGrid.PlayerMovementBlocks[i]).ToString()}\n");
            
        }
        Debug.Log(output);
    }

    
}
