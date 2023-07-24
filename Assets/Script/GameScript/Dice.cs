using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Dice : MonoBehaviour, IDiceSubject
{
    // Array of dice sides sprites to load from Resources folder
    [SerializeField] private Sprite[] diceSides;

    [SerializeField] private Image dice1;
    [SerializeField] private Image dice2;
    public List<IDiceRollEvent> Observers;
    [SerializeField] private int RollTime = 5;
    public bool isFake = false;

    public bool rolling = false;
    public static Dice Instance;

    // Use this for initialization
    private void Awake()
    {
        if (Observers == null)
            Observers = new List<IDiceRollEvent>();
    }
    private void OnEnable()
    {
        if (isFake) return;
        rolling = false;
        if (Instance == null)
        {
            Instance = this;
        }
        SceneManager.sceneLoaded += OnSceneChange;
        DontDestroyOnLoad(gameObject);
    }
    private void OnDisable()
    {
        if (isFake) return;
        SceneManager.sceneLoaded -= OnSceneChange;
    }

    private void OnSceneChange(Scene arg0, LoadSceneMode arg1)
    {
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            var allObservers = FindObjectsOfType<MonoBehaviour>().OfType<IDiceRollEvent>();
            foreach (var observer in allObservers)
            {
                RegisterObserver(observer);
            }
        }
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
        rolling = false;
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
        for (int i = 0; i <= RollTime; i++)
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

    public void RegisterObserver(IDiceRollEvent observer)
    {
        if (Observers == null)
            Observers = new List<IDiceRollEvent>();
        if (!Observers.Contains(observer))
            Observers.Add(observer);
    }

    public void Notify(object value, NotificationType notificationType)
    {
        Observers.RemoveAll(item => (MonoBehaviour)item == null);
        string AllgoName = "";
        int index = 0;
        foreach (var observer in Observers.ToList())
        {
            index++;
            MonoBehaviour go = observer as MonoBehaviour;
            if (go != null)
                AllgoName += $"{index}. {go.name}\n";
        }
        foreach (var observer in Observers.ToList())
        {
            if (observer != null)
            {
                observer.OnNotify(value, notificationType);
            }
        }
    }
    public void CancelObserver(IDiceRollEvent observer)
    {
        if (Observers.Contains(observer))
            Observers.Remove(observer);
    }
}
