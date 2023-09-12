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
    public bool Assign = false;
    public GameObject QuestSpawnPref;
    public GameObject ReloadPref;
    protected void Awake()
    {
        GetComponent<SideChanger>().changeSide(front, right);
        transform.position = position;
    }
    protected void Start()
    {
        ChapterCounter.QuestAISignIn(this);
    }
    private void OnEnable()
    {
        if (Assign == false)
        {
            GetComponentInChildren<ExclamationMarkBuilder>()?.gameObject.SetActive(true);
        }
    }
    protected int Chapter()
    {
        var charList = QuestID.ToCharArray();
        var targetString = new string(new char[] { charList[2], charList[3] });
        int output = int.Parse(targetString);
        return output;
    }
    public void AssignTrue()
    {
        Assign = true;
       
        var indicators = GetComponentsInChildren<ExclamationMarkSbject>();
        foreach (var indicator in indicators)
        {
            indicator.gameObject.SetActive(false);
        }
        StartCoroutine(DisappearAfterQuestSign());
    }
    protected virtual void StartConmunicate()
    {
        var DSC = FindObjectOfType<DialogueSystemController>();
        DSC.initialDatabase = Resources.Load<DialogueDatabase>(CorrectConversationBasedOnQuest());
        DSC.Awake();
        if (!Assign)
        {
            _dialogueTriggerUncollected.OnUse();
        }
        else
        {
            GeneralEventTrigger GET = GetComponentInChildren<GeneralEventTrigger>();
            if (GET != null)
            {
                if (GET.gameTracker.gameWin) DialogueLua.SetVariable("LostDebate", true);
                else DialogueLua.SetVariable("WinDebate", true);
            }

            Debug.Log("Assigned");
            _dialogueTriggerCollected.OnUse();
        }
    }
    protected void OnMouseDown()
    {
        if (IsPointerOver.IsPointerOverUIObject())
        {
            return;
        }
        var DSC = FindObjectOfType<DialogueSystemController>();
        DSC.initialDatabase = Resources.Load<DialogueDatabase>($"Conversions/任务");
        DSC.Awake();
        StartConmunicate();
    }
    public string CorrectConversationBasedOnQuest()
    {
        var folderName = FindQuestFolder(this.QuestID);
        var output = $"{folderName}/对话{QuestID}";
        Debug.Log(output);
        return output;
    }
    public static string FindQuestFolder(string questID)
    {
        if (questID == null) return null;
        string folderPath = string.Empty;
        if (questID[0] == 'S' || questID[0] == 's')
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
