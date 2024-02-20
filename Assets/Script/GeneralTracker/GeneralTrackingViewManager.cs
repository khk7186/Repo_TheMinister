using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GeneralTrackingViewManager : MonoBehaviour, IPointerExitHandler
{
    public static GeneralTrackingViewManager Instance;
    public List<GeneralTrackingView> trackingViews = new List<GeneralTrackingView>();
    public Transform viewHolder = null;
    public GeneralTrackingView trackingView = null;
    private void Start()
    {
        Reset();
    }
    public GeneralTrackingView PushTracker(Character character, string trackerName, string message, int turnLeft, bool auto)
    {
        foreach (GeneralTrackingView view in trackingViews)
        {
            if (view.trackerName == trackerName)
            {
                if (message == "destroy" && view.NoAction)
                {
                    trackingViews.Remove(view);
                    view.Hide();
                    return null;
                }
                view.Setup(trackerName, message, turnLeft);
                return view;
            }
        }
        var clone = Instantiate(trackingView, viewHolder);
        clone.Manager = this;
        clone.OnSpawn(character, auto);
        clone.Setup(trackerName, message, turnLeft);
        trackingViews.Add(clone);
        return clone;
    }
    public void PopUpTracker(GeneralTrackingView focusView)
    {
        foreach (var view in trackingViews)
        {
            if (view == focusView)
            {
                view.sizeAnimator.Play("SizeUp");
            }
        }
        MoveViews(focusView);
    }
    public void PopOffTracker(GeneralTrackingView focusView)
    {
        foreach (var view in trackingViews)
        {
            if (view == focusView)
            {
                view.sizeAnimator.Play("SizeUpReturn");
            }
        }
    }
    public void MoveViews(GeneralTrackingView focusView)
    {
        float compareValue = focusView.transform.position.y;
        foreach (var view in trackingViews)
        {
            if (view == focusView)
            {
                if (view.isUp) view.moveAnimator.Play("TrackerUpReturn");
                else if (view.isDown) view.moveAnimator.Play("TrackerDownReturn");
                view.isDown = false;
                view.isUp = false;
            }
            else if (view.transform.position.y > compareValue)
            {
                if (view.isDown == false)
                {
                    view.moveAnimator.Play("TrackerUp");
                }
                else
                {
                    if (view.isDown) view.moveAnimator.Play("TrackerDownUp");
                    else continue;
                }
                view.isUp = true;
                view.isDown = false;
            }
            else
            {
                if (view.isUp == false)
                {
                    view.moveAnimator.Play("TrackerDown");
                }
                else
                {
                    if (view.isUp) view.moveAnimator.Play("TrackerUpDown");
                    else continue;
                }
                view.isUp = false;
                view.isDown = true;
            }
        }
    }
    public void MoveReturns()
    {
        foreach (var view in trackingViews)
        {
            if (view.isUp) view.moveAnimator.Play("TrackerUpReturn");
            else if (view.isDown) view.moveAnimator.Play("TrackerDownReturn");
            view.isDown = false;
            view.isUp = false;
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        MoveReturns();
    }
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }
    public void Reset()
    {
        foreach (var view in trackingViews)
        {
            Destroy(view.gameObject);
        }
        trackingViews.Clear();
    }
}
