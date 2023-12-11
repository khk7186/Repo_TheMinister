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
    public DialogueSystemTrigger _readyToFight = null;
    public DialogueSystemTrigger _notReadyToFight = null;
    public bool Assign = false;
    public GameObject QuestSpawnPref;
    public GameObject ReloadPref;
    public bool triggered = false;
    public bool battleQuest = false;
    public bool AfterShow = false;
    public OndutyType battleType = OndutyType.Combat;
    protected void Awake()
    {
        GetComponent<SideChanger>().ChangeSideViaData(front, right);
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
    public void AssignShow()
    {
        if (battleQuest == false) return;
        AfterShow = true;
    }
    public void BattleDialogueTrigger()
    {
        if (battleQuest == false) return;
        bool ready = SelectOnDuty.GetOndutyAll(battleType).Count >= 0;
        if (ready) _readyToFight.OnUse();
        else _notReadyToFight.OnUse();
    }
    protected virtual void StartConmunicate()
    {
        var DSC = FindObjectOfType<DialogueSystemController>();
        DSC.initialDatabase = Resources.Load<DialogueDatabase>(CorrectConversationBasedOnQuest());
        DSC.Awake();
        if (!Assign)
        {
            if (AfterShow == false || battleQuest == false)
            {
                _dialogueTriggerUncollected.OnUse();
                AfterShow = true;
            }
            else
            {
                BattleDialogueTrigger();
            }
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
        //DSC.initialDatabase = Resources.Load<DialogueDatabase>($"Conversions/任务");
        //DSC.Awake();
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
        List<string> resultList = new List<string>(questID.Split('-'));
        bool sideQuest = (resultList[0] == "S");
        string type = sideQuest ? "支线任务/" : "阵营任务/";
        string chapter = sideQuest ? $"{resultList[1]}/" : string.Empty;
        string form = string.Empty;
        if (sideQuest)
        {
            switch (resultList[3])
            {
                case ("h"):
                    form = "交付任务/";
                    break;
                case ("d"):
                    form = "文斗任务/";
                    break;
                case ("a"):
                    form = "派遣任务/";
                    break;
                case ("k"):
                    form = "击杀任务/";
                    break;
                default:
                    break;
            }
        }
        folderPath = $"QuestDatabases/{type}{chapter}{form}{questID}";
        Debug.Log(folderPath);
        return folderPath;
    }
    protected int _counter = 0;
    protected readonly int DISSAPEAR_TIME = 4;
    public virtual IEnumerator DisappearAfterQuestSign()
    {
        Func<bool> _counterFinish = () => _counter >= DISSAPEAR_TIME;
        Dice.Instance.RegisterObserver(this);
        yield return new WaitUntil(_counterFinish);

        Destroy(transform.parent.gameObject);
    }
    public void OnNotify(object value, NotificationType notificationType)
    {
        _counter++;
    }
}
