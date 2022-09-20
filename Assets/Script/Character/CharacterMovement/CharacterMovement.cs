using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterMovement : MonoBehaviour
{
    public Transform character;
    public Animator animator;
    public bool AI = true;
    public float speed = 6f;
    public bool CutScene = false;
    public float speedPro => AI ? speed * 1.2f : speed;
    public Grid grid;

    public int currentBlock;
    public int targetBlock => (currentBlock + 1) == blockCount ? 0 : currentBlock + 1;
    public int finalBlock;
    public bool isMoving => currentBlock != finalBlock;
    private int blockCount => AI ? MovementGrid.EnemyInnerMovementBlocks.Count : MovementGrid.PlayerMovementBlocks.Count;
    public delegate Vector3Int GetGridBlock(int block);
    public GetGridBlock getGrid;
    private CapsuleCollider2D EndPlaceVisibleChecker;
    private Vector2 oldPosition;
    //public void FixedUpdate()
    //{
    //    if (oldPosition != null)
    //    {
    //        float speed = Vector2.Distance(oldPosition, transform.position) * 100000000 + 0.08f;
    //        animator.SetFloat("Speed 0", speed);
    //        oldPosition = transform.position;
    //    }
    //}
    public void OnEnable()
    {
        StartCoroutine(MoveRator());
    }
    public void OnDisable()
    {
        StopAllCoroutines();
    }
    public IEnumerator MoveRator()
    {
        while (true)
        {
            if (oldPosition != (Vector2)transform.position)
                animator.SetFloat("Speed 0", 1);
            else
                animator.SetFloat("Speed 0", 0);
            oldPosition = transform.position;
            yield return new WaitForEndOfFrame();
        }
    }
    private void Start()
    {
        animator.SetFloat("Speed 0", 0f);
    }
    private void Awake()
    {
        if (SceneManager.GetActiveScene().buildIndex != 1 || CutScene)
        {
            return;
        }
        if (grid == null)
        {
            grid = FindObjectOfType<MovementGrid>().GetComponent<Grid>();
        }
        if (AI)
        {
            getGrid = ((block) => MovementGrid.GetAIBlock(GetComponent<DefaultInGameAI>(), block));
        }
        else
        {
            getGrid = ((block) => MovementGrid.GetPlayerBlock(block));
        }
        if (AI)
        {
            EndPlaceVisibleChecker = new GameObject().AddComponent<CapsuleCollider2D>();
            EndPlaceVisibleChecker.isTrigger = true;
            EndPlaceVisibleChecker.size = character.GetComponent<CapsuleCollider2D>().size;
            EndPlaceVisibleChecker.offset = character.GetComponent<CapsuleCollider2D>().offset;
            EndPlaceVisibleChecker.gameObject.SetActive(false);
        }
    }
    public IEnumerator MoveToLocation()
    {
        finalBlock = finalBlock % blockCount;
        int awayTime = 0;
        if (AI)
        {
            EndPlaceVisibleChecker.gameObject.SetActive(true);
            EndPlaceVisibleChecker.transform.position = grid.GetCellCenterWorld(getGrid(finalBlock));
        }
        while (currentBlock != finalBlock)
        {
            bool isInView = VisibleCheck.WorldPosToPlayer(character.gameObject);
            bool EndPlaceInView = true;
            if (EndPlaceVisibleChecker != null)
            {
                EndPlaceInView = VisibleCheck.WorldPosToPlayer(EndPlaceVisibleChecker.gameObject);
            }
            if (isInView)
            {
                awayTime = 0;
                yield return MoveToNextBlock();
            }
            else
            {
                awayTime += 1;
                if (awayTime < 2)
                {
                    yield return MoveToNextBlock();
                    continue;
                }
                if (!VisibleCheck.IsInView(grid.GetCellCenterWorld(getGrid(finalBlock))))
                {
                    character.position = grid.GetCellCenterWorld(getGrid(finalBlock));
                    currentBlock = finalBlock;
                    break;
                }
                if (currentBlock != finalBlock)
                {
                    character.position = grid.GetCellCenterWorld(getGrid(targetBlock));
                    currentBlock++;
                    currentBlock = currentBlock % blockCount;
                }
            }
        }
        if (AI)
        {
            EndPlaceVisibleChecker.gameObject.SetActive(false);
        }
    }

    public IEnumerator MoveToNextBlock()
    {
        Vector2 startPt = grid.GetCellCenterWorld(getGrid(currentBlock));
        Vector2 endPt = grid.GetCellCenterWorld(getGrid(targetBlock));
        float time = 0f;
        while ((Vector2)character.position != endPt)
        {
            time += Time.deltaTime;
            character.position = Vector2.MoveTowards(startPt, endPt, speedPro * time);
            yield return null;
        }
        currentBlock++;
        currentBlock = currentBlock % blockCount;
        yield return null;
    }

}
