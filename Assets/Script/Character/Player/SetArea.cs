using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class SetArea : MonoBehaviour
{
    public List<IAreaChangeHandler> Observers = new List<IAreaChangeHandler>();
    public char AreaCode;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            foreach (var subject in FindObjectsOfType<MonoBehaviour>().OfType<IAreaChangeHandler>())
            {
                subject.OnAreaChange(AreaCode);
            }
            Debug.Log("Area Changed");
        }
    }
}
