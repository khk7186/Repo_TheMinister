using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISubject
{
    public abstract void RegisterObserver(IObserver observer);
    public abstract void Notify(object value, NotificationType notificationType);


}
