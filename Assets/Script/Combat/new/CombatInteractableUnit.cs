using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity.Examples;
using UnityEngine.EventSystems;

public class CombatInteractableUnit : MonoBehaviour
{
    public CombatSelectUI selectUI;
    public LineRenderer line;
    private void Awake()
    {
        OnMouseExit();
    }
    public void OnMouseEnter()
    {
        var outline = GetComponentInChildren<RenderExistingMesh>(true);
        if (outline != null) outline.gameObject.SetActive(true);
    }
    private void OnMouseExit()
    {
        var outline = GetComponentInChildren<RenderExistingMesh>();
        if (outline != null) outline.gameObject.SetActive(false);
    }
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
        var csc = FindObjectOfType<CombatSceneController>();
        if (csc.OnAction == false)
        {
            ChangeTarget();
        }
    }
    public void ChangeTarget()
    {

        if (line == null) line = Instantiate(Resources.Load<LineRenderer>("Lines/Line"));
        var Unit = GetComponent<CombatCharacterUnit>();
        bool friend = Unit.currentAction == Action.Defence;
        switch (Unit.currentAction)
        {
            case Action.Attack:
                line.endColor = Color.red;
                break;
            case Action.Assassinate:
                line.endColor = Color.yellow;
                break;
            case Action.Defence:
                line.endColor = Color.blue;
                break;
        }
        StartCoroutine(EnableTargetSelection(friend));
    }
    public IEnumerator EnableTargetSelection(bool friend = false)
    {
        var csc = FindObjectOfType<CombatSceneController>();
        csc.OnAction = true;
        csc.CurrentOnActionCCU = GetComponent<CombatCharacterUnit>();
        CameraShiftToEnemy();
        csc.lining = true;
        var Unit = GetComponent<CombatCharacterUnit>();
        line.SetPosition(0, (Vector2)transform.position);
        bool NotEnd = true;
        yield return new WaitForSeconds(0.00001f);
        while (NotEnd)
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

            Vector2 target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (hit.collider != null)
            {
                if (hit.collider.TryGetComponent<CombatCharacterUnit>(out var potentialTarget))
                {
                    if (potentialTarget.IsFriend == friend)
                    {
                        target = potentialTarget.transform.position;
                        if (Input.GetMouseButtonDown(0))
                        {
                            NotEnd = false;
                            Unit.target = potentialTarget;
                        }
                    }
                }
            }
            line.SetPosition(1, target);
            if (Input.GetMouseButtonDown(1))
            {
                NotEnd = false;

                Destroy(line.gameObject);
            }
            yield return null;
        }
        //Show PlayerCard
        var thisUnit = GetComponent<CombatCharacterUnit>();
        if (thisUnit != null)
        {
            CombatSceneController.ShowCard(thisUnit);
        }
        csc.lining = false;
        csc.CurrentOnActionCCU = null;
        //origin the camera
        csc.CameraAdjast = 0;
        csc.MoveCamera();
        CombatSceneController.CameraFocus(false);
        CombatSceneController.MoveCamera(0);
        yield return new WaitForSeconds(csc.duration);
        csc.OnAction = false;
    }
    public static void SetActiveAllLine(bool enable = false)
    {
        var list = FindObjectsOfType<CombatInteractableUnit>();
        foreach (var unit in list)
        {
            if (unit.line != null)
            {
                Debug.Log(1);
                unit.line.enabled = enable;
                if (enable && unit != null)
                {
                    var ccu = unit.GetComponent<CombatCharacterUnit>();
                    if (ccu.target == null)
                    {
                        var PotentialList = FindObjectsOfType<CombatCharacterUnit>();
                        foreach (var potential in PotentialList)
                        {
                            if (potential.IsFriend == ccu.target.IsFriend)
                            {
                                ccu.target = potential;
                                break;
                            }
                        }
                    }
                    var targetPost = ccu.target.transform.position;
                    unit.line.SetPosition(1, targetPost);
                }
            }
        }
    }
    private void CameraShiftToEnemy()
    {
        var thisUnit = GetComponent<CombatCharacterUnit>();
        if (thisUnit != null)
        {
            if (thisUnit.currentAction != Action.Defence)
            {
                var allUnit = FindObjectsOfType<CombatCharacterUnit>();
                CombatCharacterUnit FirstEnemy = null;
                foreach (var unit in allUnit)
                {
                    if (!unit.IsFriend)
                    {
                        FirstEnemy = unit;
                        break;
                    }
                }
                if (FirstEnemy != null)
                {
                    CombatSceneController.ShowCard(FirstEnemy);
                }
            }
        }
    }
}