using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PoliticPageManager : MonoBehaviour, IPointerClickHandler
{
    public PoliticAssassinPage assassinPage = null;
    public PoliticAppointPage appointPage = null;
    public PoliticBribePage BribePage = null;
    public PoliticImpeachPage ImpeachPage = null;
    public PoliticRequestPage requestPage = null;
    public PoliticGivePage givePage = null;
    public PoliticPage currentPage = null;
    public Image mask = null;

    public void OnClickAssassinPage(PoliticSlot slot)
    {
        assassinPage.Setup(slot);
        assassinPage.Show();
        currentPage = assassinPage;
        mask.gameObject.SetActive(true);
    }
    public void OnClickAppointPage(PoliticSlot slot)
    {
        appointPage.Setup(slot);
        appointPage.Show();
        currentPage = appointPage;
        mask.gameObject.SetActive(true);
    }

    public void OnClickBribePage(PoliticSlot slot)
    {
        BribePage.Setup(slot);
        BribePage.Show();
        currentPage = BribePage;
        mask.gameObject.SetActive(true);
    }
    public void OnClickImpeachPage(PoliticSlot slot)
    {
        ImpeachPage.Setup(slot);
        ImpeachPage.Show();
        currentPage = ImpeachPage;
        mask.gameObject.SetActive(true);
    }
    public void OnClickRequestPage(PoliticSlot slot)
    {
        requestPage.Setup(slot);
        requestPage.Show();
        currentPage = requestPage;
        mask.gameObject.SetActive(true);
    }
    public void OnClickGivePage(PoliticSlot slot)
    {
        givePage.Setup(slot);
        givePage.Show();
        currentPage = givePage;
        mask.gameObject.SetActive(true);
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            AudioManager.Play("·­Ò³");
            currentPage.Hide();
            mask.gameObject.SetActive(false);
        }
    }
}
