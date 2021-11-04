using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "GameItemFile")]
public class SOItem : ScriptableObject
{
    
    public Dictionary<ItemName, Tag> ItemMap = new Dictionary<ItemName, Tag>();
    public Sprite NullSprite;

    private void Awake()
    {
        ItemMap.Add(ItemName.Null, Tag.Null);
    }



}
