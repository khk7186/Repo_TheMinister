using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSlotForQuest : MonoBehaviour
{

    [SerializeField]
    public NodeForQuest TopNode;
    public NodeForQuest UnderNode;
    public NodeForQuest LeftNode;
    public NodeForQuest RightNode;

    public TagForQuest TagRequest;

    public QuestField questField;

    public Character character;

    public GameObject CharacterSelectWindow;

    public Image selectImage;
    private Button button;

    private void Awake()
    {
        button = GetComponent<Button>();
        GetComponent<Image>().alphaHitTestMinimumThreshold = 0.1f;
        selectImage = GetComponentInChildren<HeadImage>().GetComponent<Image>();
        button.onClick.AddListener(SelectCharacter);
        questField =
            GetComponentInParent<Transform>().
            GetComponentInParent<Transform>().
            GetComponentInParent<QuestField>();
        CharacterSelectWindow = FindObjectOfType<InventoryCharacters>().gameObject;
    }

    private void Start()
    {
    }
    public void UndisableField()
    {
        questField.GetComponent<CanvasGroup>().blocksRaycasts = true;
    }
    public void CheckAllQuestAchievement()
    {
        if(TagRequest) CheckTagAchievement(character);

        CheckQuestAchievement(TopNode);
        CheckQuestAchievement(UnderNode);
        CheckQuestAchievement(LeftNode);
        CheckQuestAchievement(RightNode);
    }

    public void CheckTagAchievement(Character character)
    {
        if (character.tagList.Contains(TagRequest.thistag))
        {
            TagRequest.Achieved = true;
            TagRequest.BtnShineExp.gameObject.SetActive(true);
        }
        else
            TagRequest.BtnShineExp.gameObject.SetActive(false);
    }

    private void CheckQuestAchievement(NodeForQuest nodeForQuest)
    {
        if (nodeForQuest == null) return;

        CharacterValueType type = nodeForQuest.nodeType;
        //Debug.Log(type);
        int compareValue = (int)nodeForQuest.raitity;

        if (character.characterValueDict[type] >= compareValue)
        {

            nodeForQuest.Achieved = true;
            nodeForQuest.BtnShineExp.gameObject.SetActive(true);

            if (nodeForQuest.quest.AllAchievementsComplete())
            {
                questField.ShowSubmit();
            }
            else questField.HideSubmit();
        }
    }

    public void SelectCharacter()
    {

        CharacterSelectWindow.SetActive(true);
        var allCharacters = CharacterSelectWindow.GetComponentsInChildren<CharacterUI>();
        foreach (CharacterUI c in allCharacters) c.CurrentSlot = this;
        questField.GetComponent<CanvasGroup>().blocksRaycasts = false;
    }



}
