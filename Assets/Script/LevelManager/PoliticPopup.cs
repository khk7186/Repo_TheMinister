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
    public void HidePopup()
    {
        animator.Play("Hide");
    }
    public void Setup(PoliticSlot politicSlot)
    {
        slot = politicSlot;
        if (politicSlot.GateHolder != null)
        {
            AssassinButton.gameObject.SetActive(true);
            BribeButton.gameObject.SetActive(true);
            ImpeachButton.gameObject.SetActive(true);
            AppointButton.gameObject.SetActive(false);
        }
        else
        {
            AssassinButton.gameObject.SetActive(false);
            BribeButton.gameObject.SetActive(false);
            ImpeachButton.gameObject.SetActive(false);
            AppointButton.gameObject.SetActive(true);
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
    }
    public void OpenAppoint()
    {
        FindObjectOfType<PoliticPageManager>().OnClickAppointPage(slot);
    }
}
