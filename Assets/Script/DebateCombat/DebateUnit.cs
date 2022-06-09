using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG;

public class DebateUnit : MonoBehaviour
{
    public string Name;
    public CharacterArtCode IconArtCode;
    public List<Character> characters = new List<Character>();
    public List<Character> selectCharacters = new List<Character>();
    public List<DebateCharacterCard> characterCards = new List<DebateCharacterCard>();
    public List<DebateCharacterCard> SelectedCards = new List<DebateCharacterCard>();
    public bool isPlayer = false;
    public int Points = 4000;
    public bool isActive = false;
    public DebateUnitUI UnitUI;
    public int index => UnitUI.index;
    public Vector2 cardConfirmPosition;
    public void Setup(List<Character> characters, string name, CharacterArtCode iconArtCode, bool isPlayer = false)
    {
        characters.ForEach(c => this.characters.Add(c));
        this.isPlayer = isPlayer;
        Name = name;
        IconArtCode = iconArtCode;
    }
    public void PointsChange(int points)
    {
        Points += points;
    }
    public void SetUnitUI(DebateUnitUI unitUI)
    {
        UnitUI = unitUI;
    }

    public void CheckSelection()
    {
        SelectedCards.Clear();
        foreach (DebateCharacterCard card in characterCards)
        {
            if (card.CardUI.OnSelect)
            {
                SelectedCards.Add(card);
            }
        }
    }
}