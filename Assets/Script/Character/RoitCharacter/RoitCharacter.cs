using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoitCharacter : Character
{
    public static List<Tag> RoitTagsA = new List<Tag>() { Tag.习武之人 };
    public static List<Tag> badTagsA = new List<Tag>() { Tag.平平无奇 };
    public static List<Tag> RoitTagsB = new List<Tag>() { Tag.习武之人 };
    public static List<Tag> badTagsB = new List<Tag>() { Tag.平平无奇 };
    public static List<Tag> RoitTagsC = new List<Tag>() { Tag.习武之人 };
    public static List<Tag> badTagsC = new List<Tag>() { Tag.平平无奇 };
    public static List<Tag> RoitTagsD = new List<Tag>() { Tag.习武之人 };
    public static List<Tag> badTagsD = new List<Tag>() { Tag.平平无奇 };
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
                inGameAiString = "醉汉";
                break;
        }
        var cloneTarget = Resources.Load<RoitInGameAI>($"InGameNPC/RoitCharacter/{inGameAiString}");
        RoitInGameAI inGameAi = Instantiate(cloneTarget, spawnRange.transform);
        InGameAI = inGameAi;
        characterCard = Resources.Load<Character>("CharacterPrefab/Character").characterCard;
        inGameAi.SetupRoitAI(this, this.spawnRange);
        CharacterName = "无名";
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
            tagList.Add(RoitTags[Random.Range(0, RoitTags.Count)]);
        }
        for (int i = 0; i < (5 - level); i++)
        {
            tagList.Add(badTags[Random.Range(0, badTags.Count)]);
        }
    }
}
