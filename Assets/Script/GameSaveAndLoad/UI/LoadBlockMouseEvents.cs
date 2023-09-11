using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
namespace SaveSystem
{
    public class LoadBlockMouseEvents : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        [SerializeField]
        public Image Mask;
        public Image HightLight;

        private void OnEnable()
        {
            SetOff();
        }
        public void OnPointerEnter(PointerEventData eventData)
        {
            SetOn();
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            SetOff();
        }

        public void SetOn()
        {
            Mask.gameObject.SetActive(false);
            HightLight.gameObject.SetActive(true);
        }
        public void SetOff()
        {
            Mask.gameObject.SetActive(true);
            HightLight.gameObject.SetActive(false);
        }
    }
}