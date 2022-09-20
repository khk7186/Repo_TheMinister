 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Occurrence : MonoBehaviour
{
    [SerializeField] private Transform QuestUI;
    public QuestFieldUI questField;
    private Button button;
    private QuestFieldUI ui;

    public int rounds = 10;

    [Header("Requirement")]
    public List<Tag> ExtraTagRequirement = new List<Tag>();
    private List<IAchieveble> AchievementList = new List<IAchieveble>();
    private Transform nodes;


    [Header("Dialog")]
    public string Dialog;

    [Header("Reward")]
    public int MinMoney;
    public int MaxMoney;

    private void Awake()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(OnClick);
        QuestUI = FindObjectOfType<QuestUI>().transform;
    }

    private void OnClick()
    {
        var mainUICanvas = GameObject.FindGameObjectWithTag("MainUICanvas").transform;
        ui = Instantiate(questField, mainUICanvas);
        var list = QuestUI.GetComponentsInChildren<QuestFieldUI>();

        nodes = ui.nodeRoot.transform;

        foreach (Transform child in nodes)
        {
            //var nodelist = GetComponentsInChildren<IAchieveble>();
            AchievementList.AddRange(child.GetComponentsInChildren<IAchieveble>());
        }
        foreach (IAchieveble achieveble in AchievementList) achieveble.occurrence = this;
    }

    public bool AllAchievementsComplete()
    {
        foreach (IAchieveble achieveble in AchievementList)
        {
            if (achieveble.Achieved == false)
            {
                achieveble.BtnShineExp.gameObject.SetActive(false);
                questField.HideSubmit();
                return false;
            }
            achieveble.BtnShineExp.gameObject.SetActive(true);
        }
        questField.ShowSubmit();
        return true;
    }

    public void FinishQuest()
    {
        if (AllAchievementsComplete() == false) return;
        //rewards and sent out characters
    }


}
