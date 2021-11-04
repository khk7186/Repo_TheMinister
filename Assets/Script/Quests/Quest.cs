using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum QuestType
{
    主线事件, 支线事件, 议会事件, 突发事件
}

public class Quest : MonoBehaviour
{
    [SerializeField] private Transform gameUI;
    [SerializeField] private QuestField questField;
    private Button button;
    private QuestField ui;

    public int rounds = 10;

    [Header("Requirement")]
    public List<Tag> ExtraTagRequirement = new List<Tag>();
    public Dictionary<Raitity, int> QuestValueDifficulty = new Dictionary<Raitity, int>()
    {
        {Raitity.Null, 0},
        {Raitity.N, 15},
        {Raitity.R, 30},
        {Raitity.SR, 45},
        {Raitity.SSR, 60},
        {Raitity.UR, 75}
    };
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
        gameUI = FindObjectOfType<QuestUI>().transform;
        ui = Instantiate(questField, gameUI);

        nodes = ui.nodeRoot.transform;

        foreach (Transform child in nodes)
        {
            //var nodelist = GetComponentsInChildren<IAchieveble>();
            AchievementList.AddRange(child.GetComponentsInChildren<IAchieveble>());
        }
        foreach (IAchieveble achieveble in AchievementList) achieveble.quest = this;

        ui.gameObject.SetActive(false);
    }

    private void OnClick()
    {
        var list = gameUI.GetComponentsInChildren<QuestField>();
        foreach (QuestField questField in list)
        {
            questField.gameObject.SetActive(false);
        }
        ui.gameObject.SetActive(!ui.gameObject.activeSelf);

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
