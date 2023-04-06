using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCAI : MonoBehaviour, IDiceRollEvent
{
    public Character SelfCharacter;
    public Dictionary<NPCAI, float> Relationship;
    public int winPoints = 0;
    protected IAIMovementStrategy movementStrategy = new DefaultInGameAI();
    protected IConspiracyStrategy conspiracyStrategy = new DefaultConspiracyStrategy();
    //protected List<QuestLine>
    //protected List<IQuest> currentQuests = new List<IQuest>();
    public void OnNotify(object value, NotificationType notificationType)
    {
        if (notificationType == NotificationType.DiceRoll)
        {
            movementStrategy.Move();
            conspiracyStrategy.TryConspiracy();
        }
    }
}