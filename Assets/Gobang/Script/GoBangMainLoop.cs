using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class GoBangMainLoop : MonoBehaviour
{
    public struct point
    {
        public int x, y, v;
        public bool Equals(point point)
        {
            return (x == point.x) && (y == point.y);
        }
    };
    public GameObject white_prefab;
    public GameObject black_prefab;
    public int state;
    public bool gameEnd = false;
    public Board board;
    public bool isBlack = true;
    public GoBangMethod PlayerMethod;
    public int playerEffect;
    public GoBangMethod AIMethod;
    public int AIEffect;
    public AI ai;

    public bool check_point(point p) // check if valid
    {
        return !(p.x > 14 || p.x < 0 || p.y > 14 || p.y < 0 || BoardModel.map[p.x, p.y] != 0);
    }

    public void place_chess(Cross cross, bool is_black)
    {
        if (cross == null)
        {
            return;
        }
        var new_chess = Instantiate(is_black ? black_prefab : white_prefab);
        new_chess.transform.SetParent(cross.gameObject.transform, false);
        BoardModel.set_type(cross.grid_x, cross.grid_y, is_black ? 1 : 2);

        CheckWin();
    }

    public void CheckWin()
    {
        int win = BoardModel.check_win();
        if (win == 2)
        {
            state = 4;
        }
        else if (win == 1)
        {
            state = 3;
        }
        StateAction();
    }

    public void Restart()
    {
        state = 1;
        gameEnd = false;
        ai = new AI();
        isBlack = true;
        board.Reset();

        //test, remove after
        place_chess(board.GetCross(6, 6), false);
        place_chess(board.GetCross(7, 6), false);
        place_chess(board.GetCross(7, 8), false);
        place_chess(board.GetCross(6, 4), false);
        place_chess(board.GetCross(5, 8), false);
        place_chess(board.GetCross(6, 7), false);
        place_chess(board.GetCross(9, 6), false);
    }

    public void on_click(Cross cross) // player's turn
    {
        if (state != 1)
        {
            return;
        }
        point tmp = new point();
        tmp.x = cross.grid_x;
        tmp.y = cross.grid_y;
        if (check_point(tmp))
        {
            place_chess(cross, true);
            if (PlayerMethod != null) PlayerMethod.Run(tmp, playerEffect);
            isBlack = false;
            if (state == 1)
            {
                state = 2;
            }
            StateAction();
        }
    }

    private void Start()
    {
        board = GetComponent<Board>();
        Restart();
    }

    private void StateAction()
    {
        switch (state)
        {
            case 2:
                {
                    state = 1;
                    point tmp = ai.select_point();
                    var aiCross = board.GetCross(tmp.x, tmp.y);
                    place_chess(aiCross, false);
                    if (AIMethod!= null)
                    {
                        AIMethod.Run(tmp,AIEffect);
                    }
                    isBlack = true;
                    break;
                }
            case 3:
                {
                    if (!gameEnd)
                    {
                        BoardModel.win_cnt++;
                        Text result_text = GameObject.Find("Canvas/Result").GetComponent<Text>();
                        result_text.text = "Congratulations! You won the game!";
                        gameEnd = true;
                    }
                    break;
                }
            case 4:
                {
                    if (!gameEnd)
                    {
                        BoardModel.lose_cnt++;
                        Text result_text = GameObject.Find("Canvas/Result").GetComponent<Text>();
                        result_text.text = "Too bad. You lost the game......";
                        gameEnd = true;
                    }
                    break;
                }
        }
    }
}
