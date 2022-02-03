using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum CharacterValueType
{
    智,
    才,
    谋,
    武,
    刺,
    守,
    逃
}

public class NodeForQuest : MonoBehaviour, IAchieveble
{
    public CharacterValueType nodeType;
    public Rarerity raitity;
    public bool achieved = false;
    public Image image;
    private Occurrence targetquest;
    private BtnShineExp btnShineExpPref;
    private BtnShineExp btnShineExp;


    public bool Achieved
    {
        get => achieved;
        set => achieved = value;
    }
    public Occurrence occurrence 
    {
        get => targetquest;
        set => targetquest = value;
    }
    public BtnShineExp BtnShineExp  => btnShineExp;


    public void Start()
    {
        string pathArt = ("Art/Nodes/" + nodeType.ToString() + raitity.ToString()).Replace(" ", string.Empty);
        image = GetComponent<Image>();
        Sprite nodeSprite = Resources.Load<Sprite>(pathArt);
        image.sprite = nodeSprite;

        string pathAnm = ("UIAnimation/ShineBtnExp");
        btnShineExpPref = Resources.Load<BtnShineExp>(pathAnm);
        btnShineExp = Instantiate(btnShineExpPref, transform);
        btnShineExp.gameObject.SetActive(false);      
    }
}
