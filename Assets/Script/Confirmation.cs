using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum ConfirmPhase
{
    False,
    True,
    Null
}
public class Confirmation
{
    public string CurrentText;
    public ConfirmUI uiPrefab;
    public ConfirmUI currentUI;
    public delegate void HoldingMethod();
    private HoldingMethod holdingMethod;

    private ConfirmPhase confirm= ConfirmPhase.Null;

    public Confirmation()
    {
        uiPrefab = Resources.Load<ConfirmUI>("BuildingUI/ConfirmWindow");
        Transform canvas = MainCanvas.FindMainCanvas();
        currentUI = Object.Instantiate(uiPrefab, canvas);
        currentUI.confirm.onClick.AddListener(SetConfirmTrue);
        currentUI.cancel.onClick.AddListener(SetConfirmFalse);
    }

    public static Confirmation CreateNewComfirmation( HoldingMethod holding,string input)
    {
        var output = new Confirmation();
        output.currentUI.SetUp(input);
        output.holdingMethod = holding;
        return output;
    }

    private void SetConfirmTrue()
    {
        confirm = ConfirmPhase.True;
    }

    private void SetConfirmFalse()
    {
        confirm = ConfirmPhase.False;
    }

    public IEnumerator Confirm()
    {
        while (confirm == ConfirmPhase.Null)
        {
            yield return null;
        }
        if (confirm == ConfirmPhase.False)
        {
            confirm = ConfirmPhase.Null;
        }
        else if (confirm == ConfirmPhase.True)
        {
            holdingMethod();
        }
    }


}
