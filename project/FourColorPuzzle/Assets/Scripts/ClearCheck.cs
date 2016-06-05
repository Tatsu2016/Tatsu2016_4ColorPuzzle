using UnityEngine;
using System.Collections;

public class ClearCheck : MonoBehaviour
{
	JudgeColor[] Judge;
	GameObject[] Obj;
	ChangeColor[] Color;
	bool isClear;

	// Use this for initialization
	void Start()
	{
		gameObject.transform.localPosition = new Vector3(100, 0, 0);
		Obj = GameObject.FindGameObjectsWithTag("Puzzle");
		Judge = new JudgeColor[Obj.Length];
		Color = new ChangeColor[Obj.Length];
		for (int i = 0; i < Obj.Length; i++)
		{
			Judge[i] = Obj[i].GetComponent<JudgeColor>();
			Color[i] = Obj[i].GetComponent<ChangeColor>();
		}
		isClear = false;
	}

	// Update is called once per frame
	void Update()
	{
		if (Input.GetMouseButtonDown(0))
		{
			Vector2 tapPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			Collider2D collider = Physics2D.OverlapPoint(tapPoint);
			if (collider == null)
				return;

			if (collider.tag != "Puzzle")
			{
				if(collider.tag == "Reset")
				{
					isClear = false;
					gameObject.transform.localPosition = new Vector3(100, 0, 0);
				}
				return;
			}
			for (int i = 0; i < Judge.Length; i++)
			{
				if (Color[i].sprite.color == new Color(1, 1, 1) || Color[i].sprite.color == new Color(255, 255, 255))
				{
					isClear = false;
					gameObject.transform.localPosition = new Vector3(100, 0, 0);
					return;
				}
				for (int s = 0; s < Judge[i].CheckSprite.Length; s++)
				{
					SpriteRenderer Sprite = Judge[i].CheckSprite[s];
					if (Color[i].sprite.color == Sprite.color)
					{
						isClear = false;
						gameObject.transform.localPosition = new Vector3(100, 0, 0);
						return;
					}
				}
			}
			isClear = true;
			gameObject.transform.localPosition = new Vector3(0, 0, 0);
		}
	}

	// クリア判定悩み中.

}
