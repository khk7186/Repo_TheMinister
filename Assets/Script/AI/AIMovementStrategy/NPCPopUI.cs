using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PixelCrushers.DialogueSystem;
using UnityEngine.UI;

public class NPCPopUI : MonoBehaviour
{
    private Character Character;
    private List<AIInteractType> interactTypes = new List<AIInteractType>();
    private string parentPath = "NPCInteractiveUI/InteractiveButton/";
    public bool loaded = false;
    private CharacterInfoUI currentCharacterInfoUI;
    public Button Info, Talk, Attack, Hire, Trade, Gobang, Debate;
    private DefaultInGameAI AI;
    public void Setup(Character character, List<AIInteractType> types, Transform characterImage, DefaultInGameAI ai)
    {
        AI = ai;
        Character = character;
        interactTypes.AddRange(types);
        foreach (AIInteractType interactType in interactTypes)
        {
            string finalPath = (parentPath + interactType.ToString()).Replace(" ", string.Empty);
            var target = Instantiate(Resources.Load<Button>(finalPath), transform);
            target.transform.position = Camera.main.WorldToScreenPoint(characterImage.position);
        }
        StartCoroutine(LoadDelay());
        SetPosition(characterImage);
    }
    private void Update()
    {
        if (!IsPointerOver.IsPointerOverUIObject())
        {
            if ((Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1)) && loaded)
            {
                Destroy(gameObject);
            }
        }
    }
    private void SetPosition(Transform targetTransform)
    {
        var CanvasRect = MainCanvas.FindMainCanvas().GetComponent<RectTransform>();
        var MainCamera = Camera.main;
        var Position = targetTransform.position;
        Vector2 AP = WorldToCanvasPosition.GetCanvasPosition(CanvasRect, MainCamera, Position);
        AP.x += 40;
        AP.y += 35;
        GetComponent<RectTransform>().anchoredPosition = AP;
    }
    private IEnumerator LoadDelay()
    {
        yield return new WaitForSeconds(0.001f);
        loaded = true;
    }
    public void SelectCharacterInfo()
    {
        var target = Resources.Load<CharacterInfoUI>("CharacterInfo/CharacterInfo");
        currentCharacterInfoUI = Instantiate(target, FindObjectOfType<Canvas>().transform);
        currentCharacterInfoUI.Setup(Character);
        //Debug.Log(currentCharacterInfoUI);
    }
        delegate void conversationEvent();
    public void SelectTalk()
    {
        //AI.TriggerConversation();
        conversationEvent talkEvent = Fight;
        var targetDB = Resources.Load<DialogueDatabase>($"Conversions/{Character.characterArtCode}");
        var targetEventGuid = targetDB.GetConversation(Character.characterArtCode.ToString())
            .GetDialogueEntry("Yes");
            //.sceneEventGuid =talkEvent;
    }
    public void Fight()
    {
        
        var Trigger = new GameObject().AddComponent<GeneralEventTrigger>();
        Trigger.enemyCharacters = new List<Character>() { Character };
        var soTarget = Resources.Load<SOConversationEvents>($"SOConversationEvents/{Character.characterArtCode}_CE");
        soTarget.eventTrigger = Trigger;
        Trigger.TriggerEvent();
    }
    public void SetConversationDatabase()
    {
        var target = GetComponent<DialogueSystemTrigger>();
        if (target == null)
        {
            Debug.LogError("No DialogueSystemTrigger found on " + gameObject.name);
            return;
        }
        target.selectedDatabase = Resources.Load<DialogueDatabase>($"Conversions/{Character.characterArtCode}");
    }

    public void TriggerConversation(string conversationName)
    {
        var target = GetComponent<DialogueSystemTrigger>();
        if (target == null)
        {
            Debug.LogError("No DialogueSystemTrigger found on " + gameObject.name);
            return;
        }
        target.conversation = conversationName;
    }

    
}
