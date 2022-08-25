using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Dice : MonoBehaviour, ISubject
{
    // Array of dice sides sprites to load from Resources folder
    [SerializeField] private Sprite[] diceSides;

    [SerializeField] private Image dice1;
    [SerializeField] private Image dice2;
    private List<IObserver> Observers = new List<IObserver>();

    public bool rolling = false;

    // Use this for initialization
    private void OnEnable()
    {
        rolling = false;
    }
    public void Roll()
    {
        if (!rolling)
        {
            StartCoroutine(RollTheDice());
        }
    }
    public void FakeRoll33()
    {
        FakeRoll(new Vector2(3, 3));
    }
    public void FakeRoll(Vector2 final)
    {
        if (!rolling)
        {
            StartCoroutine(RollTheDice(final));
        }
    }
    private IEnumerator RollTheDice(object final = null)
    {
        rolling = true;
        // Variable to contain random dice side number.
        // It needs to be assigned. Let it be 0 initially
        int randomDiceSide1 = 0;
        int randomDiceSide2 = 0;

        // Final side or value that dice reads in the end of coroutine
        int finalSide1 = 0;
        int finalSide2 = 0;

        // Loop to switch dice sides ramdomly
        // before final side appears. 20 itterations here.
        for (int i = 0; i <= 20; i++)
        {
            // Pick up random value from 0 to 5 (All inclusive)
            randomDiceSide1 = Random.Range(0, 5);

            // Set first dice's sprite to upper face of dice from array according to random value
            dice1.sprite = diceSides[randomDiceSide1];

            // Set second random for second dice
            randomDiceSide2 = Random.Range(0, 5);

            // Set Second dice image
            dice2.sprite = diceSides[randomDiceSide2];

            // Pause before next itteration
            yield return new WaitForSeconds(0.05f);
        }

        if (final != null)
        {
            var finalVecter = (Vector2)final;
            finalSide1 = (int)finalVecter.x;
            finalSide2 = (int)finalVecter.y;
            dice1.sprite = diceSides[finalSide1 - 1];
            dice2.sprite = diceSides[finalSide2 - 1];
        }
        else
        {
            finalSide1 = randomDiceSide1 + 1;
            finalSide2 = randomDiceSide2 + 1;

        }
        int totalCount = finalSide1 + finalSide2;
        // Assigning final side so you can use this value later in your game
        // for player movement for example


        // Show final dice value in Console
        // Notify Observers
        Notify(totalCount, NotificationType.DiceRoll);
        if (final != null) transform.parent.gameObject.SetActive(false);
    }

    public void RegisterObserver(IObserver observer)
    {
        Observers.Add(observer);
    }

    public void Notify(object value, NotificationType notificationType)
    {
        if (notificationType == NotificationType.DiceRoll)
        {
            foreach (var observer in Observers.ToList())
            {
                observer.OnNotify(value, notificationType);
            }
        }
    }

    public void CancelObserver(IObserver observer)
    {
        Observers.Remove(observer);
    }
}
