using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxMethod : GoBangMethod
{
    public override void Run(GoBangMainLoop.point local, int fill)
    {
        var game = CurrentGame();
        var point = new GoBangMainLoop.point();
        for (int i = -1; i < 2; i++)
        {
            for (int j = -1; j < 2; j++)
            {
                if ((Mathf.Abs(i) + Mathf.Abs(j) == 2) || (fill == 1))
                {
                    point.x = local.x + i;
                    point.y = local.y + j;
                    if (game.check_point(point))
                    {
                        var cross = game.board.GetCross(point.x, point.y);
                        game.place_chess(cross, game.isBlack);
                    }
                }
            }
        }
    }
}
