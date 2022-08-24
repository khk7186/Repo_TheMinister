using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReciveCharacter : MonoBehaviour
{
    public CharacterArtCode CharacterArtCode;
    public List<Tag> tags;
    public string Name;
    public int health;
    public int loyalty;
    public Canvas canvas;
    private void Start()
    {
        TakeCharacter();
    }
    public void TakeCharacter()
    {
        var target = GameObject.FindGameObjectWithTag("PlayerCharacterInventory").transform;
        var pref = Resources.Load<Character>("CharacterPrefab/Character");
        var character = Instantiate(pref, target);
        character.hireStage = HireStage.Hired;
        character.CharacterName = Name;
        character.characterArtCode = CharacterArtCode;
        character.tagList = tags;
        character.health = health;
        character.loyalty = loyalty;
        character.UpdateVariables();
        var congrat = Instantiate(Resources.Load<CharacterReciveNotice>("MainUI/CharacterReciveConfirmWindow"),canvas.transform);
        congrat.Setup(character);
    }
}
