using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlidingPuzzle : MonoBehaviour
{
    public NumberBox boxPrefab;
    public NumberBox[,] boxes = new NumberBox[5, 5];
    public Sprite[] sprites;

    void Start()
    {
        Init();
        for (int i = 0; i < 99; i++)
            Shuffle();
    }


    void Init()
    {
        int n = 0;
        for (int y = 4; y >= 0; y--)
        {
            for (int x = 0; x < 5; x++)
            {
                NumberBox box = Instantiate(boxPrefab, new Vector2(x, y), Quaternion.identity);
                box.Init(x, y, n + 1, sprites[n], clickToSwap);
                boxes[x, y] = box;
                n++;
            }
        }
    }

    void clickToSwap(int x, int y)
    {
        int dx = getDx(x, y);
        int dy = getDy(x, y);
        Swap(x, y, dx, dy);
    }

    void Swap(int x, int y, int dx, int dy)
    {
        var from = boxes[x, y];
        var target = boxes[x + dx, y + dy];

        //swap
        boxes[x, y] = target;
        boxes[x + dx, y + dy] = from;

        //update
        from.UpdatePos(x + dx, y + dy);
        target.UpdatePos(x, y);
    }

    int getDx(int x, int y)
    {
        //is right empty
        if (x < 4 && boxes[x + 1, y].isEmpty())
        {
            return 1;
        }

        //is left empty
        if (x > 0 && boxes[x - 1, y].isEmpty())
            return -1;
        return 0;
    }

    int getDy(int x, int y)
    {
        //is up empty
        if (y < 4 && boxes[x, y + 1].isEmpty())
        {
            return 1;
        }

        //is down empty
        if (y > 0 && boxes[x, y - 1].isEmpty())
            return -1;
        return 0;
    }

    void Shuffle()
    {
        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                if (boxes[i, j].isEmpty())
                {
                    Vector2 pos = getValidMove(i, j);
                    Swap(i, j, (int)pos.x, (int)pos.y);
                }
            }
        }
    }

    private Vector2 lastMove;

    Vector2 getValidMove(int x, int y)
    {
        Vector2 pos = new Vector2();
        int n = Random.Range(0, 4);
        do
        {
            if (n == 0)
            {
                pos = Vector2.left;
            }
            else if (n == 1)
            {
                pos = Vector2.right;
            }
            else if (n == 2)
            {
                pos = Vector2.up;
            }
            else if (n == 3)
            {
                pos = Vector2.down;
            }

        } while (!(isValidRange(x + (int)pos.x) && isValidRange(y + (int)pos.y)) || isRepeatMove(pos));
        return pos;
    }

    bool isValidRange(int n)
    {
        return n >= 0 && n <= 4;
    }

    bool isRepeatMove(Vector2 pos)
    {
        return pos * -1 == lastMove;
    }

}
