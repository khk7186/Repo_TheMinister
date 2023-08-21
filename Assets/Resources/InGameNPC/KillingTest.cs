using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillingTest : MonoBehaviour
{
    public RoitCharacter RoitCharacter;
    public RoitInGameAI RoitInGameAI;
    public Character Character;
    public DefaultInGameAI DefaultInGameAI;

    public void Awake()
    {
        RoitInGameAI.SetupRoitAI(RoitCharacter,null);
        DefaultInGameAI.Setup(Character);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(RoitInGameAI.transform.position, 10);
    }
}
