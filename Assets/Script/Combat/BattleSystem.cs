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
    None = 0,
    Combat = 1,
    Debate = 2,
    GoBang = 3
}
public enum Action
{
    NoSelect = 0,
    Attack = 1,
    Defence = 2,
    Assassin = 3,
    Surrender = 4
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

    //new combat scene
    public CombatSceneController SceneController;

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
            case BattleState.Win:
                CurrentBattleState = BattleState.End;
                break;
            case BattleState.Lose:
                CurrentBattleState = BattleState.End;
                break;
        }
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
                NextState();
                SceneManager.LoadScene(1);
                break;
            case BattleState.Prepare:
                if (CurrentBattleUI == null)
                {
                    var tool = GetComponent<SpawnUI>();
                    CurrentBattleUI = tool.SpawnWithReturn().GetComponent<BattleUI>();
                }
                CurrentBattleUI.Setup(PlayerCharacters, EnemyCharacters, battleType);
                CurrentBattleUI.informationUI.gameObject.SetActive(false);
                CurrentBattleUI.ActionChoosePannel.gameObject.SetActive(true);
                NextState();
                break;
            case BattleState.Fight:
                PlayerCurrentCharacter = CurrentBattleUI.PlayerCurrentCharacter.character;
                currentEnemyAction = battleAI.MakeDecision(EnemyCharacters, this);
                EnemyCurrentCharacter = battleAI.nextCharacter;
                FightResultHandler(currentPlayerAction, currentEnemyAction);
                CurrentBattleUI.informationUI.gameObject.SetActive(true);
                CurrentBattleUI.ActionChoosePannel.gameObject.SetActive(false);
                CurrentBattleUI.Setup(PlayerCharacters, EnemyCharacters, battleType);
                SetCurrentAction(Action.NoSelect);
                NextState();
                StartCoroutine(WaitToReady());
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
            case Action.Assassin:
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
            case Action.Assassin:
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
            case Action.Assassin:
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
        if (currentPlayerAction != Action.NoSelect)
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
            case Action.Assassin:
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
        CurrentBattleUI.informationUI.AttackNDefence(attackCharacter.CharacterName, defenceCharacter.CharacterName, resultValue);
    }

    private void AttackNAttack(Character attackOne, Character attackTwo)
    {

        int resultValue =
            attackOne.CharactersValueDict[CharacterValueType.Œ‰]
            - attackTwo.CharactersValueDict[CharacterValueType.Œ‰];
        if (resultValue > 0) attackTwo.FightHealthModify(-resultValue);
        else attackTwo.FightHealthModify(resultValue);
        CurrentBattleUI.informationUI.AttackNAttack(attackOne.CharacterName, attackTwo.CharacterName, resultValue);
    }
    private void AttackNAssinate(Character attackCharacter, Character assinateCharacter)
    {
        int attackResult = -attackCharacter.CharactersValueDict[CharacterValueType.Œ‰] * 2;
        assinateCharacter.FightHealthModify(attackResult);
        int assassinResult = -assinateCharacter.CharactersValueDict[CharacterValueType.¥Ã];
        attackCharacter.FightHealthModify(assassinResult);
        CurrentBattleUI.informationUI.AttackNAssasinate(attackCharacter.CharacterName, assinateCharacter.CharacterName, attackResult, assassinResult);
    }
    private void DefenceNAssinate(Character defenceCharacter, Character assinateCharacter)
    {
        int resultValue =
            -assinateCharacter.CharactersValueDict[CharacterValueType.¥Ã];
        defenceCharacter.FightHealthModify(resultValue);
        CurrentBattleUI.informationUI.DefenceNAssassinate(defenceCharacter.CharacterName, assinateCharacter.CharacterName, resultValue);
    }
    private void DefenceNDefence(Character defenceOne, Character defenceTwo)
    {
        defenceOne.FightHealthModify(1);
        defenceTwo.FightHealthModify(1);
        CurrentBattleUI.informationUI.DefenceNDefence(defenceOne.CharacterName, defenceTwo.CharacterName);
    }
    private void AssinateNAssinate(Character assinateOne, Character assinateTwo)
    {
        int damageResultA = -assinateTwo.CharactersValueDict[CharacterValueType.¥Ã];
        assinateOne.FightHealthModify(damageResultA);
        int damageResultB = -assinateOne.CharactersValueDict[CharacterValueType.¥Ã];
        assinateTwo.FightHealthModify(damageResultB);
        CurrentBattleUI.informationUI.
            AssassinateNAssassinate
            (
            assinateOne.CharacterName, assinateTwo.CharacterName
            , damageResultA, damageResultB
            );
    }

    public IEnumerator WaitToReady()
    {
        yield return new WaitForSeconds(5);
        StateAction();
    }
}
