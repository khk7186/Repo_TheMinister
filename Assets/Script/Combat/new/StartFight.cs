using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;
using DG.Tweening.Plugins.Options;

public class StartFight : MonoBehaviour
{
    public float duration = 0.3f;
    private float distanceX = 2.5f;
    private float distanceY = 2.5f;
    private CharacterModelController model;
    public IEnumerator StartNewFight()
    {
        var selfUnit = GetComponent<CombatCharacterUnit>();
        if (selfUnit.gameObject.activeSelf != false)
        {
            model = selfUnit.GetComponent<CharacterModelController>();
            selfUnit.ModifyStat();
            if (!selfUnit.IsFriend)
            {
                selfUnit.currentAction = AIStrategy(selfUnit);
            }
            if (selfUnit.currentAction == Action.NoSelect)
            {
                selfUnit.currentAction = Action.Attack;
            }
            if (selfUnit.currentAction != Action.Surrender)
                yield return StatChangeAnimation(selfUnit);
            if (selfUnit.currentAction == Action.Surrender)
            {
                yield return Surrender(selfUnit);
            }
            else if (selfUnit.currentAction != Action.Defence)
            {
                yield return Attack(selfUnit);
            }
            //if defence
            else
            {
                selfUnit.target.Defender = selfUnit;
            }
            yield return null;
        }
    }
    public IEnumerator Surrender(CombatCharacterUnit unit)
    {
        if (!unit.IsFriend)
        {
            unit.DestroyHealthBar();
            Vector3Int targetCell = new Vector3Int(unit.cellPosition.x + 10, unit.cellPosition.y, unit.cellPosition.z);
            Vector2 originPosition = transform.position;
            Vector3 targetPosition = CombatCharacterUnit.grid.GetCellCenterWorld(targetCell);
            float time = 0;
            while (time < duration)
            {
                time += Time.deltaTime;
                transform.position = Vector2.Lerp(originPosition, targetPosition, time / duration);
                yield return null;
            }
            unit.SurrenderAction();
        }
    }
    public IEnumerator Attack(CombatCharacterUnit selfUnit)
    {
        if (selfUnit.target == null || selfUnit.target.gameObject.activeSelf == false)
        {
            var PotentialList = FindObjectsOfType<CombatCharacterUnit>().Where(x => x.IsFriend != selfUnit.IsFriend);
            var Potential = PotentialList.ToList()[UnityEngine.Random.Range(0, PotentialList.ToList().Count)];

            selfUnit.target = Potential;
            Debug.Log("changeTarget");
        }
        CombatCharacterUnit target = selfUnit.target;
        bool targetHaveDefender = false;
        if (target != null)
        {
            var targetPosition = target.transform.position;
            var originPosition = transform.position;
            targetHaveDefender = TargetHaveDefender(target);
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
                if (targetHaveDefender && target.Defender.character.health > 0)
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
            selfUnit.MakeTurn();
            model.SetTrigger(selfUnit.currentAction.ToString());
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
        var sideChanger = selfUnit.GetComponent<SideChanger>();
        if (selfUnit.IsFriend)
        {
            if (sideChanger != null) sideChanger.changeSide(false, true);
            if (targetHaveDefender)
            {
                target.Defender.GetComponent<SideChanger>().changeSide(true, false);
            }
        }
        else
        {
            if (sideChanger != null) sideChanger.changeSide(true, false);
            if (targetHaveDefender)
            {
                target.Defender.GetComponent<SideChanger>().changeSide(false, true);
            }
        }
    }
    public Action AIStrategy(CombatCharacterUnit unit)
    {
        int health = (int)unit.healthBar.slider.value;
        bool reachMaxHealth = 18 <= health;
        bool reachMidHealth = 10 <= health;
        bool reachLowHealth = 8 >= health;
        Action[] actionArray = Enum.GetValues(typeof(Action)) as Action[];
        List<Action> actionChoices = actionArray.Where(x => x != Action.NoSelect).ToList();

        if (reachMaxHealth)
        {
            actionChoices.Remove(Action.Surrender);
            actionChoices.Remove(Action.Defence);
            actionChoices.Add(Action.Attack);
            actionChoices.Add(Action.Attack);
            actionChoices.Add(Action.Assassin);
            actionChoices.Add(Action.Assassin);
        }
        if (reachLowHealth)
        {
            actionChoices.RemoveAll(x => x == Action.Attack);
            actionChoices.Add(Action.Assassin);
            actionChoices.Add(Action.Assassin);
            actionChoices.Add(Action.Surrender);
            actionChoices.Add(Action.Surrender);
        }
        if (reachMidHealth)
        {
            actionChoices.Remove(Action.Assassin);
            actionChoices.Remove(Action.Defence);
        }
        Action output = actionChoices[UnityEngine.Random.Range(0, actionChoices.Count)];
        return output;
    }
    public bool TargetHaveDefender(CombatCharacterUnit target)
    {
        if (target == null) return false;
        return target.Defender != null;
    }

    public IEnumerator StatChangeAnimation(CombatCharacterUnit character)
    {
        if (character.gameObject.activeSelf != false)
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
}
