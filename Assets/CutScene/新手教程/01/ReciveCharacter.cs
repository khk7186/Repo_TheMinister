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
    public List<GameObject> _objectToActive;
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
        var congrat = Instantiate(Resources.Load<CharacterReciveNotice>("MainUI/CharacterReciveConfirmWindow"), canvas.transform);
        congrat.Setup(character);
        congrat.GetComponent<CharacterRetireNotice>().Show();
        //congrat.destroyEvents.AddListener(() => SetCharacterToInv(character));
        foreach (var item in _objectToActive)
        {
            congrat.destroyEvents.AddListener(() =>
            {
                item.SetActive(true);
            });
        }
    }
    public static void SetCharacterToInv(Character character)
    {
        //character.transform.parent = GameObject.FindGameObjectWithTag("PlayerCharacterInventory").transform;
        //FindObjectOfType<PlayerCharactersInventory>().SetupNewCharacter(character);
    }
    public static void TakeCharacter(Character character)
    {
        var target = GameObject.FindGameObjectWithTag("PlayerCharacterInventory").transform;
        character.transform.SetParent(target);
        character.hireStage = HireStage.Hired;
        character.characterType = CharacterType.General;
        var shrink = character.InGameAI?.gameObject.AddComponent<ObjectShrinkHandler>();
        if (shrink != null)
        {
            shrink.Shrink(0, 0.5f, character.InGameAI.gameObject, new List<ObjectShrinkHandler.AfterShrink>()
                                                            {   () => SetupCongrat(character) ,
                                                                    ()=> CurrencyInvAnimationManager.Instance.PrestigeChange(1),
                                                                    () => DestroyInGameAvantor(character) });
        }
        //character
    }

    public static void SetupCongrat(Character character)
    {
        var congrat = Instantiate(Resources.Load<CharacterReciveNotice>("MainUI/CharacterReciveConfirmWindow"), MainCanvas.FindMainCanvas());
        congrat.Setup(character);
        congrat.destroyEvents.AddListener(() => SetCharacterToInv(character));
        congrat.GetComponent<CharacterRetireNotice>().Show();
    }
    public static void DestroyInGameAvantor(Character character)
    {
        Destroy(character.InGameAI.gameObject);
    }
}
