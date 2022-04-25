using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCharacter : Character
{
    public List<Tag> tagList = new List<Tag>() { };
    public HireStage hireStage = HireStage.Hired;
}
