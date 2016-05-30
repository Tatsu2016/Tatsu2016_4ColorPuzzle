using UnityEngine;
using System.Collections;

public class ChangeColor : MonoBehaviour
{
	[HideInInspector]
	public SpriteRenderer sprite;
	GameObject obj;
	ColorScript Data;
	// Use this for initialization
	void Start()
	{
		// 自動でコライダーコンポーネント追加.
		gameObject.AddComponent<PolygonCollider2D>();
		gameObject.tag = "Puzzle";
		sprite = GetComponent<SpriteRenderer>();
		obj = GameObject.Find("ColorObj");
		Data = obj.GetComponent<ColorScript>();
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
			if (collider.name == gameObject.name)
			{
				sprite.color = new Color(Data.ColorInfo.r, Data.ColorInfo.g, Data.ColorInfo.b);
			}
		}
	}
}
