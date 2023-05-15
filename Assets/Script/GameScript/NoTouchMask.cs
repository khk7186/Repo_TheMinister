using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NoTouchMask : MonoBehaviour, IDiceRollEvent
{
    public Image mask;

    private void Start()
    {
        Dice.Instance.RegisterObserver(this);
        mask.enabled = false;
    }
    public void OnNotify(object value, NotificationType notificationType)
    {
        mask.enabled = true;
        StartCoroutine(WaitForPlayerStop());
    }
    public IEnumerator WaitForPlayerStop()
    {
        yield return new WaitForFixedUpdate();
        yield return new WaitUntil(() => Map.Instance.Player.GetComponent<CharacterMovement>().isMoving == false);
        mask.enabled = false;
    }
}
