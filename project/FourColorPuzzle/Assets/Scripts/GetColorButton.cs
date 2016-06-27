using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GetColorButton : MonoBehaviour
{
	const int COLOR_KIND = 4;
	Sprite[] ColorButtonImage;
	GameObject Canvas;
	GameObject BackGround;

	const int X_MAX = 5;
	const int Y_MAX = 7; // 仮.
	const int ColorSpace = 200;

	// Use this for initialization
	void Start()
	{
		ColorButtonImage = new Sprite[COLOR_KIND];
		Canvas = GameObject.Find("GameCanvas");
		BackGround = GameObject.Find("ChangeColorBackGround");
		// 各画像取得.
	}

	public void OnClick()
	{
		// 既存キャンバスの無効化.
		Canvas.SetActive(false);
		// 新キャンバスの出現.		
		BackGround.transform.localScale = new Vector3(6, 11, 1);
		// 各画像の配置,


	}

	// Update is called once per frame
	void Update()
	{

	}
}
