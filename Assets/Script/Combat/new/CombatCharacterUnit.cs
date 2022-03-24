using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CharacterStat
{
    weak,
    normal,
    strong
}
public class CombatCharacterUnit : MonoBehaviour
{
    public Character character;
    public bool IsFriend = false;
    public int armor = 0;

    public CharacterStat stat = CharacterStat.normal;
    public Action currentAction = Action.Attack;
    public CombatCharacterUnit target = null;

    public CombatCharacterUnit Defender = null;
    private void Awake()
    {
        if (character == null)
        {
            character = GetComponent<Character>();
        }
    }
    public void ChooseTarget()
    {
        switch (currentAction)
        {
            default:
                break;
            case Action.Attack:
            case Action.Assassinate:

                break;
            case Action.Defence:
                break;
        }

    }
    IEnumerator TryGetTarget()
    {
        yield return null;
    }
    public void DoDefence()
    {

        if (target == this)
        {
            stat = CharacterStat.strong;
        }
        else
        {
            target.Defender = this;
        }
    }
    public void DoDamage()
    {
        if (character != null && target != null)
        {
            switch (currentAction)
            {
                default:
                    break;
                case Action.Attack:
                    target.TakeDamge(character.CharactersValueDict[CharacterValueType.Îä]);
                    break;
                case Action.Assassinate:
                    target.TakeDamge(character.CharactersValueDict[CharacterValueType.´Ì]);
                    break;
            }
        }
    }
    public void TakeDamge(int damage, bool asDefender = false)
    {
        if (Defender == null || asDefender == true)
        {
            int result;
            switch (stat)
            {
                case CharacterStat.weak:
                    result = TryArmor(damage * 2);
                    character.FightHealthModify(result);
                    break;
                case CharacterStat.normal:
                    result = TryArmor(damage);
                    character.FightHealthModify(result);
                    break;
                case CharacterStat.strong:
                    result = TryArmor(damage / 2);
                    character.FightHealthModify(result);
                    break;
            }
        }
        else if (target != null)
        {
            Defender.TakeDamge(damage, true);
        }
    }

    public int TryArmor(int damage)
    {
        int result = armor - damage;
        if (result > 0)
        {
            armor = result;
            return 0;
        }
        else
        {
            armor = 0;
            return -result;
        }
    }

    public void NewTurn()
    {
        stat = CharacterStat.normal;
        target = null;
        Defender = null;
        currentAction = Action.NoSelect;
    }
}
