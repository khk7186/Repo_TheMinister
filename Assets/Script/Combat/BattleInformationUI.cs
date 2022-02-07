using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleInformationUI : MonoBehaviour
{
    public Text text;
    public string AttackNAttack(string AttackA, string AttackB, int damage)
    {
        string output;
        if (damage > 0)
        {
            output = "双方同时出招攻击彼此，" + AttackA + "技高一筹对" + AttackB + "造成" + Mathf.Abs(damage) + "点伤害";
        }
        else
        {
            output = "双方同时出招攻击彼此，" + AttackB + "技高一筹对" + AttackA + "造成" + Mathf.Abs(damage)  + "点伤害";
        }
        text.text = output;
        return output;
    }

    public string AttackNDefence(string Attack, string Defence, int damageDeal)
    {
        string output;
        if (damageDeal > 0)
        {
            output = Defence + "试图防守" + Attack + "的攻击，但是失败，收到" + damageDeal + "点伤害";
        }
        else
        {
            output = Defence + "防守了" + Attack + "的攻击，" + Defence + "获得" + Mathf.Abs(damageDeal) + "点护甲";
        }
        text.text = output;
        return output;
    }

    public string AttackNAssasinate(string Attack, string Assassinate, int damageAttack, int damageAssassinate)
    {
        string output = Attack +"正面攻击，并对舍身袭刺的"
            +Assassinate+"造成了"+ Mathf.Abs(damageAttack) +"点暴击伤害，并受到了来自对方袭刺的"
            + Mathf.Abs(damageAssassinate) +"点伤害";
        text.text = output;
        return output;
    }

    public string DefenceNDefence(string DefenceA, string DefenceB)
    {
        string output = "尴尬的是，双方同时进行了防守，各获得 1 点护甲";
        text.text = output;
        return output;
    }

    public string DefenceNAssassinate(string Defence, string Assassinate, int Damage)
    {
        string output = Assassinate+"无视了"+Defence+"的防御，袭刺并造成"+Damage+"点伤害";
        text.text = output;
        return output;
    }

    public string AssassinateNAssassinate(string AssassinateA, string AssassinateB, int DamageA, int DamageB)
    {
        string output = "双方奋不顾身的袭向对方，以伤换伤的扭打在一起；"
            + AssassinateA + "受到了" + Mathf.Abs(DamageB) + "点伤害，" 
            + AssassinateB + "受到了" + Mathf.Abs(DamageA) + "点伤害";
        text.text = output;
        return output;
    }
}
