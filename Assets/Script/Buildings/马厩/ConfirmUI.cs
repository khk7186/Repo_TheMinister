using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ConfirmUI: MonoBehaviour, IPointerClickHandler
{
    public Button confirm;
    public Button cancel;
    public Text text;

    public void SetUp(string confirmContext)
    {
        text.text = confirmContext;
    }

    public void Finish()
    {
        Destroy(gameObject);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        cancel.onClick.Invoke();
    }
}

