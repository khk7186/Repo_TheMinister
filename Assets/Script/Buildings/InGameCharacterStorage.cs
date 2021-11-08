using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class InGameCharacterStorage : MonoBehaviour
{
    public List<Character> CurrentCharacters = new List<Character>();
    public List<Character> UnshowedCharacters = new List<Character>();
    public int MinimumCharacterNumber = 10;
    private Character characterPref;


    public void Awake()
    {
        characterPref = Resources.Load<Character>("CharacterPrefab/Character");
        UpdateCurrentCharacters();
    }

    public void UpdateCurrentCharacters()
    {
        CurrentCharacters = GetComponentsInChildren<Character>().ToList<Character>();
        UnshowedCharacters = CurrentCharacters;
    }

    public void Start()
    {
        AdjustCharacterStorage();
    }

    public void AdjustCharacterStorage()
    {
        if (MinimumCharacterNumber >CurrentCharacters.Count)
        {
            int difference = MinimumCharacterNumber - CurrentCharacters.Count;
            for (int i = 0; i < difference; i ++) AddNewCharacter();
        }
        UpdateCurrentCharacters();
    }

    public void AddNewCharacter()
    {
        Instantiate(characterPref, transform);
    }

    public List<Character> SelectCharacterForBuilding(int numberToSelect)
    {
        List<Character> selectList = new List<Character>();
        for (int i = 0; i<numberToSelect; i++)
        {
            int randomInt = Random.Range(0, UnshowedCharacters.Count);
            selectList.Add(UnshowedCharacters[randomInt]);
            UnshowedCharacters.RemoveAt(randomInt);
        }
        return selectList;
    }
}
