using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum BattleState
{
    Start,
    Prepare,
    Fight,
    Win,
    Lose,
    End
}
public enum BattleType
{
    Duel,
    Debate
}
public enum Action
{
    NoSelect,
    Attack,
    Defence,
    Assinate,
    Surrender
}
public class BattleSystem : MonoBehaviour
{
    public BattleState CurrentBattleState = BattleState.Start;
    public BattleUI CurrentBattleUI;
    public List<Character> PlayerCharacters;
    public List<Character> EnemyCharacters;
    public Character PlayerCurrentCharacter;
    public Character EnemyCurrentCharacter;
    public BattleType battleType;
    public Action currentPlayerAction = Action.NoSelect;
    public Action currentEnemyAction = Action.NoSelect;
    public BaseBattleAI battleAI;
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
                CurrentBattleState = BattleState.Fight;
                break;
            case BattleState.Prepare:
                CurrentBattleState = BattleState.Fight;
                break;
            case BattleState.Win:
                CurrentBattleState = BattleState.End;
                break;
            case BattleState.Lose:
                CurrentBattleState = BattleState.End;
                break;
        }
    }
    private void Prepare()
    {

    }
    private IEnumerator StartBattle()
    {
        while (CurrentBattleState != BattleState.End)
        {
            yield return null;
        }
    }
    public void StateAction()
    {
        switch (CurrentBattleState)
        {
            default:
                break;
            case BattleState.Start:
                DontDestroyOnLoad(gameObject);
                foreach (Character character in PlayerCharacters) character.armor = 0;
                foreach (Character character in EnemyCharacters) character.armor = 0;
                NextState();
                SceneManager.LoadScene(1);
                break;
            case BattleState.Prepare:
                var tool = GetComponent<SpawnUI>();
                CurrentBattleUI = tool.SpawnWithReturn().GetComponent<BattleUI>();
                CurrentBattleUI.Setup(PlayerCharacters, EnemyCharacters, battleType);
                NextState();
                break;
            case BattleState.Fight:
                var AIReaction = battleAI.MakeDecision();
                FightResultHandler(currentPlayerAction, currentEnemyAction);
                CurrentBattleUI.Setup(PlayerCharacters, EnemyCharacters, battleType);
                NextState();
                break;
            case BattleState.Win:
                NextState();
                break;
            case BattleState.Lose:
                NextState();
                break;
            case BattleState.End:
                Destroy(gameObject);
                SceneManager.LoadScene(0);
                break;
        }
    }
    public void FightResultHandler(Action playerAction, Action enemyAction)
    {
        switch (playerAction)
        {
            default:
                break;
            case Action.Attack:
                Attack(enemyAction);
                break;
            case Action.Defence:
                Defence(enemyAction);
                break;
            case Action.Assinate:
                Assinate(enemyAction);
                break;
        }
    }
    private void Attack(Action enemyAction)
    {
        switch (enemyAction)
        {
            default:
                break;
            case Action.Attack:
                AttackNAttack(PlayerCurrentCharacter, EnemyCurrentCharacter);
                break;
            case Action.Defence:
                AttackNDefence(PlayerCurrentCharacter, EnemyCurrentCharacter);
                break;
            case Action.Assinate:
                AttackNAssinate(PlayerCurrentCharacter, EnemyCurrentCharacter);
                break;
            case Action.Surrender:
                PlayerCurrentCharacter.health += 1;
                break;
        }
    }
    private void Defence(Action enemyAction)
    {
        switch (enemyAction)
        {
            default:
                break;
            case Action.Attack:
                AttackNDefence(EnemyCurrentCharacter, PlayerCurrentCharacter);
                break;
            case Action.Defence:
                DefenceNDefence(EnemyCurrentCharacter, PlayerCurrentCharacter);
                break;
            case Action.Assinate:
                DefenceNAssinate(PlayerCurrentCharacter, EnemyCurrentCharacter);
                break;
            case Action.Surrender:
                PlayerCurrentCharacter.health += 2;
                break;
        }
    }

    public void SetCurrentAction(Action buttonAction)
    {
        currentPlayerAction = buttonAction;
        if (currentPlayerAction!= Action.NoSelect)
        {
            CurrentBattleUI.Confirm.gameObject.SetActive(true);
        }
        else
            CurrentBattleUI.Confirm.gameObject.SetActive(false);
    }

    private void Assinate(Action enemyAction)
    {
        switch (enemyAction)
        {
            default:
                break;
            case Action.Attack:
                AttackNAssinate(EnemyCurrentCharacter, PlayerCurrentCharacter);
                break;
            case Action.Defence:
                DefenceNAssinate(EnemyCurrentCharacter, PlayerCurrentCharacter);
                break;
            case Action.Assinate:
                AssinateNAssinate(PlayerCurrentCharacter, EnemyCurrentCharacter);
                break;
            case Action.Surrender:
                PlayerCurrentCharacter.health += 2;
                break;
        }
    }
    private void AttackNDefence(Character attackCharacter, Character defenceCharacter)
    {
        int resultValue =
            defenceCharacter.CharactersValueDict[CharacterValueType. ÿ] * 2
             - attackCharacter.CharactersValueDict[CharacterValueType.Œ‰];
        defenceCharacter.FightHealthModify(resultValue);
    }

    private void AttackNAttack(Character attackOne, Character attackTwo)
    {
        int resultValue =
            attackOne.CharactersValueDict[CharacterValueType.Œ‰]
            - attackTwo.CharactersValueDict[CharacterValueType.Œ‰];
        if (resultValue > 0) attackTwo.FightHealthModify(-resultValue);
        else attackTwo.FightHealthModify(resultValue);
    }
    private void AttackNAssinate(Character attackCharacter, Character assinateCharacter)
    {
        assinateCharacter.FightHealthModify(-attackCharacter.CharactersValueDict[CharacterValueType.Œ‰] * 2);
        attackCharacter.FightHealthModify(-assinateCharacter.CharactersValueDict[CharacterValueType.¥Ã]);
    }
    private void DefenceNAssinate(Character defenceCharacter, Character assinateCharacter)
    {
        int resultValue =
            assinateCharacter.CharactersValueDict[CharacterValueType.¥Ã]*2
            - defenceCharacter.CharactersValueDict[CharacterValueType. ÿ];
        defenceCharacter.FightHealthModify(resultValue);
    }
    private void DefenceNDefence(Character defenceOne, Character defenceTwo)
    {
        defenceOne.FightHealthModify(1);
        defenceTwo.FightHealthModify(1);
    }
    private void AssinateNAssinate(Character assinateOne, Character assinateTwo)
    {
        assinateOne.FightHealthModify(-assinateTwo.CharactersValueDict[CharacterValueType.¥Ã]);
        assinateTwo.FightHealthModify(-assinateOne.CharactersValueDict[CharacterValueType.¥Ã]);
    }
}
