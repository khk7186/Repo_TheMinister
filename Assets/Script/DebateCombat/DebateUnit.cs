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
    public bool isPlayer = false;
    public int Points = 4000;
    public bool isActive = false;
    public DebateUnitUI UnitUI;
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

}