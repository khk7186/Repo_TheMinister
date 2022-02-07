using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class BattleUI : MonoBehaviour,IScrollHandler
{
    public BattleCharacterHeadUI PlayerCh1;
    public BattleCharacterHeadUI PlayerCh2;
    public BattleCharacterHeadUI PlayerCh3;
    public BattleCharacterHeadUI EnemyCh1;
    public BattleCharacterHeadUI EnemyCh2;
    public BattleCharacterHeadUI EnemyCh3;

    public BattleCharacterHeadUI PlayerCurrentCharacter;
    public BattleCharacterHeadUI EnemyCurrentCharacter;

    public Text ScoreBoard;
    public BattleInformationUI informationUI;
    public RectTransform ActionChoosePannel;

    public Transform AbilityList;

    public BattleSelectedCharacterUI playerSideImage;
    public BattleSelectedCharacterUI enemySideImage;

    public BattleType battleType;
    //Buttons 
    public Transform Attak;
    public Transform Defence;
    public Transform Assassinate;
    public Transform Surrender;
    public Transform Confirm;

    public CombatUICharacterRotateAnimation characterRotateAnimation;
    public void Setup(List<Character> playerList, List<Character> enemyList, BattleType battleType)
    {
        //TODO: foreach character spawn new headui.
        PlayerCh1.Setup(playerList[0], battleType, transform, true);
        PlayerCh2.Setup(playerList[1], battleType, transform, true);
        PlayerCh3.Setup(playerList[2], battleType, transform, true);
        EnemyCh1.Setup(enemyList[0], battleType, transform, false);
        EnemyCh2.Setup(enemyList[1], battleType, transform, false);
        EnemyCh3.Setup(enemyList[2], battleType, transform, false);
        this.battleType = battleType;
        if (PlayerCurrentCharacter == null)
        {
            PlayerCurrentCharacter = characterRotateAnimation.Front.GetComponent<BattleCharacterHeadUI>();
        }
    }
    public void characterSwitch(BattleCharacterHeadUI subject, BattleCharacterHeadUI compare)
    {
        
    }

#if UNITY_EDITOR
    private void Start()
    {
    }

    public void OnScroll(PointerEventData eventData)
    {
        if (Input.mouseScrollDelta.y > 0)
        {
            characterRotateAnimation.ScrollUp();
        }
        else if(Input.mouseScrollDelta.y < 0)
        {
            characterRotateAnimation.ScrollDown();
        }
        PlayerCurrentCharacter = characterRotateAnimation.Front.GetComponent<BattleCharacterHeadUI>();
    }
#endif
}
