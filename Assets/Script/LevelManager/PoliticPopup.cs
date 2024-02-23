using Language.Lua;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PoliticPopup : MonoBehaviour
{
    public GameObject Popup = null;
    public Button AssassinButton;
    public Button BribeButton;
    public Button AppointButton;
    public Button ImpeachButton;
    public Button RequestButton;
    public Button GiveButton;
    public Animator animator;
    public PoliticSlot slot;

    private void Start()
    {
        GetComponent<Canvas>().sortingOrder = 102;
    }
    public void ShowPopup()
    {
        gameObject.SetActive(true);
        animator.Play("Show");
    }
    public void ShowAssassinOnly()
    {
        BribeButton.gameObject.SetActive(false);
        ImpeachButton.gameObject.SetActive(false);
        AppointButton.gameObject.SetActive(false);
        RequestButton.gameObject.SetActive(false);
        GiveButton.gameObject.SetActive(false);
        gameObject.SetActive(true);
        animator.Play("Show");
    }
    public void HidePopup()
    {
        animator.Play("Hide");
    }
    public void Setup(PoliticSlot politicSlot)
    {
        slot = politicSlot;
        slot.SetupLineSprites();
        if (politicSlot.GateHolder != null && politicSlot.GateHolder.bribed == false)
        {
            AssassinButton.gameObject.SetActive(true);
            BribeButton.gameObject.SetActive(true);
            ImpeachButton.gameObject.SetActive(true);
            AppointButton.gameObject.SetActive(false);
            RequestButton.gameObject.SetActive(false);
            GiveButton.gameObject.SetActive(false);
        }
        else if (politicSlot.GateHolder != null && politicSlot.GateHolder.bribed == true)
        {
            AssassinButton.gameObject.SetActive(false);
            BribeButton.gameObject.SetActive(false);
            ImpeachButton.gameObject.SetActive(false);
            AppointButton.gameObject.SetActive(false);
            RequestButton.gameObject.SetActive(true);
            GiveButton.gameObject.SetActive(true);
        }
        else if (politicSlot.characterOnHold == null)
        {
            AssassinButton.gameObject.SetActive(false);
            BribeButton.gameObject.SetActive(false);
            ImpeachButton.gameObject.SetActive(false);
            AppointButton.gameObject.SetActive(true);
            RequestButton.gameObject.SetActive(false);
            GiveButton.gameObject.SetActive(false);
        }
        else
        {
            AssassinButton.gameObject.SetActive(false);
            BribeButton.gameObject.SetActive(false);
            ImpeachButton.gameObject.SetActive(false);
            AppointButton.gameObject.SetActive(false);
            RequestButton.gameObject.SetActive(true);
            GiveButton.gameObject.SetActive(true);
        }
        SetPosition(politicSlot.transform);
    }
    public void SetPosition(Transform targetTransform)
    {
        Popup.transform.position = targetTransform.position;
    }
    public void OpenAssassin()
    {
        FindObjectOfType<PoliticPageManager>().OnClickAssassinPage(slot);
    }
    public void OpenBribe()
    {
        FindObjectOfType<PoliticPageManager>().OnClickBribePage(slot);
    }
    public void OpenImpeach()
    {
        FindObjectOfType<PoliticPageManager>().OnClickImpeachPage(slot);
    }
    public void OpenRequest()
    {
        FindObjectOfType<PoliticPageManager>().OnClickRequestPage(slot);
    }
    public void OpenGive()
    {
        FindObjectOfType<PoliticPageManager>().OnClickGivePage(slot);
    }
    public void OpenAppoint()
    {
        FindObjectOfType<PoliticPageManager>().OnClickAppointPage(slot);
    }
}
