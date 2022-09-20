using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class InGameCharacterStorage : MonoBehaviour, IObserver, IAreaChangeHandler
{
    public List<Character> CurrentCharacters = new List<Character>();
    public List<Character> UnshowedCharacters = new List<Character>();
    public int MinimumCharacterNumber = 20;
    private Character characterPref;
    public bool EnemyOn = true;
    private int spawnRate = 500;
    private readonly int spawnTotal = 1000;
    public void Awake()
    {
        foreach (var subject in FindObjectsOfType<MonoBehaviour>().OfType<ISubject>())
        {
            subject.RegisterObserver(this);
        }
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
        if (MinimumCharacterNumber > CurrentCharacters.Count)
        {
            int difference = MinimumCharacterNumber - CurrentCharacters.Count;
            for (int i = 0; i < difference; i++) AddNewCharacter();
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
        List<Character> pool = UnshowedCharacters;
        if (pool.Count <= numberToSelect)
            return pool;
        for (int i = 0; i < numberToSelect; i++)
        {
            int randomInt = Random.Range(0, UnshowedCharacters.Count);
            selectList.Add(UnshowedCharacters[randomInt]);
            pool.RemoveAt(randomInt);
        }
        return selectList;
    }
    public List<Character> SelectOtherCharacters(int numberToSelect, List<Character> Existed)
    {
        List<Character> selectList = new List<Character>();
        List<Character> pool = UnshowedCharacters.Where(x => !Existed.Contains(x)).ToList();
        if (pool.Count <= numberToSelect)
            return pool;
        for (int i = 0; i < numberToSelect; i++)
        {
            int randomInt = Random.Range(0, UnshowedCharacters.Count);
            selectList.Add(UnshowedCharacters[randomInt]);
            pool.Remove(UnshowedCharacters[randomInt]);
        }
        return selectList;
    }
    public void GenerateCombatCharacters()
    {
        var AIpref = Resources.Load<ForceCombatInGameAI>("InGameNPC/ForceCombatNPC");
        var newAI = Instantiate(AIpref);
        var newCharacter = Instantiate(characterPref, newAI.transform);
        newCharacter.characterArtCode = CharacterArtCode.ÄÐµ¶¿Í;
        newCharacter.hireStage = HireStage.NotInMap;
        newAI.Setup(newCharacter);
    }
    public void OnNotify(object value, NotificationType notificationType)
    {
        var map = FindObjectOfType<Map>();
        if (map.DayTime == 0)
        {
            AdjustCharacterStorage();
        }
        int multi = map.DayTime == 2 ? 2 : 1;
        int result = Random.Range(0, spawnTotal) * multi;
        bool spawn = result < spawnRate;
        if (spawn&&EnemyOn)
        {
            GenerateCombatCharacters();
        }
    }

    public void OnAreaChange(char areaCode)
    {
        switch (areaCode)
        {
            case 'A':
                spawnRate = 150;
                break;
            case 'B':
                spawnRate = 400;
                break;
            case 'C':
                spawnRate = 200;
                break;
            case 'D':
                spawnRate = 50;
                break;
        }
    }
}
