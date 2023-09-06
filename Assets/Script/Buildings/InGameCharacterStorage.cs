using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class InGameCharacterStorage : MonoBehaviour, IDiceRollEvent, IAreaChangeHandler
{
    public static InGameCharacterStorage Instance;
    public List<Character> CurrentCharacters = new List<Character>();
    public List<Character> UnshowedCharacters = new List<Character>();
    public int MinimumCharacterNumber = 20;
    private Character characterPref;
    private int spawnRate = 500;
    private readonly int spawnTotal = 1000;
    public bool Deserializing = false;
    public void Awake()
    {
        characterPref = Resources.Load<Character>("CharacterPrefab/Character");
        if (Deserializing) return;
        UpdateCurrentCharacters();
    }

    public void UpdateCurrentCharacters()
    {
        CurrentCharacters = GetComponentsInChildren<Character>().ToList<Character>();
        UnshowedCharacters = CurrentCharacters;
    }

    public void Start()
    {
        if (Instance == null)
        {
            Instance = this;
            Dice.Instance.RegisterObserver(this);
        }
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
    }
    public static void LoadCharacter(Character character)
    {
        character.transform.parent = Instance.transform;
        Instance.CurrentCharacters.Add(character);
    }

    public void AdjustCharacterStorage()
    {
        if (MinimumCharacterNumber > CurrentCharacters.Count)
        {
            int difference = MinimumCharacterNumber - CurrentCharacters.Count;

            if (difference < 5)
            {
                SpawnNewCharacter(1);
            }
            else if (difference > 1 / 2 * MinimumCharacterNumber)
            {
                int spawnNumber = Random.Range(0, difference / 2);
                SpawnNewCharacter(spawnNumber);
            }
            else
            {
                int spawnNumber = Random.Range(0, difference);
                SpawnNewCharacter(spawnNumber);
            }

        }
        UpdateCurrentCharacters();
    }

    public void SpawnNewCharacter(int count = 1)
    {
        if (characterPref == null) return;
        for (int i = 0; i < count; i++)
        {
            var target = Instantiate(characterPref, transform);
            target.hireStage = HireStage.InCity;

        }
        UpdateCurrentCharacters();
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
