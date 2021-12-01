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
        {ItemName.ë��,Tag.����},
        {ItemName.����,Tag.��ʿ},
        {ItemName.����,Tag.ɮ��}
    };
    public static Dictionary<ItemType, List<ItemName>> ItemTypeDict = new Dictionary<ItemType, List<ItemName>>()
    {
        { 
            ItemType.����, new List<ItemName>()
            {
                ItemName.��˪����,
                ItemName.����,
                ItemName.ŷұ�ӵĴ�,
                ItemName.ŷұ�ӵ�С��,
                ItemName.��,
                ItemName.��,
                ItemName.ǹ,
                ItemName.��,
                ItemName.�
            }
        },
        {
            ItemType.��ҩ, new List<ItemName>()
            {
                ItemName.���ӵ�
            }
        },
        {
            ItemType.�鼮, new List<ItemName>()
            {
                ItemName.ɽ����,
                ItemName.���زо�,
                ItemName.��󡹦�ؼ�,
                ItemName.����ʵ�,
                ItemName.����ʵ�,
                ItemName.�Ӽ�,
                ItemName.������,
                ItemName.�Ƶ��ھ�,
                ItemName.���ݸ�Ŀ,
                ItemName.ī�ӷǹ�,
                ItemName.ī�Ӽ氮,
                ItemName.����,
                ItemName.Ψ����,
                ItemName.���,
                ItemName.��ֳ�д�,
                ItemName.�˺��Ӳ���,
                ItemName.�����,
                ItemName.ϴԩ¼,
                ItemName.Т����,
                ItemName.����,
                ItemName.ҩ�Ĵ�ȫ,
                ItemName.��Ա����������,
                ItemName.��ͷ���
            }
        },
        {
            ItemType.����, new List<ItemName>()
            {
                ItemName.��,
                ItemName.���ֵ�����,
            }
        },
        {
            ItemType.��װ, new List<ItemName>()
            {
                ItemName.����
            }
        },
        {
            ItemType.����, new List<ItemName>()
            {
            }
        },
        {
            ItemType.�ӻ�, new List<ItemName>()
            {
                ItemName.����������,
                ItemName.������,
                ItemName.����,
                ItemName.ë��,
                ItemName.����,
                ItemName.����,
                ItemName.������ӡ,
                ItemName.����ƿ,
                ItemName.�Ĺ�״,
                ItemName.���״,
                ItemName.�Ӽ�,
                ItemName.����
            }
        },
        {
            ItemType.ҩ��, new List<ItemName>()
            {
                ItemName.����
            }
        }
    };

    public static Dictionary<BuildingType, List<ItemName>> BuildingCraftDict = new Dictionary<BuildingType, List<ItemName>>()
    {
        {
            BuildingType.������, new List<ItemName>()
            {
                ItemName.��,
                ItemName.ǹ,
                ItemName.��,
                ItemName.�,
                ItemName.��,
                ItemName.��ʯ�ҷ繭,
                ItemName.�һ�ն�Ƶ�,
                ItemName.��ľ�׵�ǹ,
                ItemName.��ʤ��,
                ItemName.������,
                ItemName.����ǹ,
                ItemName.��Դ��,
                ItemName.��Ǯ��,
                ItemName.����,
                ItemName.Ѫ����,
                ItemName.��ü��,
                ItemName.�˻�����,
                ItemName.�����滨��
            }
        },
        {
            BuildingType.ҩ��, new List<ItemName>()
            {
                ItemName.���ӵ�,
                ItemName.��ҩ,
                ItemName.��������ҩ,
                ItemName.ʮȫ����,
                ItemName.����ɢ,
                ItemName.������,
                ItemName.ϴ�赤,
                ItemName.ֹѪ��,
                ItemName.����������,
                ItemName.����컯��
            }    
        },
        {
            BuildingType.��֯��, new List<ItemName>()
            {
                ItemName.Ƥ��,
                ItemName.����,
                ItemName.�ƽ��,
                ItemName.������,
                ItemName.�컧��,
                ItemName.���廪��
            }
        }
    };

    public static Dictionary<List<ItemName>, ItemName> MergeItemDict = new Dictionary<List<ItemName>, ItemName>
    {
        {new List<ItemName>(){ItemName.����,ItemName.Ƥ��},ItemName.��},
        {new List<ItemName>(){ItemName.����,ItemName.ľͷ},ItemName.ǹ},
        {new List<ItemName>(){ItemName.ͭ��,ItemName.����},ItemName.��},
        {new List<ItemName>(){ItemName.����,ItemName.����},ItemName.�},
        {new List<ItemName>(){ItemName.ľͷ,ItemName.����},ItemName.��},
        {new List<ItemName>(){ItemName.��,ItemName.��ĸ��},ItemName.��ʯ�ҷ繭},
        {new List<ItemName>(){ItemName.��,ItemName.��Ѫ��},ItemName.�һ�ն�Ƶ�},
        {new List<ItemName>(){ItemName.ǹ,ItemName.��ˮ��},ItemName.��ľ�׵�ǹ},
        {new List<ItemName>(){ItemName.����,ItemName.Ƥ��},ItemName.Ƥ��},
        {new List<ItemName>(){ItemName.����,ItemName.����},ItemName.����},
        {new List<ItemName>(){ItemName.����,ItemName.������Ļƽ�},ItemName.�ƽ��},
        {new List<ItemName>(){ItemName.����װ,ItemName.�廨��},ItemName.������},
        {new List<ItemName>(){ItemName.������,ItemName.�챦ʯ},ItemName.�컧��},
        {new List<ItemName>(){ItemName.����,ItemName.����},ItemName.���廪��},
        {new List<ItemName>(){ItemName.���,ItemName.����},ItemName.����},
        {new List<ItemName>(){ItemName.���,ItemName.������Ļƽ�},ItemName.��Ǯ��},
        {new List<ItemName>(){ItemName.�ƾ�,ItemName.�˽���},ItemName.��ҩ},
        {new List<ItemName>(){ItemName.�޺���,ItemName.������},ItemName.����ɢ},
        {new List<ItemName>(){ItemName.����,ItemName.��֥,ItemName.������},ItemName.��������ҩ},
        {new List<ItemName>(){ItemName.����,ItemName.�˲�,ItemName.����},ItemName.ʮȫ����},
        {new List<ItemName>(){ItemName.���,ItemName.����},ItemName.ϴ�赤},
        {new List<ItemName>(){ItemName.����,ItemName.����},ItemName.������},
        {new List<ItemName>(){ItemName.�׻������,ItemName.��ɽ��},ItemName.����������},
        {new List<ItemName>(){ItemName.�׻������,ItemName.�ǳ���},ItemName.����컯��}



    };
    public Sprite NullSprite;




}
