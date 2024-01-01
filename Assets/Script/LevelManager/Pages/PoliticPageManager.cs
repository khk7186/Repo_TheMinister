using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PoliticPageManager : MonoBehaviour, IPointerClickHandler
{
    public PoliticAssassinPage assassinPage = null;
    public PoliticAppointPage appointPage = null;
    public PoliticBribePage politicBribePage = null;
    public PoliticImpeachPage politicImpeachPage = null;
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
        politicBribePage.Setup(slot);
        politicBribePage.Show();
        currentPage = politicBribePage;
        mask.gameObject.SetActive(true);
    }
    public void OnClickImpeachPage(PoliticSlot slot)
    {
        politicImpeachPage.Setup(slot);
        politicImpeachPage.Show();
        currentPage = politicImpeachPage;
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
