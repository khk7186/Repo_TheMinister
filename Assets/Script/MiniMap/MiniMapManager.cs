using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMapManager : MonoBehaviour
{
    public static MiniMapManager Instance;
    public RectTransform[] blocks;
    public int currentBlock;
    public int nextBlock
    {
        get
        {
            var next = currentBlock + 1;
            if (next < blocks.Length)
            {
                return next;
            }
            else
                return 0;
        }
    }
    public float speed;
    Player FindPlayer => FindObjectOfType<Player>();
    public RectTransform playerRect;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(Instance.gameObject);
            Instance = this;
        }
    }
    private void Start()
    {
        speed = CharacterMovement.playerSpeed;
    }
    private void OnEnable()
    {
        FindCurrentBlock();
        playerRect.position = blocks[currentBlock].position;
    }
    //public void OnNotify(object value, NotificationType notificationType)
    //{
    //    MoveWithCharacter();
    //}
    //public void MoveWithCharacter()
    //{
    //    FindCurrentBlock();
    //    StartCoroutine(MoveRator());
    //}
    public void FindCurrentBlock()
    {
        var player = FindPlayer;
        if (player != null)
        {
            currentBlock = player.GetComponent<CharacterMovement>().currentBlock;
        }
    }
    //public IEnumerator MoveRator()
    //{
    //    while (transform.position != blocks[currentBlock].position)
    //    {
    //        Vector3 endPosition = blocks[nextBlock].position;
    //        yield return MoveABlock(endPosition);
    //    }
    //}
    //public IEnumerator MoveABlock(Vector3 endPosition)
    //{
    //    Vector3 startPosition = transform.position;
    //    float time = 0f;
    //    while (playerRect.position != endPosition)
    //    {
    //        time += Time.deltaTime;
    //        playerRect.position = Vector2.MoveTowards(startPosition, endPosition, speed * time);
    //        yield return null;
    //    }
    //}

    public void OpenCloseEvent()
    {
        gameObject.SetActive(!gameObject.activeSelf);
    }
}
