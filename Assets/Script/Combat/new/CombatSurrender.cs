using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CombatSurrender : MonoBehaviour
{
    public float duration = 0.3f;
    public void Start()
    {
        if (GeneralEventTrigger.CurrentGET.canSurrender == false)
        {
            gameObject.SetActive(false);
        }
    }
    public void Surrender()
    {
        Debug.Log("Surrender");
        var units = FindObjectsOfType<CombatCharacterUnit>().Where(x => x.IsFriend == true).ToList();
        FindObjectOfType<CombatTriggerAnimationController>().Stop();
        foreach (var unit in units)
        {
            StartCoroutine(Surrender(unit));
        }
        CombatInteractableUnit.SetActiveAllLine(false);
    }
    public IEnumerator Surrender(CombatCharacterUnit unit)
    {
        Vector3Int targetCell = new Vector3Int(unit.cellPosition.x - 10, unit.cellPosition.y, unit.cellPosition.z);
        Vector2 originPosition = unit.transform.position;
        Vector3 targetPosition = CombatCharacterUnit.grid.GetCellCenterWorld(targetCell);
        float time = 0;
        unit.DestroyHealthBar();
        while (time < duration)
        {
            time += Time.deltaTime;
            unit.transform.position = Vector2.Lerp(originPosition, targetPosition, time / duration);
            yield return null;
        }
        unit.SurrenderAction();
    }
}
