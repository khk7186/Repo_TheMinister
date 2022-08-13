using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity.Examples;
using UnityEngine.EventSystems;
using System.Linq;

public class CombatInteractableUnit : MonoBehaviour
{
    public CombatSelectUI selectUI;
    public LineRenderer line;
    private CombatSceneController csc;
    public RenderExistingMesh renderExistingMesh;
    private void Start()
    {
        
        if (csc == null)
        {
            csc = FindObjectOfType<CombatSceneController>();
        }
        renderExistingMesh = GetComponentInChildren<RenderExistingMesh>(true);
        renderExistingMesh.Set();
        Character character = GetComponent<CombatCharacterUnit>().character;
        CharacterArtCode artCode = character.characterArtCode;
        string FrontOrBack = character.hireStage == HireStage.Hired ? "Front" : "Back";
        string path = $"Character Spine/{artCode}/{FrontOrBack}/{renderExistingMesh.replacementMaterials[0].originalMaterial.name}";
        renderExistingMesh.GetComponent<MeshRenderer>().materials[0] = (Material)Resources.Load(path, typeof(Material));
        path = $"{path}_Outline";
        Debug.Log(path);
        renderExistingMesh.replacementMaterials[0].replacementMaterial = (Material)Resources.Load(path, typeof(Material));
        renderExistingMesh.Set();
        OnMouseExit();
        //RenderExistingMesh outline = new GameObject("outLine").AddComponent<RenderExistingMesh>();
        //outline.gameObject.transform.parent = transform;
        //outline.referenceRenderer.material = (Material)Resources.Load($"{outline.referenceRenderer.material.name}_outline", typeof(Material));
        //outline.Set();
    }
    public void OnMouseEnter()
    {
        if (renderExistingMesh != null) renderExistingMesh.gameObject.SetActive(true);
    }
    private void OnMouseExit()
    {
        if (renderExistingMesh != null) renderExistingMesh.gameObject.SetActive(false);
    }
    public void OnMouseOver()
    {
        //Debug.Log("Mouse over");
        if (FindObjectOfType<CombatTrigger>() == null) return;
        if (IsPointerOver.IsPointerOverUIObject())
        {
            if (Input.GetMouseButtonUp(1) && !csc.OnAction)
            {
                var others = FindObjectsOfType<CombatInteractableUnit>();
                foreach (var other in others)
                {
                    if (other.selectUI != null) Destroy(other.selectUI.gameObject);
                }
                if (selectUI == null)
                {
                    Debug.Log("Creating select UI");
                    string path = "NPCInteractiveUI/CombatMenu/CombatSelectMenu";
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
        if (FindObjectOfType<CombatTrigger>() == null) return;
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
                line.SetColors(Color.red, Color.red);
                break;
            case Action.Assassin:
                line.SetColors(Color.yellow, Color.yellow);
                break;
            case Action.Defence:
                line.SetColors(Color.blue, Color.blue);
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
            line.SetPosition(1, Vector2.Lerp(line.GetPosition(0), target, 0.9f));
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
                unit.line.enabled = enable;
                unit.line.GetComponent<CombatLine>().arrow.enabled = enable;
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
                    if (ccu.target != null)
                    {
                        var targetPost = ccu.target.transform.position;
                        unit.line.SetPosition(1, targetPost);
                    }
                    else
                    {
                        Destroy(unit.line.gameObject);
                    }
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
    public static CombatCharacterUnit FindAttachedCCU(Character character)
    {
        CombatCharacterUnit output = null;
        foreach (var unit in FindObjectsOfType<CombatCharacterUnit>())
        {
            if (unit != null)
            {
                if (output.character == character)
                {
                    output = unit;
                    break;
                }
            }
        }
        return output;
    }
}