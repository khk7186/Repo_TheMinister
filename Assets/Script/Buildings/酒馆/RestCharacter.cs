using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestCharacter : MonoBehaviour
{
    public static void RecoverCharcter(Character character, int healthAdd)
    {
        character.health += healthAdd;
    }
}
