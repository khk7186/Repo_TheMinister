using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RoitManager : MonoBehaviour, IDiceRollEvent
{
    public static RoitManager Instance;
    public List<MoneyCollectPoint> OnRoitPoints;
    private int spawnRate = 500;
    private int spawnTotal = 1000;
    private Character characterPref;
    private void Start()
    {
        if (Instance == null)
        {
            Instance = this;
            OnRoitPoints = new List<MoneyCollectPoint>();
        }
        else if (Instance != this)
            Destroy(gameObject);
    }
    public void OnEnable()
    {
        OnRoitPoints = FindObjectsOfType<MoneyCollectPoint>().Where(x => x.OnRoit).ToList<MoneyCollectPoint>();
    }

    public void SpawnRoit()
    {
        
    }

    public void OnNotify(object value, NotificationType notificationType)
    {
        bool spawn = Random.Range(spawnRate, spawnTotal) <= spawnRate;
        if (spawn)
        {
            SpawnRoit();
        }
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
    //public (PathPoint, PathPoint) GetRoitPath()
    //{
    //    PathPoint[] range = RoitPoints.Except(TakenPoints).ToArray();
    //    PathPoint A = range[Random.Range(0, range.Length)];
    //    TakenPoints.Add(A);
    //    range = RoitPoints.Except(TakenPoints).ToArray();
    //    PathPoint B = range[Random.Range(0, range.Length)];
    //    return (A, B);
    //}
}
