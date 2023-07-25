using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PixelCrushers.QuestMachine;
using PixelCrushers.DialogueSystem;
using System;

public class QuestGiverAI : MonoBehaviour, IDiceRollEvent
{
    public string QuestID;
    public string QuestChainName = string.Empty;
    public int QuestChainOrder = 0;
    public Vector2 position;
    public bool front;
    public bool right;
    public DialogueSystemTrigger _dialogueTriggerUncollected;
    public DialogueSystemTrigger _dialogueTriggerCollected;
    protected void Awake()
    {
        GetComponent<SideChanger>().changeSide(front, right);
        transform.position = position;
    }
    protected void Start()
    {
        ChapterCounter.QuestAISignIn(this);
    }
    protected int Chapter()
    {
        var charList = QuestID.ToCharArray();
        var targetString = new string(new char[] { charList[2], charList[3] });
        int output = int.Parse(targetString);
        return output;
    }
    protected virtual void StartConmunicate()
    {
        var DSC = FindObjectOfType<DialogueSystemController>();
        DSC.initialDatabase = Resources.Load<DialogueDatabase>(CorrectConversationBasedOnQuest());
        DSC.Awake();
        if (DialogueLua.GetVariable("Assign").asBool == false)
        {
            _dialogueTriggerUncollected.OnUse();
            StartCoroutine(DisappearAfterQuestSign());
        }
        else
        {
            _dialogueTriggerCollected.OnUse();
        }
    }
    protected void OnMouseDown()
    {
        var DSC = FindObjectOfType<DialogueSystemController>();
        DSC.initialDatabase = Resources.Load<DialogueDatabase>($"Conversions/任务");
        DSC.Awake();
        StartConmunicate();
    }
    public string CorrectConversationBasedOnQuest()
    {
        var folderName = FindQuestFolder(this.QuestID);
        return $"{folderName}/对话{QuestID}";
    }
    public static string FindQuestFolder(string questID)
    {
        if (questID == null) return null;
        string folderPath = string.Empty;
        if (questID[0] == 'M' || questID[0] == 'm')
        {
            folderPath = $"QuestDatabases/支线任务/{questID}";
        }
        return folderPath;
    }
    protected int _counter = 0;
    protected readonly int DISSAPEAR_TIME = 4;
    public virtual IEnumerator DisappearAfterQuestSign()
    {
        Func<bool> _counterFinish = () => _counter >= DISSAPEAR_TIME;
        Dice.Instance.RegisterObserver(this);
        yield return new WaitUntil(_counterFinish);
        if (DialogueLua.GetVariable("Assign").asBool == false)
        {
        }
        else if (Chapter() < ChapterCounter.Instance.Chapter)
        {
            Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void OnNotify(object value, NotificationType notificationType)
    {
        _counter++;
    }
}
