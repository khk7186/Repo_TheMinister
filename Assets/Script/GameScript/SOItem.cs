using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "GameItemFile")]
public class SOItem : ScriptableObject
{
    
    public static Dictionary<ItemName, Tag> ItemMap = new Dictionary<ItemName, Tag>() 
    {
        {ItemName.ɽ����,Tag.��ͨ����},
        {ItemName.���زо�,Tag.��ʦ},
        {ItemName.����������,Tag.���Ŷݼ�},
        {ItemName.��󡹦�ؼ�,Tag.��󡹦},
        {ItemName.������,Tag.ͨ������},
        {ItemName.��˪����,Tag.��˪����},
        {ItemName.����,Tag.����},
        {ItemName.����ʵ�,Tag.������},
        {ItemName.����ʵ�,Tag.������},
        {ItemName.����,Tag.�ܸ�����},
        {ItemName.�Ӽ�,Tag.�����弼},
        {ItemName.���ӵ�,Tag.��������},
        {ItemName.����,Tag.���в���},
        {ItemName.����,Tag.ҹ������},
        {ItemName.��,Tag.��},
<<<<<<< HEAD
        {ItemName.����,Tag.����},
        {ItemName.���¾�,Tag.��ʿ},
        {ItemName.������,Tag.ɮ��}
=======
        {ItemName.ë��,Tag.����},
        {ItemName.����,Tag.��ʿ},
        {ItemName.����,Tag.ɮ��}

>>>>>>> ba7bd96f2dfe4a2990fd031a19c82a56d93dec48
    };
    public Sprite NullSprite;

    private void Awake()
    {
    }



}
