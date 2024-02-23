using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PoliticFriendlyNotify : MonoBehaviour, IPointerClickHandler
{
    public Animator animator;

    public RectTransform FriendlyTransform;
    public RectTransform LevelTransform;
    public RectTransform JiuQianSuiIcon;
    public RectTransform ShiZuIcon;
    public RectTransform LiYuanmoIcon;

    public Text FactionTypeText;
    public Text FriendlyText;
    public Text LevelText;
    public void Setup(FactionType factionType, int friendly, int level)
    {
        if(friendly != 0)
        {
            FriendlyTransform.gameObject.SetActive(true);
            FriendlyText.text = friendly.ToString();
        }
        if(level != 0)
        {
            LevelTransform.gameObject.SetActive(true);
            LevelText.text = level.ToString();
        }

        FactionTypeText.text = factionType.ToString();
        if (factionType == FactionType.李党)
        {
            LiYuanmoIcon.gameObject.SetActive(true);
        }
        else if (factionType == FactionType.九千岁)
        {
            JiuQianSuiIcon.gameObject.SetActive(true);
        }
        else if(factionType == FactionType.士族门阀)
        {
            ShiZuIcon.gameObject.SetActive(true);
        }
        



    }

    public void Show()
    {
        animator.Play("Show");
    }

    public void Hide()
    {
        animator.Play("Hide");
        Destroy(gameObject.transform.parent.gameObject);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            Hide();
        }
    }

}
