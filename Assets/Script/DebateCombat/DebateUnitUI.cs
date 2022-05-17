using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DebateUnitUI : MonoBehaviour
{
    public DebateUnit debateUnit;
    public Image head;
    public Text Name;
    public Text PointsText;
    public RectTransform CardPool;

    public void Setup(DebateUnit unit)
    {
        debateUnit = unit;
        Setup();
    }
    public void Setup()
    {
        if (debateUnit == null)
            return;
        string ImagePath = ReturnAssetPath.ReturnCharacterSpritePath(debateUnit.IconArtCode,false);
        head.sprite = Resources.Load<Sprite>(ImagePath);
        Name.text = debateUnit.Name;
        UpdatePoints();
    }
    public void UpdatePoints()
    {
        PointsText.text = debateUnit.Points.ToString();
    }
}
