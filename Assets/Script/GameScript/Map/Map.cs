using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Map : MonoBehaviour, IObserver
{
    private List<Block> map = new List<Block>();
    [SerializeField] private int currentBlock = 0;
    [SerializeField] private Transform Player;
    [SerializeField] private float delayPerMove = 1f;

    public Transform currentTransform => (map.Count > 0) ? map[currentBlock].transform : null;

    private void Awake()
    {
        map = GetComponentsInChildren<Block>().ToList();
        FindObjectOfType<Dice>().RegisterObserver(this);
    }
    private void Start()
    {
        Player.position = map[0].transform.position;
    }
    public void OnNotify(object value, NotificationType notificationType)
    {
        if (notificationType == NotificationType.MovePlayer)
        {
            StartCoroutine(MoveAndDelay((int)value));
        }
        
    }

    private void MoveAStep()
    {
        currentBlock += 1;
        Player.position = map[currentBlock].transform.position;
    }

    private IEnumerator MoveAndDelay(int steps)
    {
        
        for (int i = 0; i < steps; i++)
        {
            MoveAStep();
            yield return new WaitForSeconds(delayPerMove);
        }
        
    }

    
}
