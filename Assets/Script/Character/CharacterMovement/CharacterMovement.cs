using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public Transform character;
    public Animator animator;
    public bool AI = true;
    public float speed = 6f;
    public float speedPro => AI ? speed * 2 : speed;
    public Grid grid;

    public int currentBlock;
    public int targetBlock => (currentBlock + 1) == blockCount ? 0 : currentBlock + 1;
    public int finalBlock;
    public bool isMoving => currentBlock != finalBlock;
    private int blockCount => AI ? MovementGrid.EnemyInnerMovementBlocks.Count : MovementGrid.PlayerMovementBlocks.Count;
    public delegate Vector3Int GetGridBlock(int block);
    public GetGridBlock getGrid;
    private void Awake()
    {
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
    }
    public IEnumerator MoveToLocation()
    {
        finalBlock = finalBlock % blockCount;
        animator.SetTrigger("Move");
        bool isInView = VisibleCheck.ColliderInView(character.gameObject);

        while (currentBlock != finalBlock)
        {
            isInView = VisibleCheck.ColliderInView(character.gameObject);
            if (isInView)
            {
                yield return MoveToNextBlock();
            }
            else
            {
                if (!VisibleCheck.IsInView(grid.GetCellCenterWorld(getGrid(finalBlock))))
                {
                    character.position = grid.GetCellCenterWorld(getGrid(finalBlock));
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
        animator.SetTrigger("Stop");
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
