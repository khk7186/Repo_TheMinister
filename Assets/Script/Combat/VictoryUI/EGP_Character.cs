using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EGP_Character : MonoBehaviour
{
    public Image CharacterIcon;
    public Image State;

    private void Awake()
    {
        State.gameObject.SetActive(false);
        SetTransparent();
        SetState();
    }
    public void Setup(CharacterArtCode characterArtCode)
    {
        gameObject.SetActive(true);
        CharacterIcon.sprite = Resources.Load<Sprite>(ReturnAssetPath.ReturnCharacterSpritePath(characterArtCode, false));
    }
    public void SetState(bool On = false)
    {
        State.gameObject.SetActive(On);
    }
    public void SetTransparent(bool On = false)
    {
        if (On)
        {

            CharacterIcon.color = new Color(CharacterIcon.color.r, CharacterIcon.color.g, CharacterIcon.color.b, 61);
        }
        else
        {
            CharacterIcon.color = new Color(255, 255, 255, 255);
        }
    }
}
