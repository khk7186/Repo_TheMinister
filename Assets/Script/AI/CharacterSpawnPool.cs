using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CharacterSpawnPool : MonoBehaviour
{
    public static Dictionary<BattleType, List<Character>> FemalePoestDict
        = new Dictionary<BattleType, List<Character>>()
        {
            { BattleType.Combat,
                new List<Character>() { }
            }
            ,
            { BattleType.Debate,
                new List<Character>() { }
            }
        };
    public static Dictionary<BattleType, List<Character>> MalePoetDict
        = new Dictionary<BattleType, List<Character>>()
        {
            { BattleType.Combat,
                new List<Character>() { }
            }
            ,
            { BattleType.Debate,
                new List<Character>() { }
            }
        };
    public static Dictionary<BattleType, List<Character>> MaleBladeUserDict
        = new Dictionary<BattleType, List<Character>>()
        {
                { BattleType.Combat,
                    new List<Character>() { }
                }
                ,
                { BattleType.Debate,
                    new List<Character>() { }
                }
        };
    public static Dictionary<BattleType, List<Character>> ElderlyDict
        = new Dictionary<BattleType, List<Character>>()
        {
                    { BattleType.Combat,
                        new List<Character>() { }
                    }
                    ,
                    { BattleType.Debate,
                        new List<Character>() { }
                    }
        };
    public static Dictionary<BattleType, List<Character>> MaleFighterDict
        = new Dictionary<BattleType, List<Character>>()
        {
                    { BattleType.Combat,
                        new List<Character>() { }
                    }
                    ,
                    { BattleType.Debate,
                        new List<Character>() { }
                    }
        };
    public static Dictionary<BattleType, List<Character>> MaleGovDict
        = new Dictionary<BattleType, List<Character>>()
        {
                    { BattleType.Combat,
                        new List<Character>() { }
                    }
                    ,
                    { BattleType.Debate,
                        new List<Character>() { }
                    }
        };
    public static Dictionary<BattleType, List<Character>> FemaleCivilianDict
        = new Dictionary<BattleType, List<Character>>()
        {
                    { BattleType.Combat,
                        new List<Character>() { }
                    }
                    ,
                    { BattleType.Debate,
                        new List<Character>() { }
                    }
        };
    public static Dictionary<BattleType, List<Character>> MissionaryDict
        = new Dictionary<BattleType, List<Character>>()
        {
                    { BattleType.Combat,
                        new List<Character>() { }
                    }
                    ,
                    { BattleType.Debate,
                        new List<Character>() { }
                    }
        };
    public static Dictionary<BattleType, List<Character>> MucisianDict
        = new Dictionary<BattleType, List<Character>>()
        {
                    { BattleType.Combat,
                        new List<Character>() { }
                    }
                    ,
                    { BattleType.Debate,
                        new List<Character>() { }
                    }
        };
    public static Dictionary<BattleType, List<Character>> StorytellerDict
        = new Dictionary<BattleType, List<Character>>()
        {
                    { BattleType.Combat,
                        new List<Character>() { }
                    }
                    ,
                    { BattleType.Debate,
                        new List<Character>() { }
                    }
        };
    public static Dictionary<BattleType, List<Character>> ChessplayerDict
        = new Dictionary<BattleType, List<Character>>()
        {
                    { BattleType.Combat,
                        new List<Character>() { }
                    }
                    ,
                    { BattleType.Debate,
                        new List<Character>() { }
                    }
        };
    public static Dictionary<BattleType, List<Character>> MonkDict
    = new Dictionary<BattleType, List<Character>>()
    {
                    { BattleType.Combat,
                        new List<Character>() { }
                    }
                    ,
                    { BattleType.Debate,
                        new List<Character>() { }
                    }
    };
    public static Dictionary<BattleType, List<Character>> GovernorDict
        = new Dictionary<BattleType, List<Character>>()
        {
                    { BattleType.Combat,
                        new List<Character>() { }
                    }
                    ,
                    { BattleType.Debate,
                        new List<Character>() { }
                    }
        };
    public static Dictionary<BattleType, List<Character>> ScavengerDict
        = new Dictionary<BattleType, List<Character>>()
        {
                    { BattleType.Combat,
                        new List<Character>() { }
                    }
                    ,
                    { BattleType.Debate,
                        new List<Character>() { }
                    }
        };
    public static Dictionary<BattleType, List<Character>> EunuchDict
        = new Dictionary<BattleType, List<Character>>()
        {
                    { BattleType.Combat,
                        new List<Character>(){ }
                    }
                    ,
                    {BattleType.Debate,
                        new List<Character>(){ }
                    }
        };
    public static Dictionary<CharacterArtCode, Dictionary<BattleType, List<Character>>> CharacterSpawnPoolDict
        = new Dictionary<CharacterArtCode, Dictionary<BattleType, List<Character>>>()
        {
            {CharacterArtCode.女诗人, FemalePoestDict },
            {CharacterArtCode.男书生, MalePoetDict},
            {CharacterArtCode.男刀客, MaleBladeUserDict },
            {CharacterArtCode.老者, ElderlyDict },
            {CharacterArtCode.男官, MaleGovDict },
            {CharacterArtCode.男武, MaleFighterDict },
            {CharacterArtCode.女布衣, FemaleCivilianDict },
            {CharacterArtCode.传教士, MissionaryDict},
            {CharacterArtCode.琴师, MucisianDict },
            {CharacterArtCode.说书人, StorytellerDict },
            {CharacterArtCode.棋圣, ChessplayerDict },
            {CharacterArtCode.方丈, MonkDict },
            {CharacterArtCode.官员, GovernorDict },
            {CharacterArtCode.拾荒者, ScavengerDict },
            {CharacterArtCode.太监, EunuchDict }
        };
    public void RotateAllCharacters()
    {
        foreach (CharacterArtCode characterArtCode in Enum.GetValues(typeof(CharacterArtCode)))
        {
            if (characterArtCode == CharacterArtCode.李袁陌) continue;
            RotateCharacters(characterArtCode);
        }
    }
    public void RotateCharacters(CharacterArtCode characterArtCode)
    {
        List<Character> newCombatList = new List<Character>();
        for (int i = 0; i < 2; i++)
        {
            var newCharacter = new GameObject().AddComponent<Character>();
            Rarerity[] rarerities = new Rarerity[] { Rarerity.N, Rarerity.R, Rarerity.SR };
            int index = UnityEngine.Random.Range(0, rarerities.Length);
            newCharacter.rarerity = rarerities[index];
            newCharacter.hireStage = HireStage.NotInMap;
            newCharacter.transform.parent = this.transform;
            newCombatList.Add(newCharacter);
        }
        try
        {
            CharacterSpawnPoolDict[characterArtCode][BattleType.Combat] = newCombatList;
        }
        catch (KeyNotFoundException)
        {
            Debug.LogError($"{characterArtCode} not found in CharacterSpawnPoolDict");
        }
        int numberOfDebate = UnityEngine.Random.Range(3, 8);
        var newDebateList = new List<Character>();
        for (int i = 0; i < numberOfDebate; i++)
        {
            var newCharacter = new GameObject().AddComponent<Character>();
            Rarerity[] rarerities = new Rarerity[] { Rarerity.N, Rarerity.R, Rarerity.SR };
            int index = UnityEngine.Random.Range(0, rarerities.Length);
            newCharacter.rarerity = rarerities[index];
            newCharacter.hireStage = HireStage.NotInMap;
            newCharacter.transform.parent = this.transform;            
            newDebateList.Add(newCharacter);
        }
        CharacterSpawnPoolDict[characterArtCode][BattleType.Debate]
            = newDebateList;
    }
}