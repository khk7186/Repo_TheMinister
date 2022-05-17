using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebateUnit : MonoBehaviour
{
    public string Name;
    public CharacterArtCode IconArtCode;
    public List<Character> characters = new List<Character>();
    public int Points = 4000;
    public DebateUnitUI UnitUI;

    public void Setup(List<Character> characters, string name, CharacterArtCode iconArtCode)
    {
        characters.ForEach(c => this.characters.Add(c));
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