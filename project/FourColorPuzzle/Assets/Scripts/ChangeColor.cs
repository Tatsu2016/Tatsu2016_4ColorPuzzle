using UnityEngine;
using System.Collections;

public class ChangeColor : MonoBehaviour
{
	[HideInInspector]
	public SpriteRenderer sprite;
	ColorScript Data;

	//　デバッグ用(クリアしてから判定取らない).
	bool isCleared;
	static bool isDebug;
	GameObject Clear;
	ClearCheck Check;
	// デバッグ用fin.

	public void DebugClear(bool isFlag)
	{
		isDebug = isFlag;
	}

	// Use this for initialization
	void Start()
	{
		// 自動でコライダーコンポーネント追加.
		gameObject.AddComponent<PolygonCollider2D>();
		gameObject.tag = "Puzzle";
		sprite = GetComponent<SpriteRenderer>();
		GameObject obj = GameObject.Find("ColorObj");
		Data = obj.GetComponent<ColorScript>();
		Clear = GameObject.Find("Clear");
		Check = Clear.GetComponent<ClearCheck>();
		isDebug = true;
	}

	// Update is called once per frame
	void Update()
	{
		// デバッグ用.
		if (!isDebug && isCleared)
			return;
		// 無駄感すごい.
		isCleared = Check.isClear;
#if UNITY_ANDROID || UNITY_IOS
		foreach (var touch in Input.touches)
		{
			if (touch.phase == TouchPhase.Began)
			{
				Vector2 tapPoint = Camera.main.ScreenToWorldPoint(touch.position);
				Collider2D collider = Physics2D.OverlapPoint(tapPoint);
				if (collider == null)
					return;
				if (collider.name == gameObject.name)
				{
					sprite.color = new Color(Data.ColorInfo.r, Data.ColorInfo.g, Data.ColorInfo.b);				
				}
			}
		}
#endif
#if UNITY_EDITOR_WIN
		if (Input.GetMouseButtonDown(0))
		{
			Vector2 tapPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			Collider2D collider = Physics2D.OverlapPoint(tapPoint);
			if (collider == null)
				return;
			if (collider.name == gameObject.name)
			{
				sprite.color = new Color(Data.ColorInfo.r, Data.ColorInfo.g, Data.ColorInfo.b);
			}
		}
#endif
	}

}
