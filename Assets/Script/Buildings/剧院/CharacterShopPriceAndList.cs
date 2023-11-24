using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class CharacterShopPriceAndList : MonoBehaviour
{
    public static Dictionary<string, ArrayList> CharacterPool = new Dictionary<string, ArrayList>()
    {
        //姓名，{是否在商店或被招募了（默认false），artCode，拥有的tag,价格{金钱，声望，势力（没有写0）}}
        {"王小", new ArrayList(){false,CharacterArtCode.女布衣, new  List<Tag>() { Tag.才华横溢, Tag.小有谋略, Tag.东洋语, Tag.能歌善舞, Tag.不孕不育 }, new List<int>(){100,0,0} } },
        {"诗飞兰", new ArrayList(){false, CharacterArtCode.舞女, new  List<Tag>() { Tag.长袖善舞, Tag.通晓天文, Tag.离经叛道, Tag.演员, Tag.体态端正 }, new List<int>(){100,0,0} } },
        {"任谷雪", new ArrayList(){false, CharacterArtCode.舞女, new  List<Tag>() { Tag.妙手丹心, Tag.小有谋略, Tag.西洋语, Tag.演员, Tag.不孕不育 }, new List<int>(){100,0,0} } },
        {"诗音书", new ArrayList(){false, CharacterArtCode.舞女, new  List<Tag>() { Tag.通晓天文, Tag.东洋语, Tag.能歌善舞, Tag.体态端正, Tag.不孕不育 }, new List<int>(){100,0,0} } },
        {"东方夏沁", new ArrayList(){false, CharacterArtCode.舞女, new  List<Tag>() { Tag.略有才名, Tag.长袖善舞, Tag.棋道, Tag.根骨清奇, Tag.体态端正 }, new List<int>(){100,0,0} } },
        {"双南静", new ArrayList(){false, CharacterArtCode.舞女, new  List<Tag>() { Tag.长袖善舞, Tag.心算, Tag.离经叛道, Tag.演员, Tag.体态端正 }, new List<int>(){100,0,0} } },
        {"雪妙忆", new ArrayList(){false, CharacterArtCode.舞女, new  List<Tag>() { Tag.长袖善舞, Tag.琴师, Tag.外乡人, Tag.珠光宝气, Tag.辟邪安正 }, new List<int>(){100,0,0} } },
    };
    public static Dictionary<string, ArrayList> UnSelectedCharacters
        => CharacterPool.Where(x => (bool)x.Value[0] == false).ToDictionary(x => x.Key, x => x.Value);
    
    public static Dictionary<string, ArrayList> TopCharacterPool = new Dictionary<string, ArrayList>()
    {
        {"栾千雪", new ArrayList(){false,CharacterArtCode.女布衣, new  List<Tag>() { Tag.一点寒芒, Tag.不孕不育, Tag.不孝子, Tag.义肢, Tag.买瓜人}, new List<int>(){100,0,0} } },
        {"问音晓", new ArrayList(){false, CharacterArtCode.女布衣, new  List<Tag>() { Tag.一点寒芒, Tag.不孕不育, Tag.不孝子, Tag.义肢, Tag.买瓜人}, new List<int>(){100,0,0} } },
    };
    public static Dictionary<string, ArrayList> UnSelectedTopCharacters
    => TopCharacterPool.Where(x => (bool)x.Value[0] == false).ToDictionary(x => x.Key, x => x.Value);
    public static List<Character> GetSomeGirls(int count)
    {
        var output = new List<Character>();
        int total = UnSelectedCharacters.Count > count ? count : UnSelectedCharacters.Count;
        for (int i = 0; i < total; i++)
        {
            var random = Random.Range(0, UnSelectedCharacters.Count);
            var key = UnSelectedCharacters.Keys.ToList()[random];
            output.Add(OuputCharacter(key));
        }
        return output;
    }
    public static Character OuputCharacter(string key)
    {
        var value = UnSelectedCharacters[key];
        var character = Instantiate(Resources.Load<Character>("CharacterPrefab/Character"));
        character.hireStage = HireStage.NotInMap;
        DontDestroyOnLoad(character);
        CharacterPool[key][0] = true;
        character.CharacterName = key;
        character.characterArtCode = (CharacterArtCode)value[1];
        character.tagList = value[2] as List<Tag>;
        character.UpdateVariables();
        return character;
    }
    public static Character OuputTopCharacter(string key)
    {
        var value = TopCharacterPool[key];
        var character = Instantiate(Resources.Load<Character>("CharacterPrefab/Character"));
        character.hireStage = HireStage.NotInMap;
        DontDestroyOnLoad(character);
        TopCharacterPool[key][0] = true;
        character.CharacterName = key;
        character.characterArtCode = (CharacterArtCode)value[1];
        character.tagList = value[2] as List<Tag>;
        character.UpdateVariables();
        return character;
    }
    public static List<int> ReturnPrice(string name)
    {
        return CharacterPool[name][3] as List<int>;
    }
    public static void ReturnSomeGirls(List<Character> characters)
    {
        foreach (var character in characters)
        {
            CharacterPool[character.CharacterName][0] = false;
            Destroy(character.gameObject);
        }
    }
    public static void DeleteSomeGirls(List<string> names)
    {
        foreach (var name in names)
        {
            CharacterPool.Remove(name);
        }
    }
}
