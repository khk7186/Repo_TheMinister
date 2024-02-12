using SaveSystem;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;

public class PoliticActionUI : MonoBehaviour, IPointerClickHandler
{
    public Animator animator;
    public GateHolderAnimationPlayer animPlayer;
    public GameObject MoneyDepartment;
    public GameObject DocumentDepartment;
    public GameObject PopulationDepartment;
    public void Show()
    {
        AudioManager.Play("翻页");
        animator.Play("Show");
    }
    public void Hide()
    {
        AudioManager.Play("翻页");
        animator.Play("Hide");
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            Hide();
        }
    }
    public IEnumerator AssassinSuccess()
    {
        Show();
        yield return new WaitForSeconds(0.4f);
        animPlayer.StartSequence();
    }
    public void StartAssassinSuccessAnimation(string pageName)
    {
        if (pageName == "档案司")
        {
            OpenDocumentDepartment();
        }
        else if (pageName == "金钱司")
        {
            OpenMoneyDepartment();
        }
        else if (pageName == "户部司")
        {
            OpenPopulationDepartment();
        }
        StartCoroutine(AssassinSuccess());
    }
    public void OpenMoneyDepartment()
    {
        MoneyDepartment.gameObject.SetActive(true);
        DocumentDepartment.gameObject.SetActive(false);
        PopulationDepartment.gameObject.SetActive(false);
        animPlayer.page = MoneyDepartment.GetComponent<GateholderAnimationPageRef>().targetRect;
    }
    public void OpenDocumentDepartment()
    {
        MoneyDepartment.gameObject.SetActive(false);
        DocumentDepartment.gameObject.SetActive(true);
        PopulationDepartment.gameObject.SetActive(false);
        animPlayer.page = DocumentDepartment.GetComponent<GateholderAnimationPageRef>().targetRect;
    }
    public void OpenPopulationDepartment()
    {
        MoneyDepartment.gameObject.SetActive(false);
        DocumentDepartment.gameObject.SetActive(false);
        PopulationDepartment.gameObject.SetActive(true);
        animPlayer.page = PopulationDepartment.GetComponent<GateholderAnimationPageRef>().targetRect;
    }

    public List<SerializedPoliticPages> Save()
    {
        var output = new List<SerializedPoliticPages>();
        output.Add(SerializedPoliticPages.Serialize(MoneyDepartment.GetComponentsInChildren<PoliticSlot>().ToList(), "金钱司"));
        output.Add(SerializedPoliticPages.Serialize(DocumentDepartment.GetComponentsInChildren<PoliticSlot>().ToList(), "档案司"));
        output.Add(SerializedPoliticPages.Serialize(PopulationDepartment.GetComponentsInChildren<PoliticSlot>().ToList(), "户部司"));
        return output;
    }
    public void Load(GameSave gameSave)
    {
        var data = gameSave.politicPages;
        foreach (var page in data)
        {
            LoadPage(page);
        }
        return;
    }
    public void LoadPage(SerializedPoliticPages serializedPoliticPages)
    {
        var slots = new List<PoliticSlot>();
        if (serializedPoliticPages.pageName == "金钱司")
        {
            slots = MoneyDepartment.GetComponentsInChildren<PoliticSlot>().ToList();
        }
        else if (serializedPoliticPages.pageName == "档案司")
        {
            slots = DocumentDepartment.GetComponentsInChildren<PoliticSlot>().ToList();

        }
        else if (serializedPoliticPages.pageName == "户部司")
        {
            slots = PopulationDepartment.GetComponentsInChildren<PoliticSlot>().ToList();

        }
        if (slots.Count == 0) return;

        foreach (var slot in slots)
        {
            var index = serializedPoliticPages.slotNames.IndexOf(slot.slotName);
           //if (serializedPoliticPages.!=null)
           // {
           //     slot.GateHolder.GetComponent
           // }
        }
    }
}
