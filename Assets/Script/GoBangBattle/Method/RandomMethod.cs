using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMethod : GoBangMethod
{
    public override void Run(GoBangMainLoop.point local, int effect)
    {
        var game = CurrentGame();
        for (int i = 0; i < effect; i++)
        {
            bool valid = false;
            int tryTimeMax = 20;
            int tryTime = 0;
            int x = 0, y = 0;
            while (!valid || tryTime < tryTimeMax)
            {
                tryTime++;
                var point = new GoBangMainLoop.point();
                x = Random.RandomRange(0, 15);
                y = Random.RandomRange(0, 15);
                point.x = x;
                point.y = y;
                valid = game.check_point(point);
            }
            var cross = game.board.GetCross(x, y);
            game.place_chess(cross,game.isBlack);
        }
    }

}
