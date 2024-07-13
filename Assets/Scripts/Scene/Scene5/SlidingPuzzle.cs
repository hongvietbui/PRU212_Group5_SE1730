﻿using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SlidingPuzzle : MonoBehaviour
{
	public NumberBox boxPrefab;
	public NumberBox[,] boxes = new NumberBox[4, 4];
	public Sprite[] sprites;
	public Button reloadButton;
	public Button cancelButton;
	public Canvas canvas; // Reference to the Canvas component
	private bool isCanvasActive = true; // Track the current state of the canvas
	private int clickCount = 0;

	void Start()
	{
		Init();
		for (int i = 0; i < 999; i++)
			Shuffle();

		reloadButton.onClick.AddListener(ReloadPuzzle);
		cancelButton.onClick.AddListener(CancelPuzzle);
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
			}
		}
	}

	void Swap(int x, int y, int dx, int dy)
	{
		var from = boxes[x, y];
		var target = boxes[x + dx, y + dy];

		boxes[x, y] = target;
		boxes[x + dx, y + dy] = from;

		from.UpdatePos(x + dx, y + dy);
		target.UpdatePos(x, y);
	}

	int getDx(int x, int y)
	{
		if (x < 3 && boxes[x + 1, y].isEmpty())
		{
			return 1;
		}
		if (x > 0 && boxes[x - 1, y].isEmpty())
		{
			return -1;
		}
		return 0;
	}

	int getDy(int x, int y)
	{
		if (y < 3 && boxes[x, y + 1].isEmpty())
		{
			return 1;
		}
		if (y > 0 && boxes[x, y - 1].isEmpty())
		{
			return -1;
		}
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
		PuzzleState.isPuzzleSolved = true;
		SceneManager.LoadScene("Scene5_ExitClassRoom");
		return true;
	}

	void ReloadPuzzle()
	{
		clickCount++;

		// Toggle the canvas state based on the number of clicks
		if (clickCount % 2 == 1)
		{
			canvas.gameObject.SetActive(true); // Deactivate the canvas on the first click
		}
		else
		{
			canvas.gameObject.SetActive(false); // Activate the canvas on the second click
		}
	}

	void CancelPuzzle()
	{
		PuzzleState.isPuzzleSolved = false; // Ensure the puzzle is marked as not solved.
		SceneManager.LoadScene("Scene5_ExitClassRoom");
	}
}
