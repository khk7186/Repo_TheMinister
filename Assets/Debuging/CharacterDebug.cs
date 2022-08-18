using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using System.Linq;

public class CharacterDebug : MonoBehaviour
{
    public Character character;
    private void Start()
    {
        Character character = GetComponent<Character>();
        StartCoroutine(DebugRator(character.tagList));
    }
    private IEnumerator DebugRator(List<Tag> tags)
    {
        yield return new WaitUntil(() => !Enumerable.SequenceEqual(tags, character.tagList));
        Debug.Log(String.Join(", ", character.tagList.ToArray()));
        StartCoroutine(DebugRator(character.tagList));
    }
}
