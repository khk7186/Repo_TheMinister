using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterMovement : MonoBehaviour, IStopAllCoroutine
{
    public static float playerSpeed => GameObject.FindGameObjectWithTag("Player")
                                                            .GetComponent<CharacterMovement>().speed;
    public Transform character;
    public CharacterModelController modelController;
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
    public void OnEnable()
    {
        if (modelController != null)
        {
            StartCoroutine(ModelMoveRator());
        }
        else
            StartCoroutine(MoveRator());
    }
    public void OnDisable()
    {
        StopAllCoroutines();
    }
    public void ModelDieAnimation()
    {
        modelController.front.GetComponent<Animator>().SetTrigger("Death");
        modelController.back.GetComponent<Animator>().SetTrigger("Death");
    }
    public IEnumerator ModelMoveRator()
    {
        while (true)
        {
            if (AI == false)
            {
                if (isMoving)
                {
                    modelController.front.GetComponent<Animator>().SetFloat("Speed 0", 1f);
                    modelController.back.GetComponent<Animator>().SetFloat("Speed 0", 1f);
                    oldPosition = transform.position;
                    yield return new WaitForEndOfFrame();
                    continue;
                }
            }
            if (oldPosition != (Vector2)transform.position)
            {
                modelController.front.GetComponent<Animator>().SetFloat("Speed 0", 1f);
                modelController.back.GetComponent<Animator>().SetFloat("Speed 0", 1f);
            }
            else
            {
                modelController.front.GetComponent<Animator>().SetFloat("Speed 0", 0f);
                modelController.back.GetComponent<Animator>().SetFloat("Speed 0", 0f);
            }
            oldPosition = transform.position;
            yield return new WaitForEndOfFrame();
        }
    }
    public IEnumerator MoveRator()
    {
        while (true)
        {
            if (oldPosition != (Vector2)transform.position)
                animator.SetFloat("Speed 0", 1f);
            else
            {
                animator.SetFloat("Speed 0", 0f);
            }
            oldPosition = transform.position;
            yield return new WaitForEndOfFrame();
        }
    }
    private void Awake()
    {
        modelController = GetComponent<CharacterModelController>();
    }
    private void Start()
    {
        if (modelController == null)
            animator.SetFloat("Speed 0", 0f);
        else
        {
            modelController.front.GetComponent<Animator>().SetFloat("Speed 0", 0f);
            modelController.back.GetComponent<Animator>().SetFloat("Speed 0", 0f);
        }
        if (grid == null)
        {
            grid = FindObjectOfType<MovementGrid>()?.GetComponent<Grid>();
        }
        if (!AI)
        {
            getGrid = ((block) => MovementGrid.GetPlayerBlock(block));
        }
        if (SceneManager.GetActiveScene().buildIndex != 1 || CutScene)
        {
            return;
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
    public IEnumerator MoveToLocationOld()
    {
        finalBlock = finalBlock % blockCount;
        while (currentBlock != finalBlock)
        {
            yield return MoveToNextBlock();
        }
    }

    public IEnumerator MoveToNextBlock()
    {
        Vector2 startPt = transform.position;
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

    public IEnumerator MoveToLocation(Vector2 endPosition, float speed = 3)
    {
        Vector2 startPosition = transform.position;
        float speedRD = Random.Range(playerSpeed / 2, playerSpeed);
        float time = 0f;
        while ((Vector2)character.position != endPosition)
        {
            time += Time.deltaTime;
            character.position = Vector2.MoveTowards(startPosition, endPosition, speedRD * time);
            yield return null;
        }
    }
    public void StopAllCoroutine()
    {
        StopAllCoroutines();
    }
    public void RegisterStoper()
    {
        if (PathManager.Instance == null)
        {
            PathManager.Instance.RegistedCoroutines.Add(this);
        }
    }
}
