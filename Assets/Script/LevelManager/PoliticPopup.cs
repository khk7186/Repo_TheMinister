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
        if (politicSlot.GateHolder != null)
        {
            AssassinButton.gameObject.SetActive(true);
            BribeButton.gameObject.SetActive(true);
            AppointButton.gameObject.SetActive(false);
        }
        else
        {
            AssassinButton.gameObject.SetActive(false);
            BribeButton.gameObject.SetActive(false);
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

    }
    public void OpenBribe()
    {

    }
    public void OpenImpeach()
    {
    }
    public void OpenAppoint()
    {

    }
}
