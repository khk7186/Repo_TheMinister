using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BattleState
{
    Start,
    Prepare,
    Fight
}
public class BattleSystem : MonoBehaviour
{
    public BattleState CurrentBattleState;
    public List<Character> PlayerCharacters;
    public List<Character> EnemyCharacters;
    public Character PlayerCurrentCharacter;
    public Character EnemyCurrentCharacter;

    private void Start()
    {
        CurrentBattleState = BattleState.Start;
    }

    private void NextState()
    {
        switch (CurrentBattleState)
        {
            case BattleState.Start:
                CurrentBattleState = BattleState.Prepare;
                break;
            case BattleState.Fight:
                CurrentBattleState = BattleState.Prepare;
                break;
            case BattleState.Prepare:
                CurrentBattleState = BattleState.Fight;
                break;
        }
    }

    private void Prepare()
    {
        
    }
}
