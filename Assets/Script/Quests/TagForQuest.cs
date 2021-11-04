using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TagForQuest : MonoBehaviour,IAchieveble
{
    public Tag thistag;
    private bool achieved = false;
    private Quest targetQuest;
    private BtnShineExp btnShineExpPref;
    private BtnShineExp btnShineExp;

    public bool Achieved
    {
        get => achieved;
        set => achieved = value;
    }
    public Quest quest
    {
        get => targetQuest;
        set => targetQuest = value;
    }
    public BtnShineExp BtnShineExp => btnShineExp;

    private void Start()
    {
        string pathAnm = ("UIAnimation/ShineBtnExp");
        btnShineExpPref = Resources.Load<BtnShineExp>(pathAnm);
        btnShineExp = Instantiate(btnShineExpPref, transform);

        string FolderPathOfTags = ("Art/Tags/" + thistag.ToString()).Replace(" ", string.Empty);
        GetComponent<Image>().sprite = Resources.Load<Sprite>(FolderPathOfTags);
        btnShineExp.gameObject.SetActive(false);
    }
}
