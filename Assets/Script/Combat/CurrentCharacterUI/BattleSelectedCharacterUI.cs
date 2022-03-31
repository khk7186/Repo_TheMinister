using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleSelectedCharacterUI : MonoBehaviour
{
    public Slider healthSlider;
    public Image characterImage;

    public void Setup(Character character, BattleType battleType)
    {
        if (character == null)
        {
            characterImage.gameObject.SetActive(false);
            healthSlider.gameObject.SetActive(false);
        }
        else
        {
            characterImage.gameObject.SetActive(true);
            healthSlider.gameObject.SetActive(true);
            switch (battleType)
            {
                default:
                    break;
                case BattleType.Debate:
                    healthSlider.value = character.health / 20;
                    break;
                case BattleType.Combat:
                    healthSlider.value = character.loyalty / 20;
                    break;
            }
            string imagePath = ("Art/CharacterSprites/Idle/Idle_" + character.characterArtCode).Replace(" ", string.Empty);
            characterImage.sprite = Resources.Load<Sprite>(imagePath);
        }
    }
}
