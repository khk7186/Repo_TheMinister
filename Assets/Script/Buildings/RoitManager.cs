using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RoitManager : MonoBehaviour, IDiceRollEvent
{
    public static RoitManager Instance;
    public List<RoitSpawnRange> spawnRanges;
    public List<RoitSpawnRange> OnRoitSpawnRanges
    {
        get
        {
            return spawnRanges.Where(x => x.onRoit == true).ToList();
        }
    }
    public List<PathPoint> OnRoitPoints
    {
        get
        {
            List<PathPoint[]> targets = OnRoitSpawnRanges.Select(x => x.pathPoints).ToList();
            List<PathPoint> output = new List<PathPoint>();
            foreach (var target in targets)
            {
                if (target == null) continue;
                foreach (var pp in target)
                {
                    if (output.Contains(pp)) continue;
                    output.Add(pp);
                }
            }
            return output;
        }
    }
    public int spawnRate = 300;
    public int spawnTotal = 1000;
    private Character characterPref;
    private void Start()
    {
        if (Instance == null)
        {
            Instance = this;
            spawnRanges = FindObjectsOfType<RoitSpawnRange>().ToList();
        }
        else if (Instance != this)
            Destroy(gameObject);
    }
    public void OnEnable()
    {
        spawnRanges = FindObjectsOfType<RoitSpawnRange>().ToList();
    }

    public void SpawnRoit()
    {
        var range = spawnRanges.Where(x => x.Full == false).ToList();
        var choice = range[Random.Range(0, range.Count)];
        choice.SpawnRoit();
        //TODO: effect on money collect point.
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
