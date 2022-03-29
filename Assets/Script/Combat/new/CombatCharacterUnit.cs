using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CharacterStat
{
    weak = 0,
    normal = 1,
    strong = 2,
}
public class CombatCharacterUnit : MonoBehaviour
{
    int order = 0;
    public Character character;
    public bool IsFriend = false;
    public int armor = 0;
    public static int minimumDamage = 1;

    public CharacterStat stat = CharacterStat.normal;
    public Action currentAction = Action.Attack;
    public CombatCharacterUnit target = null;
    public bool SelfDefending = false;

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
    public void MakeTurn()
    {
        ModifyStat();
        DoDamage();
    }
    public void ModifyStat()
    {
        CharacterStat NextStat = stat;
        switch (currentAction)
        {
            default:
                break;
            case Action.Defence:
                if (SelfDefending)
                {
                    NextStat = CharacterStat.strong;
                }
                else
                {
                    NextStat = (CharacterStat)((((int)stat + 1) >= 2) ? 2 : ((int)stat + 1));

                }
                break;
            case Action.Assassinate:
                NextStat = (CharacterStat)((((int)stat - 1) <= 0) ? 0 : ((int)stat - 1));
                break;
        }
        stat = NextStat;
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
                    target.TakeDamge(character.CharactersValueDict[CharacterValueType.Îä]);
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
                    result = TryArmor(damage > 0 ? damage * 2 : minimumDamage);
                    character.FightHealthModify(result);
                    break;
                case CharacterStat.normal:
                    result = TryArmor(damage > 0 ? damage : minimumDamage);
                    character.FightHealthModify(result);
                    break;
                case CharacterStat.strong:
                    result = TryArmor(damage > 0 ? damage / 2 : minimumDamage);
                    character.FightHealthModify(result);
                    break;
            }
            if (character.health <= 0)
            {
                if (TryGetComponent(out CombatInteractableUnit unit))
                {
                    Destroy(unit.line);
                }
                Destroy(gameObject);
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
