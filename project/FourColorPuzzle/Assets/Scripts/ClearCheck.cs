using UnityEngine;
using System.Collections;

// クリア判定後エフェクトを有効にする処理を書く.

public class ClearCheck : MonoBehaviour
{
	JudgeColor[] Judge;
	GameObject[] Obj;
	ChangeColor[] Color;
	// 自分自身にアタッチされているパーティクルシステムを格納.
	ParticleSystem ClearEffect;

	// デバッグ用にPublic指定.
	public bool isClear;

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
		ClearEffect = this.GetComponent<ParticleSystem>();
		ClearEffect.Stop(true);
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
			ClearEffect.Play();
			isClear = true;
			gameObject.transform.localPosition = new Vector3(0, 0, 0);
		}
#if UNITY_EDITOR_WIN
		else if (Input.GetKeyDown(KeyCode.Space))
		{
			ClearEffect.Play();
			isClear = true;
			gameObject.transform.localPosition = new Vector3(0, 0, 0);
		}
#endif
	}

	// クリア判定悩み中.

}
