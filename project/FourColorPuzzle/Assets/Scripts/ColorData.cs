using UnityEngine;
using System.Collections;

public class ColorData : MonoBehaviour
{
	[SerializeField]
	Color32 ColorInfo;

	// 初期.
	Vector3 OriginScale;
	Vector3 OriginPos;
	// 選択時.
	Vector3 SelectScale;
	Vector3 SelectPos;

	GameObject obj;
	ColorScript afterColor;

	// Use this for initialization
	void Start()
	{
		// 自動でコリダーコンポーネント追加.
		gameObject.AddComponent<BoxCollider2D>();
		OriginScale = transform.localScale;
		OriginPos = transform.localPosition;
		SelectScale = new Vector3(1.2f, 1.2f, 1.0f);
		SelectPos = new Vector3(-0.1f, 0.1f, 0.0f);
		SelectPos += OriginPos;
		obj = GameObject.Find("ColorObj");
		afterColor = obj.GetComponent<ColorScript>();
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
				afterColor.ColorInfo = ColorInfo;
				gameObject.transform.localScale = SelectScale;
				gameObject.transform.localPosition = SelectPos;
			}
			else
			{
				if (collider.tag == "ColorPanel")
				{
					gameObject.transform.localScale = OriginScale;
					gameObject.transform.localPosition = OriginPos;
				}
			}
		}
	}
}
