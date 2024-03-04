using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class CombatSelectUI : MonoBehaviour
{
    public CombatCharacterUnit unit;
    public Canvas displayCanvas;
    public float xDiff = 60;
    public float yDiff = 60;
    public GameObject AttackGO;
    public GameObject DefenceGO;
    public GameObject AssassinateGO;
    public GameObject ShinePref = null;
    public GameObject CurrentShineObject = null;
    public bool TutorialLevel => CombatTutorManager.TutorialLevelIsOn;
    public void Setup(Transform targetUnit)
    {
        if (TutorialLevel == true)
        {
            var currentSelect = FindObjectOfType<ShowOnlyChoice>().CombatAction;
            if (CurrentShineObject != null)
            {
                Destroy(CurrentShineObject.gameObject);
            }
            if (currentSelect == CombatAction.Attack)
            {
                AttackGO.GetComponent<GraphicRaycaster>().enabled = true;
                AssassinateGO.GetComponent<GraphicRaycaster>().enabled = false;
                DefenceGO.GetComponent<GraphicRaycaster>().enabled = false;
                CurrentShineObject = Instantiate(ShinePref, AttackGO.transform);
            }
            else if (currentSelect == CombatAction.Defence)
            {
                AttackGO.GetComponent<GraphicRaycaster>().enabled = false;
                DefenceGO.GetComponent<GraphicRaycaster>().enabled = true;
                AssassinateGO.GetComponent<GraphicRaycaster>().enabled = false;
                CurrentShineObject = Instantiate(ShinePref, DefenceGO.transform);
            }
            else if (currentSelect == CombatAction.Assassin)
            {
                AttackGO.GetComponent<GraphicRaycaster>().enabled = false;
                DefenceGO.GetComponent<GraphicRaycaster>().enabled = false;
                AssassinateGO.GetComponent<GraphicRaycaster>().enabled = true;
                CurrentShineObject = Instantiate(ShinePref, AssassinateGO.transform);
            }
            else
            {
                AttackGO.GetComponent<GraphicRaycaster>().enabled = true;
                DefenceGO.GetComponent<GraphicRaycaster>().enabled = true;
                AssassinateGO.GetComponent<GraphicRaycaster>().enabled = true;
            }
        }
        SetPosition(targetUnit);
        unit = targetUnit.GetComponent<CombatCharacterUnit>();
    }
    private void SetPosition(Transform targetTransform)
    {
        var CanvasRect = GetComponentInParent<Canvas>().GetComponent<RectTransform>();
        var MainCamera = Camera.main;
        var Position = targetTransform.position;
        Vector2 AP = WorldToCanvasPosition.GetCanvasPosition
                                                        (displayCanvas.GetComponent<RectTransform>(), MainCamera, Position);
        AP.x += xDiff;
        AP.y += yDiff;
        GetComponent<RectTransform>().anchoredPosition = AP;
    }
    private void Awake()
    {
        //StartCoroutine(DestryoRator());
    }
    //public IEnumerator DestryoRator()
    //{
    //    var csc = FindObjectOfType<CombatSceneController>();
    //    csc.OnAction = true;
    //    yield return new WaitForEndOfFrame();
    //    while (csc.OnAction)
    //    {
    //        if (Input.GetMouseButtonDown(1))
    //        {

    //            csc.OnAction = false;
    //            GetComponent<MenuPopLeftAnimation>().Hide();
    //        }

    //        yield return null;
    //    }
    //}
    public void Attack()
    {
        unit.currentAction = CombatAction.Attack;
        var interactUnit = unit.GetComponent<CombatInteractableUnit>();
        if (interactUnit != null)
        {
            interactUnit.ChangeTarget();
        }
    }
    public void Defence()
    {
        unit.currentAction = CombatAction.Defence;
        var interactUnit = unit.GetComponent<CombatInteractableUnit>();
        if (interactUnit != null)
        {
            interactUnit.ChangeTarget();
        }
    }
    public void Assassinate()
    {
        unit.currentAction = CombatAction.Assassin;
        var interactUnit = unit.GetComponent<CombatInteractableUnit>();
        if (interactUnit != null)
        {
            interactUnit.ChangeTarget();
        }
    }
}
