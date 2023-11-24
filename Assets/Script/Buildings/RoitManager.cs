using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RoitManager : MonoBehaviour, IDiceRollEvent
{
    public static RoitManager Instance;
    public List<RoitSpawnRange> spawnRanges;
    public int RoitMax = 20;
    public int RoitTotal
    {
        get
        {
            int output = 0;
            foreach (var roitSpawnRange in spawnRanges)
            {
                output += roitSpawnRange.CurrentRoit;
            }
            return output;
        }
    }
    public bool EnoughRoit => RoitTotal >= RoitMax;
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
    public int spawnRate => spawnRateByChapter[ChapterCounter.Instance.Chapter];
    public List<int> spawnRateByChapter = new List<int> { 100, 200, 300, 500 };
    public int spawnTotal = 1000;
    public Rarerity Difficulty = Rarerity.R;
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
        Dice.Instance.RegisterObserver(this);
    }

    public void SpawnRoit()
    {
        var range = spawnRanges.Where(x => x.Full == false).ToList();
        var choice = range[Random.Range(0, range.Count)];
        choice.SpawnRoit();
    }

    public void OnNotify(object value, NotificationType notificationType)
    {
        bool spawn = Random.Range(0, spawnTotal) <= spawnRate;
        if (spawn)
        {
            if (!EnoughRoit)
                SpawnRoit();
            //Debug.Log("spawn");
        }
    }

    internal void Reset()
    {
        foreach (var spawnRange in spawnRanges)
        {
            foreach (var rc in spawnRange.roitCharacters)
            {
                Destroy(rc.InGameAI.gameObject);
                Destroy(rc.gameObject);
            }
            spawnRange.roitCharacters = new List<Character>();
            spawnRange.takenStartPoint = new List<PathPoint>();
        }
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
