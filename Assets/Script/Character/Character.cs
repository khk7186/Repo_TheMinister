using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.EventSystems;
public enum Tag
{
    Null,
    书痴,
    略有才名,
    小有谋略,
    武痴,
    身形矫健,
    老罴当道,
    文贞,
    武勇,
    干饭人,
    有勇无谋,
    花言巧语,
    绣花枕头,
    梧鼠五技,
    自是三公,
    敝帚自珍,
    双目失明,
    独臂,
    痴呆,
    身怀六甲,
    不孕不育,
    巨人症,
    侏儒症,
    小儿麻痹,
    目不识丁,
    儒生,
    道士,
    僧人,
    讼棍,
    冷血无情,
    蛤蟆功,
    近视,
    嗜甜如命,
    营养不良,
    夜不能寐,
    阉人,
    吸血鬼,
    膝盖僵硬,
    通晓天文,
    多动症,
    不孝子,
    冰霜宝剑,
    狼人,
    巫妖领主,
    飞毛腿,
    火炮,
    龙骑士,
    能歌善舞,
    东洋语,
    平平无奇,
    雕,
    腿脚不便,
    年老体衰,
    习武之人,
    状元,
    诗仙,
    卧龙,
    西洋语,
    武圣,
    无影,
    磐石,
    大人时代变了,
    弈星下凡,
    文,
    武,
    书通二酉,
    才华横溢,
    工于心计,
    力拔山兮,
    广厦之荫,
    智勇双全,
    偃师,
    奇门遁甲,
    天生神力,
    阳明学派,
    吸星大法,
    成道,
    外交官,
    老当益壮,
    出没无常,
    八斗之才,
    诸武精通,
    文武双全,
    纸上谈兵,
    徒有虚名,
    投机取巧,
    混世魔王,
    心狠手辣,
    法外狂徒,
    糖尿病,
    恶魔人,
    欢喜佛,
    黯然销魂掌,
    围棋十段,
    文正,
    武忠
}
public enum Raitity
{
    Null, 
    VB, 
    B, 
    N = 30, 
    R = 50, 
    SR = 70, 
    SSR = 90, 
    UR = 110
}

public enum CharacterArtCode
{
    女诗人,
    男刀客,
    老者,
    男书生
}

public enum HireStage
{
    Never,
    First,
    Second,
    Third,
    Hired
}
public class Character : MonoBehaviour, IRound
{
    #region ID
    [Header("Character Infomation")]
    public int ID;
    public string CharacterName;
    #endregion

    #region Max
    [SerializeField] private int loyaltyMax = 10;
    [SerializeField] private int healthMax = 10;
    [SerializeField] private int tagMax = 5;

    [SerializeField] private List<int> TagSpawnRareRate = new List<int>(5) { 46, 33, 20, 1, 0 };
    #endregion

    #region Variable
    public CharacterArtCode characterArtCode;
    public int loyalty = 10;
    public int health = 10;

    public CharacterUI characterCard;
    private CharacterUI thisCharacterCard;
    public Transform characterCardInvUI;

    

    [Header("Base Variables")]

    public Dictionary<CharacterValueType, int> characterValueDict =
        new Dictionary<CharacterValueType, int>
        {
            {CharacterValueType.智, 10 },
            {CharacterValueType.才, 10 },
            {CharacterValueType.谋, 10 },
            {CharacterValueType.武, 10 },
            {CharacterValueType.刺, 10 },
            {CharacterValueType.守, 10 },
        };
    public Dictionary<CharacterValueType, Raitity> characterValueRareDict =
        new Dictionary<CharacterValueType, Raitity>
        {
            {CharacterValueType.智, Raitity.Null },
            {CharacterValueType.才, Raitity.Null },
            {CharacterValueType.谋, Raitity.Null },
            {CharacterValueType.武, Raitity.Null },
            {CharacterValueType.刺, Raitity.Null },
            {CharacterValueType.守, Raitity.Null },
        };

    public List<Tag> tagList = new List<Tag>();

    public int ReturnRounds = 0;


    #endregion

    #region View
    public HireStage hireStage;
    #endregion
    private void Awake()
    {
        SpawnTagOnStart();
        UpdateVariables();
        
    }

    private void Start()
    {
        if (hireStage == HireStage.Hired) CreatUI();

    }

    private bool CheckForAway()
    {
        if (ReturnRounds > 0) return true;
        return false;
    }

    public void UpdateVariables()
    {
        ResetVariables();
        foreach (Tag tag in tagList)
        {
            var varlist = Player.TagInfDict[tag];
            characterValueDict[CharacterValueType.智] += varlist[0];
            characterValueDict[CharacterValueType.才] += varlist[1];
            characterValueDict[CharacterValueType.谋] += varlist[2];
            characterValueDict[CharacterValueType.武] += varlist[3];
            characterValueDict[CharacterValueType.刺] += varlist[4];
            characterValueDict[CharacterValueType.守] += varlist[5];
        }

        foreach (CharacterValueType key in Enum.GetValues(typeof(CharacterValueType)))
        {
            characterValueRareDict[key] = CheckVariablesRare(characterValueDict[key]);
            //Debug.Log(key.ToString() + characterValueRareDict[key].ToString());
        }
    }

    private Raitity CheckVariablesRare(int input)
    {
        if (input > (int)Raitity.UR) return Raitity.UR;
        else if (input > (int)Raitity.SSR) return Raitity.SSR;
        else if (input > (int)Raitity.SR) return Raitity.SR;
        else if (input > (int)Raitity.R) return Raitity.R;
        else if (input > (int)Raitity.N) return Raitity.N;
        else return Raitity.Null;
    }

    private void ResetVariables()
    {
        characterValueDict[CharacterValueType.智] = 10;
        characterValueDict[CharacterValueType.才] = 10;
        characterValueDict[CharacterValueType.谋] = 10;
        characterValueDict[CharacterValueType.武] = 10;
        characterValueDict[CharacterValueType.刺] = 10;
        characterValueDict[CharacterValueType.守] = 10;
    }

    private void SpawnTagOnStart()
    {
        int tagAmount = UnityEngine.Random.Range(1, 5);
        for (int i = 0; i < 5; i++)
        {
            tagList.Add(RandomTag());
        }
    }

    private void SpawnTag(Tag tag)
    {
        if (tagList.Count >= 5)
        {
            //TODO: Open new UI and choose a exist tag to remove before add new one.
        }
        else tagList.Add(tag);
    }

    private void RemoveTag(Tag tag)
    {
        tagList.Remove(tag);
    }

    private Tag RandomTag()
    {
        Raitity rare = RandomRare();
        var dict = Player.GivenableTagRareDict;
        dict.TryGetValue(rare, out List<Tag> targetList);
        int targetValue = UnityEngine.Random.Range(0, targetList.Count - 1);
        return targetList[targetValue];
    }

    private Tag RandomTag(Raitity rare)
    {
        List<Tag> targetList = Player.GivenableTagRareDict[rare];
        int targetValue = UnityEngine.Random.Range(0, targetList.Count - 1);
        return targetList[targetValue];
    }

    private Raitity RandomRare()
    {
        int rare = UnityEngine.Random.Range(1, 100);
        if (rare < TagSpawnRareRate[0])
        {
            return Raitity.N;
        }
        else if (rare < (TagSpawnRareRate[0] + TagSpawnRareRate[1]))
        {
            return Raitity.R;
        }
        else if (rare < (TagSpawnRareRate[0] + TagSpawnRareRate[1] + TagSpawnRareRate[2]))
        {
            return Raitity.SR;
        }
        else if (rare < (TagSpawnRareRate[0] + TagSpawnRareRate[1] + TagSpawnRareRate[2] + TagSpawnRareRate[3]))
        {
            return Raitity.SSR;
        }
        else if (rare < (TagSpawnRareRate[0] + TagSpawnRareRate[1] + TagSpawnRareRate[2] + TagSpawnRareRate[3] + TagSpawnRareRate[4]))
        {
            return Raitity.UR;
        }
        else return Raitity.Null;
    }

    private void CreatUI()
    {
        thisCharacterCard = Instantiate(characterCard, characterCardInvUI);
        thisCharacterCard.character = this;
        thisCharacterCard.UpdateUI();
    }

    public void RoundPass()
    {
        ReturnRounds -= 1;
        if (ReturnRounds <= 0)
        {
            ReturnToHand();
        }
    }

    public void Away()
    {
        Destroy(thisCharacterCard);
    }

    public void ReturnToHand()
    {
        CreatUI();
    }

    public void Destroy()
    {
        Destroy(thisCharacterCard);
        Destroy(gameObject);
    }


}
