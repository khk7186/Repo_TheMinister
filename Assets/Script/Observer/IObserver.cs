using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum NotificationType
{
    DiceRoll
}

public interface IObserver
{
    public abstract void OnNotify(object value, NotificationType notificationType);
}
