using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoitCharacter : Character
{
    public static List<Tag> RoitTagsA = new List<Tag>() {Tag.法外狂徒,
                                                         Tag.冷血无情,
                                                         Tag.火炮,
                                                         Tag.恶魔人,
                                                         Tag.箭无虚发,
                                                         Tag.一点寒芒,
                                                         Tag.武艺精湛,
                                                         Tag.护心,
                                                         Tag.皮甲,
                                                         Tag.铁甲,
                                                         Tag.武功小成,
                                                         Tag.文化沙漠,
                                                         Tag.如醉如狂,
                                                         Tag.气功达人,
                                                         Tag.天生神力,
                                                         Tag.出没无常,
                                                         Tag.象虎之力,
                                                         Tag.嘤嘤狂吠,
                                                         Tag.心狠手辣,
                                                         Tag.混世魔王,
                                                         Tag.驯兽大师};

    public static List<Tag> badTagsA = new List<Tag>() { Tag.平平无奇,
                                                        Tag.绣花枕头,
                                                        Tag.磕巴,
                                                        Tag.杂七杂八,
                                                        Tag.无用之人,
                                                        Tag.毛发旺盛,
                                                        Tag.欢喜佛,
                                                        Tag.东洋语,
                                                        Tag.心算,
                                                        Tag.花言巧语,
                                                        Tag.绣花枕头,
                                                        Tag.故事王 };
    public static List<Tag> RoitTagsB = new List<Tag>() { Tag.武痴,
                                                        Tag.身形矫健,
                                                        Tag.老罴当道,
                                                        Tag.毒师,
                                                        Tag.驯兽术,
                                                        Tag.根骨清奇,
                                                        Tag.登堂入室,
                                                        Tag.吸血鬼,
                                                        Tag.狼人,
                                                        Tag.习武之人 };

    public static List<Tag> badTagsB = new List<Tag>() { Tag.膝盖僵硬,
                                                        Tag.匠人,
                                                        Tag.营养不良,
                                                        Tag.夜不能寐,
                                                        Tag.独臂,
                                                        Tag.小儿麻痹,
                                                        Tag.得寸进尺,
                                                        Tag.干呕,
                                                        Tag.身体孱弱 };

    public static List<Tag> RoitTagsC = new List<Tag>() { Tag.飞毛腿,
                                                        Tag.外乡人,
                                                        Tag.牧民,
                                                        Tag.买瓜人,
                                                        Tag.五味杂陈,
                                                        Tag.好酒之人,
                                                        Tag.巨人症,
                                                        Tag.琴师 };

    public static List<Tag> badTagsC = new List<Tag>() { Tag.多动症,
                                                        Tag.调皮鬼,
                                                        Tag.衣不蔽体,
                                                        Tag.自是三公,
                                                        Tag.丹童,
                                                        Tag.敝帚自珍,
                                                        Tag.医术 };

    public static List<Tag> RoitTagsD = new List<Tag>() {Tag.戟,
                                                        Tag.刀,
                                                        Tag.枪,
                                                        Tag.剑,
                                                        Tag.弓,
                                                        Tag.有勇无谋,
                                                        Tag.巨人症,
                                                        Tag.梧鼠五技 };

    public static List<Tag> badTagsD = new List<Tag>() { Tag.肥胖症,
                                                        Tag.长短腿,
                                                        Tag.义肢,
                                                        Tag.药毒,
                                                        Tag.年老体衰,
                                                        Tag.腿脚不便,
                                                        Tag.醉酒,
                                                        Tag.近视};
    public char Area = 'A';
    public List<Tag> RoitTags => Area == 'A' ? RoitTagsA : Area == 'B' ? RoitTagsB : Area == 'C' ? RoitTagsC : RoitTagsD;
    public List<Tag> badTags => Area == 'A' ? badTagsA : Area == 'B' ? badTagsB : Area == 'C' ? badTagsC : badTagsD;
    public static CharacterArtCode characterArtCodeA = CharacterArtCode.男武;
    public static CharacterArtCode characterArtCodeB = CharacterArtCode.男刀客;
    public static CharacterArtCode characterArtCodeC = CharacterArtCode.拾荒者;
    public static CharacterArtCode characterArtCodeD = CharacterArtCode.男官;
    public CharacterArtCode RoitCharacterArtCode => Area == 'A' ? characterArtCodeA : Area == 'B' ? characterArtCodeB : Area == 'C' ? characterArtCodeC : characterArtCodeD;
    public RoitInGameAI RoitAITemp;
    public RoitSpawnRange spawnRange;
    public override void AwakeAction()
    {
        characterType = CharacterType.Roit;
        hireStage = HireStage.InCity;
    }
    public override void StartAction()
    {
        StartCoroutine(RemoveFromGame());
    }
    public void Setup(RoitSpawnRange spawnRange)
    {
        this.Area = spawnRange.Area;
        this.spawnRange = spawnRange;
        characterArtCode = RoitCharacterArtCode;
        SpawnTagOnStart(RoitManager.Instance.Difficulty);
        string inGameAiString = "";
        switch (Area)
        {
            case 'A':
                inGameAiString = "街霸";
                break;
            case 'B':
                inGameAiString = "强盗";
                break;
            case 'C':
                inGameAiString = "逃难者";
                break;
            case 'D':
                inGameAiString = "醉鬼";
                break;
        }
        var cloneTarget = Resources.Load<RoitInGameAI>($"InGameNPC/RoitCharacter/{inGameAiString}");
        RoitInGameAI inGameAi = Instantiate(cloneTarget, spawnRange.transform);
        InGameAI = inGameAi;
        characterCard = Resources.Load<Character>("CharacterPrefab/Character").characterCard;
        inGameAi.SetupRoitAI(this, this.spawnRange);
        CharacterName = "无名";
    }
    protected IEnumerator RemoveFromGame()
    {
        Func<bool> defeated = () => hireStage == HireStage.Defeated;
        yield return new WaitUntil(defeated);
        int day = Map.Instance.Day;
        Func<bool> after2Days = () => (Map.Instance.Day - day >= 2);
        yield return new WaitUntil(after2Days);
        if (hireStage != HireStage.Hired)
        {
            Destroy(InGameAI.gameObject.gameObject);
            Destroy(gameObject);
        }
    }
    protected override void SpawnTagOnStart(Rarerity rarerity = Rarerity.Null)
    {
        int level = 0;
        switch (rarerity)
        {
            case Rarerity.N:
                level = 1;
                break;
            case Rarerity.R:
                level = 2;
                break;
            case Rarerity.SR:
                level = 3;
                break;
            case Rarerity.SSR:
                level = 4;
                break;
            case Rarerity.UR:
                level = 5;
                break;
            default:
                break;

        }
        for (int i = 0; i < level; i++)
        {
            tagList.Add(RoitTags[UnityEngine.Random.Range(0, RoitTags.Count)]);
        }
        for (int i = 0; i < (5 - level); i++)
        {
            tagList.Add(badTags[UnityEngine.Random.Range(0, badTags.Count)]);
        }
    }
}
