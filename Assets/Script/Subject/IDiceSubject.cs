using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDiceSubject
{
    public abstract void RegisterObserver(IDiceRollEvent observer);
    public abstract void CancelObserver(IDiceRollEvent observer);
    public abstract void Notify(object value, NotificationType notificationType);


}
