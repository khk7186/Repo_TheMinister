using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CombatInteractableUnit : MonoBehaviour
{
    public CombatSelectUI selectUI;
    LineRenderer line;
    public void OnMouseOver()
    {
        if (!IsPointerOver.IsPointerOverUIObject())
        {
            if (Input.GetMouseButtonUp(1))
            {
                var others = FindObjectsOfType<CombatInteractableUnit>();
                foreach (var other in others)
                {
                        if (other.selectUI != null) Destroy(other.selectUI.gameObject);
                }

                FindObjectOfType<CombatSceneController>().OnAction = true;

                if (selectUI == null)
                {
                    string path = "NPCInteractiveUI/CombatMenu/Menu";
                    selectUI = Instantiate(Resources.Load<CombatSelectUI>(path), MainCanvas.FindMainCanvas().transform);
                    if (selectUI != null)
                    {
                        selectUI.Setup(transform);
                    }
                }
            }
        }
    }
    public void OnMouseDown()
    {
        var scs = FindObjectOfType<CombatSceneController>();
        if (scs.OnAction == false)
        {
            scs.OnAction = true;
            StartCoroutine(EnableTargetSelection());
        }
    }
    IEnumerator EnableTargetSelection()
    {
        if (line==null) line = Instantiate(Resources.Load<LineRenderer>("Lines/Line"));
        line.SetPosition(0, (Vector2)transform.position);

        bool NotEnd = true;
        yield return new WaitForSeconds(0.00001f);
        while (NotEnd)
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hit.collider != null)
            {
                if (hit.collider.TryGetComponent<CombatCharacterUnit>(out var potentialTarget))
                {
                    line.SetPosition(1, potentialTarget.transform.position);
                    if (Input.GetMouseButtonDown(0))
                    {
                        NotEnd = false;
                        GetComponent<CombatCharacterUnit>().target = potentialTarget;
                    }
                }
            }
            else
            {
                line.SetPosition(1, Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y)));
            }
            if (Input.GetMouseButtonDown(1))
            {
                NotEnd = false;
                Destroy(line.gameObject);
            }
            yield return null;
        }
        FindObjectOfType<CombatSceneController>().OnAction = false;
    }
}
