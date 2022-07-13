using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using DG;

public class DebateUnit : MonoBehaviour
{
    public string Name;
    public CharacterArtCode IconArtCode;
    public List<Character> characters = new List<Character>();
    public List<Character> selectCharacters = new List<Character>();
    public List<DebateCharacterCard> SelectedCards = new List<DebateCharacterCard>();
    public List<DebateCharacterCard> characterCards = new List<DebateCharacterCard>();
    public bool isPlayer = false;
    public int Points = 4000;
    public bool isActive = false;
    public DebateUnitUI UnitUI = null;
    public int index => UnitUI.index;
    public Vector2 cardConfirmPosition;
    public void Setup(List<Character> characters, string name, CharacterArtCode iconArtCode, bool isPlayer = false)
    {
        if (characters == null)
        {
            GetComponent<DebateUnitUI>().CardPool.gameObject.SetActive(false);
            gameObject.SetActive(false);
            return;
        }
        characters.ForEach(c => this.characters.Add(c));
        this.isPlayer = isPlayer;
        Name = name;
        IconArtCode = iconArtCode;
    }
    public void UnitDown()
    {
        UnitUI.gameObject.SetActive(false);
        gameObject.SetActive(false);
    }
    public void PointsChange(int points)
    {
        Points += points;
        UnitUI.PointsText.text = Points.ToString();
    }
    public void SetUnitUI(DebateUnitUI unitUI)
    {
        UnitUI = unitUI;
        UpdateDeck();
    }
    public void UpdateDeck()
    {
        if (UnitUI == null) return;
        UnitUI.Setup(this);
    }

    public void CheckSelection()
    {
        SelectedCards.Clear();
        selectCharacters.Clear();
        foreach (DebateCharacterCard card in characterCards)
        {
            if (card.CardUI.OnSelect == true)
            {
                SelectedCards.Add(card);
                Debug.Log("selected");
            }
        }
        foreach (DebateCharacterCard card in SelectedCards)
        {
            selectCharacters.Add(card.character);
        }
    }
}