using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyMethod : GoBangMethod
{
    private int effect = 0;
    public override void Run(GoBangMainLoop.point local, int effect)
    {
        this.effect = effect;
        var game = CurrentGame();
        var target = new GoBangMainLoop.point();
        switch (effect)
        {
            default:
                break;
            case 0:
            case 1:
                for (int i = -1; i < 2; i++)
                {
                    for (int j = -1; j < 2; j++)
                    {
                        if ((Mathf.Abs(i) + Mathf.Abs(j) == 2))
                        {
                            target.x = local.x + i;
                            target.y = local.y + j;
                            if (!game.check_point(target))
                            {
                                DestroyChess(target);
                            }
                        }
                    }
                }
                break;
            case 2:
            case 5:
                for (int i = -1; i < 2; i++)
                {
                    for (int j = -1; j < 2; j++)
                    {
                        target.x = local.x + i;
                        target.y = local.y + j;
                        if (!target.Equals(local))
                        {
                            if (!game.check_point(target) || effect == 5)
                            {
                                DestroyChess(target);
                            }
                        }
                    }
                }
                break;
            case 3:
            case 4:
                for (int i = -1; i < 2; i++)
                {
                    for (int j = -1; j < 2; j++)
                    {
                        if ((Mathf.Abs(i) + Mathf.Abs(j) != 2))
                        {
                            if (!target.Equals(local))
                            {
                                target.x = local.x + i;
                                target.y = local.y + j;
                                if (!game.check_point(target))
                                {
                                    DestroyChess(target);
                                }
                            }
                        }
                    }
                }
                break;
        }
        game.CheckWin();
    }

    public void DestroyChess(GoBangMainLoop.point target)
    {
        var game = GoBangMethod.CurrentGame();
        var targetCurrentSide = BoardModel.get_type(target.x, target.y);
        bool isBlack = game.isBlack;
        int output = isBlack ? 1 : 2;
        var cross = game.board.GetCross(target.x, target.y);
        Transform parentCross = TransformEx.Clear(cross.gameObject.transform);

        switch (effect)
        {
            default:
                break;
            case 0:
            case 4:
            case 5:
                BoardModel.set_type(target.x, target.y, 0);
                break;
            case 1:
            case 2:
            case 3:
                BoardModel.set_type(target.x, target.y, output);
                var new_chess = UnityEngine.GameObject.Instantiate(isBlack ? game.black_prefab : game.white_prefab);
                new_chess.transform.SetParent(parentCross, false);
                break;
        }
    }
}
