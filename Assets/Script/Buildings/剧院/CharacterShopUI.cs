using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterShopUI : MonoBehaviour
{
    public List<Character> CharacterPool;
    public CharacterShopCardUI cardTemp;
    public Transform CharacterShop;
    public void Setup(List<Character> characters)
    {
        CharacterPool = characters;
        TransformEx.Clear(CharacterShop);
        foreach (var character in CharacterPool)
        {
            Debug.Log(character);
            var card = Instantiate(cardTemp, CharacterShop);
            card.Setup(character);
        }
    }
    
}
