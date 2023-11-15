using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DestroyObjectsOnEnable : MonoBehaviour
{
    public List<GameObject> GameObjectsToDestroy;
    public bool DestroyOnEnable = false;
    public string destroyMainProfile = string.Empty;
    private void OnEnable()
    {
        if (DestroyOnEnable)
        {
            DestroyMethod();
        }
    }
    public void DestroyMethod()
    {
        foreach (GameObject go in GameObjectsToDestroy)
        {
            Destroy(go);
        }
        if (destroyMainProfile != string.Empty)
        {
            var unit = FindObjectsOfType<MainEventUnitProfile>().FirstOrDefault(x => x.profileName == destroyMainProfile);
            if (unit != null) Destroy(unit.gameObject);
        }
    }
}
