using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class RoitInGameAI : DefaultInGameAI
{
    public RoitSpawnRange spawnRange;
    public float moveDuration = 0.5f;
    public float stayDuration = 1.5f;
    public PathPoint startPoint;
    public PathPoint endPoint;
    public bool OnStartPoint = true;

    public override void StartAction()
    {
        DontDestroyOnLoad(gameObject);
    }
    public override void Move()
    {

    }
    public override void SetLocation()
    {
        transform.position = startPoint.transform.position;
    }
    public IEnumerator OnStreetRator()
    {
        bool lost = character.hireStage != HireStage.Defeated;
        while (!lost)
        {
            yield return MakeAMoveRator();
            yield return new WaitForSeconds(stayDuration);
        }
    }
    public IEnumerator MakeAMoveRator()
    {
        PathPoint direction = OnStartPoint ? endPoint : startPoint;
        float time = 0;
        while (time < moveDuration)
        {
            time += Time.deltaTime;
            transform.position = Vector2.Lerp(transform.position, direction.transform.position, time / moveDuration);
            yield return null;
        }
    }
    public void SetupRoitAI(Character character, RoitSpawnRange spawnRange)
    {
        this.character = character;
        this.spawnRange = spawnRange;
        var path =spawnRange.RequestPath();
        startPoint = path.Item1;
        endPoint = path.Item2;
        SetLocation();
        StartCoroutine(OnStreetRator());
    }
}
