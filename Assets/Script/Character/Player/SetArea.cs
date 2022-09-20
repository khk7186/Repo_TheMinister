using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class SetArea : MonoBehaviour
{
    public List<IAreaChangeHandler> Observers = new List<IAreaChangeHandler>();
    public char AreaCode;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Player player))
        {
            foreach (var subject in FindObjectsOfType<MonoBehaviour>().OfType<IAreaChangeHandler>())
            {
                subject.OnAreaChange(AreaCode);
            }
        }
    }
}
