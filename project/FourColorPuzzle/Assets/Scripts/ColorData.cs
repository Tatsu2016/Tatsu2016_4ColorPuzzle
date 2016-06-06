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

	ColorScript afterColor;

	// クリックされたUIの判定用.
	bool isBeforeClick;
	static bool isClick;


	// Use this for initialization
	//void Start()
	//{
	//	// 自動でコライダーコンポーネント追加.
	//	gameObject.AddComponent<BoxCollider2D>();
	//	OriginScale = transform.localScale;
	//	OriginPos = transform.localPosition;
	//	SelectScale = new Vector3(1.2f, 1.2f, 1.0f);
	//	SelectPos = new Vector3(-0.1f, 0.1f, 0.0f);
	//	SelectPos += OriginPos;
	//	obj = GameObject.Find("ColorObj");
	//	afterColor = obj.GetComponent<ColorScript>();
	//}
	//
	//// Update is called once per frame
	//void Update()
	//{
	//	if (Input.GetMouseButtonDown(0))
	//	{
	//		Vector2 tapPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
	//		Collider2D collider = Physics2D.OverlapPoint(tapPoint);
	//		if (collider == null)
	//			return;
	//		if (collider.name == gameObject.name)
	//		{
	//			afterColor.ColorInfo = ColorInfo;
	//			gameObject.transform.localScale = SelectScale;
	//			gameObject.transform.localPosition = SelectPos;
	//		}
	//		else
	//		{
	//			if (collider.tag == "ColorPanel")
	//			{
	//				gameObject.transform.localScale = OriginScale;
	//				gameObject.transform.localPosition = OriginPos;
	//			}
	//		}
	//	}
	//}

	void Start()
	{
		isBeforeClick = isClick = false;
		OriginScale = transform.localScale;
		OriginPos = transform.localPosition;
		SelectScale = new Vector3(1.2f, 1.2f, 1.0f);
		SelectPos = new Vector3(-0.1f, 0.1f, 0.0f);
		SelectPos += OriginPos;
		GameObject obj;
		obj = GameObject.Find("ColorObj");
		afterColor = obj.GetComponent<ColorScript>();
	}

	public void ColorChange()
	{
		// 自分自身のフラグをUI全体と共通化する.
		isBeforeClick = isClick;
		// UI共通のフラグを入れ替える.
		isClick = !isClick;

		afterColor.ColorInfo = ColorInfo;
		gameObject.transform.localScale = SelectScale;
		gameObject.transform.localPosition = SelectPos;
	}

	void Update()
	{
		// 自分自身のフラグとUI共通のフラグが同じ.
		// = 他のUIがクリックされたとき.
		if (isBeforeClick == isClick)
		{
			// 自分のサイズを元の大きさに戻す.
			gameObject.transform.localScale = OriginScale;
			gameObject.transform.localPosition = OriginPos;
		}
	}
}
