using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BanquetCharacterUI : MonoBehaviour
{
    public Character character;
    public Image Head;
    public Text Message;
    public Button Button;

    public void Setup(Character character)
    {
        this.character = character;
        Head.sprite = Resources.Load<Sprite>(ReturnAssetPath.ReturnCharacterSpritePath(character.characterArtCode, false));
        Message.text = $"{character.CharacterName} 接受了您的邀约并来到酒馆";
        Button.onClick.AddListener(Hire);
    }
    public void Hire()
    {
        CharacterHiringEvent hireEvent = new GameObject().AddComponent<CharacterHiringEvent>();
        hireEvent.character = character;
        hireEvent.StartHiring();
    }
    private IEnumerator Start()
    {
        yield return new WaitUntil(() => character.hireStage == HireStage.Hired);
        Button.gameObject.SetActive(false);
        Message.text = $"{character.CharacterName} 开始追随您了";
    }
}
