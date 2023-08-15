using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "GameDescriptionDatabase", menuName = "ScriptableObjects/SOGameDescription", order = 6)]
[Serializable]
public class SOGameDescription : ScriptableObject
{
    public List<DescriptionMenu> GameDescriptions;
}
[Serializable]
public struct DescriptionMenu
{
    public string name => Target;
    public string Target;
    public string Description;
    public List<string> MultiLangDescription;
}

