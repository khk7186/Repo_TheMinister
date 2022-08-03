using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterHiringEvent : MonoBehaviour
{
    private static Dictionary<Rarerity, Dictionary<ItemName, int>> FemalePoestRarityItemRequestDict
        = new Dictionary<Rarerity, Dictionary<ItemName, int>>
        {
            {Rarerity.N,
                new Dictionary<ItemName, int>()
                {
                    {ItemName.毛笔,1}
                 }
            },
            {
             Rarerity.R,
                new Dictionary<ItemName, int>()
                {
                    {ItemName.毛笔,2},
                    {ItemName.红花,1}
                 }
            } ,
            {
             Rarerity.SR,
                new Dictionary<ItemName, int>()
                {
                    {ItemName.毛笔,3},
                    {ItemName.红花,2},
                    {ItemName.伤寒杂病论,1},
                    {ItemName.水翁花,1}
                 }
            },
            {
             Rarerity.SSR,
                new Dictionary<ItemName, int>()
                {
                    {ItemName.毛笔,4},
                    {ItemName.红花,3},
                    {ItemName.伤寒杂病论,2},
                    {ItemName.水翁花,2},
                    {ItemName.长袖装,1 },
                    {ItemName.天机造化丹,1},
                 }
            },
            {
             Rarerity.UR,
                new Dictionary<ItemName, int>()
                {
                    {ItemName.毛笔,5},
                    {ItemName.红花,4},
                    {ItemName.伤寒杂病论,3},
                    {ItemName.水翁花,3},
                    {ItemName.长袖装,2},
                    {ItemName.天机造化丹,1},
                    {ItemName.和氏璧,1}
                 }
            },
        };
    private static Dictionary<Rarerity, Dictionary<ItemName, int>> MalePoetRarityItemRequestDict
        = new Dictionary<Rarerity, Dictionary<ItemName, int>>
        {
            {Rarerity.N,
                new Dictionary<ItemName, int>()
                {
                    {ItemName.毛笔,1}
                 }
            },
            {
             Rarerity.R,
                new Dictionary<ItemName, int>()
                {
                    {ItemName.毛笔,2},
                    {ItemName.剑,1}
                 }
            } ,
            {
             Rarerity.SR,
                new Dictionary<ItemName, int>()
                {
                    {ItemName.毛笔,3},
                    {ItemName.剑,2},
                    {ItemName.货殖列传,1},
                    {ItemName.竹叶青,1}
                 }
            },
            {
             Rarerity.SSR,
                new Dictionary<ItemName, int>()
                {
                    {ItemName.毛笔,4},
                    {ItemName.剑,3},
                    {ItemName.货殖列传,2},
                    {ItemName.竹叶青,2},
                    {ItemName.长袖装,1 },
                    {ItemName.山海经,1},
                 }
            },
            {
             Rarerity.UR,
                new Dictionary<ItemName, int>()
                {
                    {ItemName.毛笔,5},
                    {ItemName.红花,4},
                    {ItemName.伤寒杂病论,3},
                    {ItemName.水翁花,3},
                    {ItemName.长袖装,2},
                    {ItemName.山海经,2},
                    {ItemName.天机造化丹,1},
                    {ItemName.和氏璧,1}
                 }
            },
        };
    private static Dictionary<Rarerity, Dictionary<ItemName, int>> MaleBladeUserRarityItemRequestDict
        = new Dictionary<Rarerity, Dictionary<ItemName, int>>
        {
            {Rarerity.N,
                new Dictionary<ItemName, int>()
                {
                    {ItemName.刀,1}
                 }
            },
            {
             Rarerity.R,
                new Dictionary<ItemName, int>()
                {
                    {ItemName.刀,2},
                    {ItemName.青酒,1}
                 }
            } ,
            {
             Rarerity.SR,
                new Dictionary<ItemName, int>()
                {
                    {ItemName.刀,3},
                    {ItemName.青酒,2},
                    {ItemName.大砍刀,1},
                    {ItemName.虎骨,1}
                 }
            },
            {
             Rarerity.SSR,
                new Dictionary<ItemName, int>()
                {
                    {ItemName.刀,4},
                    {ItemName.青酒,3},
                    {ItemName.大砍刀,2},
                    {ItemName.虎骨,2},
                    {ItemName.烈火斩云刀,1 },
                    {ItemName.三味酒,1},
                 }
            },
            {
             Rarerity.UR,
                new Dictionary<ItemName, int>()
                {
                    {ItemName.刀,5},
                    {ItemName.青酒,4},
                    {ItemName.大砍刀,3},
                    {ItemName.虎骨,3},
                    {ItemName.烈火斩云刀,2 },
                    {ItemName.三味酒,2},
                    {ItemName.百胜刀,1},
                    {ItemName.十全大补丸,1}
                 }
            },
        };
    private static Dictionary<Rarerity, Dictionary<ItemName, int>> ElderlyRarityItemRequestDict
        = new Dictionary<Rarerity, Dictionary<ItemName, int>>
        {
            {Rarerity.N,
                new Dictionary<ItemName, int>()
                {
                    {ItemName.舒服的椅子,1}
                 }
            },
            {
             Rarerity.R,
                new Dictionary<ItemName, int>()
                {
                    {ItemName.舒服的椅子,2},
                    {ItemName.杏仁酒,1}
                 }
            } ,
            {
             Rarerity.SR,
                new Dictionary<ItemName, int>()
                {
                    {ItemName.舒服的椅子,3},
                    {ItemName.杏仁酒,2},
                    {ItemName.人参,1},
                    {ItemName.清炒菜心,1}
                 }
            },
            {
             Rarerity.SSR,
                new Dictionary<ItemName, int>()
                {
                    {ItemName.舒服的椅子,4},
                    {ItemName.杏仁酒,3},
                    {ItemName.人参,2},
                    {ItemName.清炒菜心,2},
                    {ItemName.神气丹,1 },
                    {ItemName.美梦酒,1},
                 }
            },
            {
             Rarerity.UR,
                new Dictionary<ItemName, int>()
                {
                    {ItemName.舒服的椅子,5},
                    {ItemName.杏仁酒,4},
                    {ItemName.人参,3},
                    {ItemName.清炒菜心,3},
                    {ItemName.神气丹,2 },
                    {ItemName.美梦酒,2},
                    {ItemName.阴阳玄龙丹,1},
                    {ItemName.长生不老药,1}
                 }
            },
        };
    private static Dictionary<Rarerity, Dictionary<ItemName, int>> MaleGovRarityItemRequestDict
    = new Dictionary<Rarerity, Dictionary<ItemName, int>>
    {
            {Rarerity.N,
                new Dictionary<ItemName, int>()
                {
                    {ItemName.文官状,1}
                 }
            },
            {
             Rarerity.R,
                new Dictionary<ItemName, int>()
                {
                    {ItemName.文官状,2},
                    {ItemName.官宸书,1}
                 }
            } ,
            {
             Rarerity.SR,
                new Dictionary<ItemName, int>()
                {
                    {ItemName.文官状,3},
                    {ItemName.官宸书,2},
                    {ItemName.丝绸,1},
                    {ItemName.金绿宝石,1}
                 }
            },
            {
             Rarerity.SSR,
                new Dictionary<ItemName, int>()
                {
                    {ItemName.文官状,4},
                    {ItemName.官宸书,3},
                    {ItemName.丝绸,2},
                    {ItemName.金绿宝石,2},
                    {ItemName.龙井竹荪,1 },
                    {ItemName.云纹袍,1},
                 }
            },
            {
             Rarerity.UR,
                new Dictionary<ItemName, int>()
                {
                    {ItemName.文官状,5},
                    {ItemName.官宸书,4},
                    {ItemName.丝绸,3},
                    {ItemName.金绿宝石,3},
                    {ItemName.龙井竹荪,2 },
                    {ItemName.云纹袍,2},
 //                 {ItemName.青织飞鱼袍,1},
                    {ItemName.和氏璧,1}
                 }
            },

    };
    private static Dictionary<Rarerity, Dictionary<ItemName, int>> MaleFighterRarityItemRequestDict
    = new Dictionary<Rarerity, Dictionary<ItemName, int>>
    {
            {Rarerity.N,
                new Dictionary<ItemName, int>()
                {
                   {ItemName.棍子,1}
                 }
            },
            {
             Rarerity.R,
                new Dictionary<ItemName, int>()
                {
                    {ItemName.棍子,2},
                    {ItemName.羊酒,1}
                 }
            } ,
            {
             Rarerity.SR,
                new Dictionary<ItemName, int>()
                {
                    {ItemName.棍子,3},
                    {ItemName.羊酒,2},
                    {ItemName.白银枪,1},
                    {ItemName.护心镜,1}
                 }
            },
            {
             Rarerity.SSR,
                new Dictionary<ItemName, int>()
                {
                    {ItemName.棍子,4},
                    {ItemName.羊酒,3},
                    {ItemName.白银枪,2},
                    {ItemName.护心镜,2},
                    {ItemName.混元功,1 },
                    {ItemName.天霸方天戟,1},
                 }
            },
            {
             Rarerity.UR,
                new Dictionary<ItemName, int>()
                {
                    {ItemName.棍子,5},
                    {ItemName.羊酒,4},
                    {ItemName.白银枪,3},
                    {ItemName.护心镜,3},
                    {ItemName.混元功,2 },
                    {ItemName.天霸方天戟,2},
                    {ItemName.青龙方戟,1},
                    {ItemName.十全大补丸,1}
                 }
            },
    };
    private static Dictionary<Rarerity, Dictionary<ItemName, int>> FemaleCivilianRarityItemRequestDict
    = new Dictionary<Rarerity, Dictionary<ItemName, int>>
    {
            {Rarerity.N,
                new Dictionary<ItemName, int>()
                {
                    {ItemName.唇纸,1}
                 }
            },
            {
             Rarerity.R,
                new Dictionary<ItemName, int>()
                {
                    {ItemName.唇纸,2},
                    {ItemName.胭脂,1}
                 }
            } ,
            {
             Rarerity.SR,
                new Dictionary<ItemName, int>()
                {
                    {ItemName.唇纸,3},
                    {ItemName.胭脂,2},
                    {ItemName.朱砂脂,1},
                    {ItemName.祖母绿,1}
                 }
            },
            {
             Rarerity.SSR,
                new Dictionary<ItemName, int>()
                {
                    {ItemName.唇纸,4},
                    {ItemName.胭脂,3},
                    {ItemName.朱砂脂,2},
                    {ItemName.祖母绿,2},
                    {ItemName.锦绣华服,1 },
                    {ItemName.玉手镯,1},
                 }
            },
            {
             Rarerity.UR,
                new Dictionary<ItemName, int>()
                {
                    {ItemName.唇纸,5},
                    {ItemName.胭脂,4},
                    {ItemName.朱砂脂,3},
                    {ItemName.祖母绿,3},
                    {ItemName.锦绣华服,2 },
                    {ItemName.玉手镯,2},
                    {ItemName.钻石,1},
                    {ItemName.和氏璧,1}
                 }
            },
    };
    private static Dictionary<Rarerity, Dictionary<ItemName, int>> MissionaryRarityItemRequestDict
    = new Dictionary<Rarerity, Dictionary<ItemName, int>>
    {
            {Rarerity.N,
                new Dictionary<ItemName, int>()
                {
                    {ItemName.咖啡,1}
                 }
            },
            {
             Rarerity.R,
                new Dictionary<ItemName, int>()
                {
                    {ItemName.咖啡,2},
                    {ItemName.汤头歌诀,1}
                 }
            } ,
            {
             Rarerity.SR,
                new Dictionary<ItemName, int>()
                {
                    {ItemName.咖啡,3},
                    {ItemName.汤头歌诀,2},
                    {ItemName.木须肉,1},
                    {ItemName.货殖列传,1}
                 }
            },
            {
             Rarerity.SSR,
                new Dictionary<ItemName, int>()
                {
                    {ItemName.咖啡,4},
                    {ItemName.汤头歌诀,3},
                    {ItemName.木须肉,2},
                    {ItemName.货殖列传,2},
                    {ItemName.鬼谷子,1 },
                    {ItemName.阴阳八卦盘,1},
                 }
            },
            {
             Rarerity.UR,
                new Dictionary<ItemName, int>()
                {
                    {ItemName.咖啡,5},
                    {ItemName.汤头歌诀,4},
                    {ItemName.木须肉,3},
                    {ItemName.货殖列传,3},
                    {ItemName.鬼谷子,2 },
                    {ItemName.阴阳八卦盘,2},
                    {ItemName.大汗之鹰,1},
                    {ItemName.和氏璧,1}
                 }
            },
    };
    private static Dictionary<Rarerity, Dictionary<ItemName, int>> MusicianRarityItemRequestDict
    = new Dictionary<Rarerity, Dictionary<ItemName, int>>
    {
            {Rarerity.N,
                new Dictionary<ItemName, int>()
                {
                    {ItemName.吵闹的鹦鹉,1}
                 }
            },
            {
             Rarerity.R,
                new Dictionary<ItemName, int>()
                {
                    {ItemName.吵闹的鹦鹉,2},
                    {ItemName.有破损的黄金,1}
                 }
            } ,
            {
             Rarerity.SR,
                new Dictionary<ItemName, int>()
                {
                    {ItemName.吵闹的鹦鹉,3},
                    {ItemName.有破损的黄金,2},
                    {ItemName.女儿红,1},
                    {ItemName.杜康酒,1}
                 }
            },
            {
             Rarerity.SSR,
                new Dictionary<ItemName, int>()
                {
                    {ItemName.吵闹的鹦鹉,4},
                    {ItemName.有破损的黄金,3},
                    {ItemName.女儿红,2},
                    {ItemName.杜康酒,2},
                    {ItemName.长袖装,1 },
                    {ItemName.美梦酒,1},
                 }
            },
            {
             Rarerity.UR,
                new Dictionary<ItemName, int>()
                {
                    {ItemName.吵闹的鹦鹉,5},
                    {ItemName.有破损的黄金,4},
                    {ItemName.女儿红,3},
                    {ItemName.杜康酒,3},
                    {ItemName.长袖装,2 },
                    {ItemName.美梦酒,2},
                    {ItemName.仙人醉,1},
                    {ItemName.和氏璧,1}
                 }
            },
    };
    private static Dictionary<Rarerity, Dictionary<ItemName, int>> StorytellerRarityItemRequestDict
    = new Dictionary<Rarerity, Dictionary<ItemName, int>>
    {
            {Rarerity.N,
                new Dictionary<ItemName, int>()
                {
                    {ItemName.演员的自我修养,1}
                 }
            },
            {
             Rarerity.R,
                new Dictionary<ItemName, int>()
                {
                    {ItemName.演员的自我修养,2},
                    {ItemName.洗冤录,1}
                 }
            } ,
            {
             Rarerity.SR,
                new Dictionary<ItemName, int>()
                {
                    {ItemName.演员的自我修养,3},
                    {ItemName.洗冤录,2},
                    {ItemName.货殖列传,1},
                    {ItemName.木须柿子,1}
                 }
            },
            {
             Rarerity.SSR,
                new Dictionary<ItemName, int>()
                {
                    {ItemName.演员的自我修养,4},
                    {ItemName.洗冤录,3},
                    {ItemName.货殖列传,2},
                    {ItemName.木须柿子,2},
                    {ItemName.山海经,1 },
                    {ItemName.鬼谷子,1},
                 }
            },
            {
             Rarerity.UR,
                new Dictionary<ItemName, int>()
                {
                    {ItemName.演员的自我修养,5},
                    {ItemName.洗冤录,4},
                    {ItemName.货殖列传,3},
                    {ItemName.木须柿子,3},
                    {ItemName.山海经,2 },
                    {ItemName.鬼谷子,2},
                    {ItemName.仙人醉,1},
                    {ItemName.和氏璧,1}
                 }
            },
    };
    private static Dictionary<Rarerity, Dictionary<ItemName, int>> ChessplayerRarityItemRequestDict
    = new Dictionary<Rarerity, Dictionary<ItemName, int>>
    {
            {Rarerity.N,
                new Dictionary<ItemName, int>()
                {
                    {ItemName.拂尘,1}
                 }
            },
            {
             Rarerity.R,
                new Dictionary<ItemName, int>()
                {
                    {ItemName.拂尘,2},
                    {ItemName.毛笔,1}
                 }
            } ,
            {
             Rarerity.SR,
                new Dictionary<ItemName, int>()
                {
                    {ItemName.拂尘,3},
                    {ItemName.毛笔,2},
                    {ItemName.棋诀,1},
                    {ItemName.竹叶青,1}
                 }
            },
            {
             Rarerity.SSR,
                new Dictionary<ItemName, int>()
                {
                    {ItemName.拂尘,4},
                    {ItemName.毛笔,3},
                    {ItemName.棋诀,2},
                    {ItemName.竹叶青,2},
                    {ItemName.云纹袍,1 },
                    {ItemName.阴阳八卦盘,1},
                 }
            },
            {
             Rarerity.UR,
                new Dictionary<ItemName, int>()
                {
                    {ItemName.拂尘,5},
                    {ItemName.毛笔,4},
                    {ItemName.棋诀,3},
                    {ItemName.竹叶青,3},
                    {ItemName.云纹袍,2 },
                    {ItemName.阴阳八卦盘,2},
                    {ItemName.天机造化丹,1},
                    {ItemName.和氏璧,1}
                 }
            },
    };
    private static Dictionary<Rarerity, Dictionary<ItemName, int>> GovernorRarityItemRequestDict
    = new Dictionary<Rarerity, Dictionary<ItemName, int>>
    {
            {Rarerity.N,
                new Dictionary<ItemName, int>()
                {
                    {ItemName.文官状,1}
                 }
            },
            {
             Rarerity.R,
                new Dictionary<ItemName, int>()
                {
                    {ItemName.文官状,2},
                    {ItemName.毛笔,1}
                 }
            } ,
            {
             Rarerity.SR,
                new Dictionary<ItemName, int>()
                {
                    {ItemName.文官状,3},
                    {ItemName.毛笔,2},
                    {ItemName.金绿宝石,1},
                    {ItemName.货殖列传,1}
                 }
            },
            {
             Rarerity.SSR,
                new Dictionary<ItemName, int>()
                {
                    {ItemName.文官状,4},
                    {ItemName.毛笔,3},
                    {ItemName.金绿宝石,2},
                    {ItemName.货殖列传,2},
                    {ItemName.亮云白龙驹,1 },
                    {ItemName.朱户衣,1},
                 }
            },
            {
             Rarerity.UR,
                new Dictionary<ItemName, int>()
                {
                    {ItemName.文官状,5},
                    {ItemName.毛笔,4},
                    {ItemName.金绿宝石,3},
                    {ItemName.货殖列传,3},
                    {ItemName.亮云白龙驹,2 },
                    {ItemName.朱户衣,2},
                    {ItemName.龙马,1},
                    {ItemName.长生不老药,1}
                 }
            },
    };
    private static Dictionary<Rarerity, Dictionary<ItemName, int>> MonkRarityItemRequestDict
    = new Dictionary<Rarerity, Dictionary<ItemName, int>>
    {
            {Rarerity.N,
                new Dictionary<ItemName, int>()
                {
                    {ItemName.棍子,1}
                 }
            },
            {
             Rarerity.R,
                new Dictionary<ItemName, int>()
                {
                    {ItemName.棍子,2},
                    {ItemName.佛珠,1}
                 }
            } ,
            {
             Rarerity.SR,
                new Dictionary<ItemName, int>()
                {
                    {ItemName.棍子,3},
                    {ItemName.佛珠,2},
                    {ItemName.木须柿子,1},
                    {ItemName.清炒菜心,1}
                 }
            },
            {
             Rarerity.SSR,
                new Dictionary<ItemName, int>()
                {
                    {ItemName.棍子,4},
                    {ItemName.佛珠,3},
                    {ItemName.木须柿子,2},
                    {ItemName.清炒菜心,2},
                    {ItemName.佛手金卷,1 },
                    {ItemName.高汤白菜,1},
                 }
            },
            {
             Rarerity.UR,
                new Dictionary<ItemName, int>()
                {
                    {ItemName.棍子,5},
                    {ItemName.佛珠,4},
                    {ItemName.木须柿子,3},
                    {ItemName.清炒菜心,3},
                    {ItemName.佛手金卷,2 },
                    {ItemName.高汤白菜,2},
                    {ItemName.擎天枪,1},
                    {ItemName.和氏璧,1}
                 }
            },
    };
    private static Dictionary<Rarerity, Dictionary<ItemName, int>> LooterRarityItemRequestDict
= new Dictionary<Rarerity, Dictionary<ItemName, int>>
{
            {Rarerity.N,
                new Dictionary<ItemName, int>()
                {
                    {ItemName.零落的宝石,1}
                 }
            },
            {
             Rarerity.R,
                new Dictionary<ItemName, int>()
                {
                    {ItemName.零落的宝石,2},
                    {ItemName.缺口的宝石,1}
                 }
            } ,
            {
             Rarerity.SR,
                new Dictionary<ItemName, int>()
                {
                    {ItemName.零落的宝石,3},
                    {ItemName.缺口的宝石,2},
                    {ItemName.祖母绿,1},
                    {ItemName.红宝石,1}
                 }
            },
            {
             Rarerity.SSR,
                new Dictionary<ItemName, int>()
                {
                    {ItemName.零落的宝石,4},
                    {ItemName.缺口的宝石,3},
                    {ItemName.祖母绿,2},
                    {ItemName.红宝石,2},
                    {ItemName.鸽血红,1 },
                    {ItemName.木佐绿,1},
                 }
            },
            {
             Rarerity.UR,
                new Dictionary<ItemName, int>()
                {
                    {ItemName.零落的宝石,5},
                    {ItemName.缺口的宝石,4},
                    {ItemName.祖母绿,3},
                    {ItemName.红宝石,3},
                    {ItemName.鸽血红,2 },
                    {ItemName.木佐绿,2},
                    {ItemName.钻石,1},
                    {ItemName.和氏璧,1}
                 }
            },
};

    private static Dictionary<CharacterArtCode, Dictionary<Rarerity, Dictionary<ItemName, int>>> CharacterArtCodeToRarityItemRequestDict
        = new Dictionary<CharacterArtCode, Dictionary<Rarerity, Dictionary<ItemName, int>>>
        {
            {CharacterArtCode.女诗人, FemalePoestRarityItemRequestDict },
            {CharacterArtCode.男书生, MalePoetRarityItemRequestDict },
            {CharacterArtCode.男刀客, MaleBladeUserRarityItemRequestDict },
            {CharacterArtCode.老者, ElderlyRarityItemRequestDict },
            {CharacterArtCode.男官, MaleGovRarityItemRequestDict },
            {CharacterArtCode.男武, MaleFighterRarityItemRequestDict },
            {CharacterArtCode.女布衣, FemaleCivilianRarityItemRequestDict },
            {CharacterArtCode.传教士, MissionaryRarityItemRequestDict },
            {CharacterArtCode.琴师,MusicianRarityItemRequestDict },
            {CharacterArtCode.说书人, StorytellerRarityItemRequestDict },
            {CharacterArtCode.棋圣, ChessplayerRarityItemRequestDict },
            {CharacterArtCode.方丈, MonkRarityItemRequestDict },
            {CharacterArtCode.官员, GovernorRarityItemRequestDict },
            {CharacterArtCode.拾荒者, LooterRarityItemRequestDict },

        };

    public Character character;
    public Dictionary<ItemName, int> requestItems;
    public string FailedMessage;
    private void Awake()
    {

    }

    public void StartHiring()
    {
        if (character == null)
        {
            return;
        }
        StartCoroutine(HiringRator());
    }
    public void SetRequest()
    {
        Rarerity rarerity = Rarerity.N;
        foreach (Tag tag in character.tag)
        {
            if ((int)Player.AllTagRareDict[tag] > (int)rarerity)
            {
                rarerity = (Rarerity)Player.AllTagRareDict[tag];
            }
        }
        requestItems = CharacterArtCodeToRarityItemRequestDict[character.characterArtCode][rarerity];
    }
    public IEnumerator HiringRator()
    {
        var UIobject = Resources.Load<CharacterHiringUI>("Hiring/HireUI");
        var currentUI = Instantiate(UIobject, MainCanvas.FindMainCanvas());
        SetRequest();
        currentUI.Setup(character, requestItems);
        bool NeverFalse = true;
        while (NeverFalse)
        {
            if (currentUI == null)
            {
                NeverFalse = false;
                break;
            }
            if (currentUI.TryHire == true)
            {
                if (TryHiring() == true)
                {
                    break;
                }
                currentUI.TryHire = false;
                var sampleText = Resources.Load<Text>("Hiring/Message");
                var message = Instantiate<Text>(sampleText, MainCanvas.FindMainCanvas());
                message.text = FailedMessage;
            }
            yield return null;
        }
        if (currentUI != null)
        {
            Destroy(currentUI.gameObject);
        }
        Destroy(gameObject);
    }
    public bool TryHiring()
    {
        var itemInventory = FindObjectOfType<ItemInventory>();
        var itemDict = itemInventory.ItemDict;
        foreach (ItemName item in requestItems.Keys)
        {
            if (itemDict.ContainsKey(item) == false)
            {
                FailedMessage = "缺少招募道具";
                return false;
            }
            if (itemDict[item] < requestItems[item])
            {
                FailedMessage = "道具数量不足";
                return false;
            }
        }
        foreach (ItemName item in requestItems.Keys)
        {
            for (int i = 0; i < requestItems[item]; i++)
            {
                itemInventory.RemoveItem(item);
            }
        }
        character.hireStage = HireStage.Hired;
        character.transform.parent = GameObject.FindGameObjectWithTag("PlayerCharacterInventory").transform;
        return true;
    }
}
