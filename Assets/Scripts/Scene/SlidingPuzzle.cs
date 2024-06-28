using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlidingPuzzle : MonoBehaviour
{
	public NumberBox boxPrefab;
	public NumberBox[,] boxes = new NumberBox[4, 4];
	public Sprite[] sprites;

	void Start()
	{
		Init();
		for (int i = 0; i < 999; i++)
			Shuffle();
	}

	void Init()
	{
		int n = 0;
		for (int y = 3; y >= 0; y--)
		{
			for (int x = 0; x < 4; x++)
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
		if (dx != 0 || dy != 0)
		{
			Swap(x, y, dx, dy);
			if (IsPuzzleSolved())
			{
				Debug.Log("Puzzle Solved!");
				// You can add more actions here, like showing a UI message or triggering an event.
			}
		}
	}

	void Swap(int x, int y, int dx, int dy)
	{
		var from = boxes[x, y];
		var target = boxes[x + dx, y + dy];

		// Swap
		boxes[x, y] = target;
		boxes[x + dx, y + dy] = from;

		// Update
		from.UpdatePos(x + dx, y + dy);
		target.UpdatePos(x, y);
	}

	int getDx(int x, int y)
	{
		// Is right empty
		if (x < 3 && boxes[x + 1, y].isEmpty())
		{
			return 1;
		}

		// Is left empty
		if (x > 0 && boxes[x - 1, y].isEmpty())
			return -1;
		return 0;
	}

	int getDy(int x, int y)
	{
		// Is up empty
		if (y < 3 && boxes[x, y + 1].isEmpty())
		{
			return 1;
		}

		// Is down empty
		if (y > 0 && boxes[x, y - 1].isEmpty())
			return -1;

		return 0;
	}

	void Shuffle()
	{
		for (int i = 0; i < 4; i++)
		{
			for (int j = 0; j < 4; j++)
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
		do
		{
			int n = Random.Range(0, 4);
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
			else
			{
				pos = Vector2.down;
			}

		} while (!(isValidRange(x + (int)pos.x) && isValidRange(y + (int)pos.y)) || isRepeatMove(pos));

		lastMove = pos;
		return pos;
	}

	bool isValidRange(int n)
	{
		return n >= 0 && n <= 3;
	}

	bool isRepeatMove(Vector2 pos)
	{
		return pos * -1 == lastMove;
	}

	bool IsPuzzleSolved()
	{
		int n = 1;
		for (int y = 3; y >= 0; y--)
		{
			for (int x = 0; x < 4; x++)
			{
				if (boxes[x, y].index != n)
				{
					return false;
				}
				n++;
			}
		}
		return true;
	}
}
