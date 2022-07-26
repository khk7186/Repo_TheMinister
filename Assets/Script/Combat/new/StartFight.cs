using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartFight : MonoBehaviour
{
    public float duration = 0.3f;
    private float distanceX = 2.5f;
    private float distanceY = 2.5f;
    private Animator animator;
    public IEnumerator StartNewFight()
    {
        var selfUnit = GetComponent<CombatCharacterUnit>();
        animator = selfUnit.GetComponent<Animator>();
        selfUnit.ModifyStat();
        yield return StatChangeAnimation(selfUnit);
        
        if (selfUnit.currentAction == Action.NoSelect)
        {
            selfUnit.currentAction = Action.Attack;
        }
        if (selfUnit.currentAction != Action.Defence)
        {
            CombatCharacterUnit target = selfUnit.target;
            if (target == null)
            {
                var PotentialList = FindObjectsOfType<CombatCharacterUnit>();
                foreach (var potential in PotentialList)
                {
                    if (potential.IsFriend != selfUnit.IsFriend)
                    {
                        selfUnit.target = potential;
                        target = selfUnit.target;
                        break;
                    }
                }
            }
            if (target != null)
            {
                var targetPosition = target.transform.position;
                var originPosition = transform.position;
                bool targetHaveDefender = IfTargetHaveDefender(target);
                Vector2 defenderFinalPosition = new Vector2(0, 0);
                Vector2 defenderOriginPosition = new Vector2(0, 0);
                if (target.IsFriend)
                {
                    targetPosition.y += distanceY;
                    targetPosition.x += distanceX;
                    if (targetHaveDefender)
                    {
                        defenderFinalPosition = targetPosition;
                        defenderOriginPosition = target.Defender.transform.position;
                        targetPosition.y += distanceY;
                        targetPosition.x += distanceX;
                    }
                }
                else
                {
                    targetPosition.y -= distanceY;
                    targetPosition.x -= distanceX;
                    if (targetHaveDefender)
                    {
                        defenderFinalPosition = targetPosition;
                        defenderOriginPosition = target.Defender.transform.position;
                        targetPosition.y -= distanceY;
                        targetPosition.x -= distanceX;
                    }
                }
                float time = 0;
                while (time < duration)
                {
                    time += Time.deltaTime;
                    transform.position = Vector2.Lerp(originPosition, targetPosition, time / duration);
                    if (targetHaveDefender)
                    {
                        target.Defender.transform.position = Vector2.Lerp(defenderOriginPosition, defenderFinalPosition, time / duration);
                    }
                    yield return null;
                }
                time = 0;
                // Do Damage Calculations
                selfUnit.MakeTurn();
                animator.SetTrigger(selfUnit.currentAction.ToString());
                yield return new WaitForSeconds(0.5f);
                while (time < duration)
                {
                    time += Time.deltaTime;
                    transform.position = Vector2.Lerp(targetPosition, originPosition, time / duration);
                    if (targetHaveDefender)
                    {
                        target.Defender.transform.position = Vector2.Lerp(defenderFinalPosition, defenderOriginPosition, time / duration);
                    }
                    yield return null;
                }
            }
            //TODO: if no other attackable target, return game result
            else
            {

            }
        }
        //if defence
        else
        {
            selfUnit.target.Defender = selfUnit;
        }
        yield return null;
        
    }
    public bool IfTargetHaveDefender(CombatCharacterUnit target)
    {
        if (target == null) return false;
        return target.Defender != null;
    }

    public IEnumerator StatChangeAnimation(CombatCharacterUnit character)
    {
        CharacterStat stat = character.stat;
        var animat = Instantiate(Resources.Load<StatChangeAnimation>("CombatScene/StatAnimation"), MainCanvas.FindMainCanvas());
        var Position = transform.position;
        var canvas = MainCanvas.FindMainCanvas().GetComponent<RectTransform>();
        Vector2 AP = WorldToCanvasPosition.GetCanvasPosition(canvas, Camera.main, Position);
        AP.y += 120;
        animat.GetComponent<RectTransform>().anchoredPosition = AP;
        var animationName = "";
        switch (stat)
        {
            case CharacterStat.weak:
                animationName = "Èõ";
                break;
            case CharacterStat.normal:
                animationName = "Õý³£";
                break;
            case CharacterStat.strong:
                animationName = "Ç¿";
                break;
            default:
                break;
        }
        yield return StartCoroutine(animat.DestroyAfterPlay(animationName));
    }
}
