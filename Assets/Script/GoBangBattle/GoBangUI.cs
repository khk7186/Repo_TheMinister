using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoBangUI : MonoBehaviour
{
    public Image playerIdle;
    public Image enemyIdle;

    public AbilityButton abilityButtonPref;

    public Transform playerTags;
    public Transform enemyTags;

    public bool Setted = false;

    public void Setup(Character player, Character enemy)
    {
        if (Setted == false)
        {
            string playerSpritePath = ("Art/CharacterSprites/Idle/Idle_" + player.characterArtCode.ToString()).Replace(" ", string.Empty);
            playerIdle.sprite = Resources.Load<Sprite>(playerSpritePath);
            TagInstan(player);

            string enemySpritePath = ("Art/CharacterSprites/Idle/Idle_" + enemy.characterArtCode.ToString()).Replace(" ", string.Empty);
            playerIdle.sprite = Resources.Load<Sprite>(enemySpritePath);
            TagInstan(enemy);
            Setted = true;
        }
    }

    public void TagInstan(Character target)
    {
        foreach (Tag tag in target.tagList)
        {
            var output = Instantiate(abilityButtonPref, playerTags);
            string FolderPathOfTags = ("Art/Tags/" + tag.ToString()).Replace(" ", string.Empty);
            output.GetComponent<Image>().sprite = Resources.Load<Sprite>(FolderPathOfTags);
        }
    }
}
