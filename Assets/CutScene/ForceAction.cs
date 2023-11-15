using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceAction : MonoBehaviour,IStopPlayer
{
    public List<GameObject> goToActive;
    public int stayblock;
    public int CurrentBlock => stayblock;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            foreach (GameObject go in goToActive)
            {
                go.SetActive(true);
            }
        }
    }
    private void OnEnable()
    {
        var movementGrid = FindObjectOfType<MovementGrid>();
        var gridVector = MovementGrid.GetPlayerBlock(stayblock);
        transform.position =movementGrid.GetComponent<Grid>().GetCellCenterWorld(gridVector);
        //Debug.Log(transform.position);
    }
}
