using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum NotificationType
{
    DiceRoll
}
public interface IDiceRollEvent
{
    public abstract void OnNotify(object value, NotificationType notificationType);
}
