using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoitCharacter : Character
{
    public static List<Tag> RoitTagsA = new List<Tag>();
    public static List<Tag> badTagsA = new List<Tag>();
    public static List<Tag> RoitTagsB = new List<Tag>();
    public static List<Tag> badTagsB = new List<Tag>();
    public static List<Tag> RoitTagsC = new List<Tag>();
    public static List<Tag> badTagsC = new List<Tag>();
    public static List<Tag> RoitTagsD = new List<Tag>();
    public static List<Tag> badTagsD = new List<Tag>();
    public char Area = 'A';
    public List<Tag> RoitTags => Area == 'A' ? RoitTagsA : Area == 'B' ? RoitTagsB : Area == 'C' ? RoitTagsC : RoitTagsD;
    public List<Tag> badTags => Area == 'A' ? badTagsA : Area == 'B' ? badTagsB : Area == 'C' ? badTagsC : badTagsD;
    public static CharacterArtCode characterArtCodeA = CharacterArtCode.ÄÐÎä;
    public static CharacterArtCode characterArtCodeB = CharacterArtCode.ÄÐµ¶¿Í;
    public static CharacterArtCode characterArtCodeC = CharacterArtCode.Ê°»ÄÕß;
    public static CharacterArtCode characterArtCodeD = CharacterArtCode.ÄÐ¹Ù;
    public CharacterArtCode RoitCharacterArtCode => Area == 'A' ? characterArtCodeA : Area == 'B' ? characterArtCodeB : Area == 'C' ? characterArtCodeC : characterArtCodeD;
    public override void AwakeAction()
    {
        characterType = CharacterType.Roit;
        
    }
    public override void StartAction()
    {
    }
    public void Setup(char Area)
    {
        this.Area = Area;
        characterArtCode = RoitCharacterArtCode;
        SpawnTagOnStart();
        
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
