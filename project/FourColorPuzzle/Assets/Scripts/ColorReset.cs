using UnityEngine;
using System.Collections;

public class ColorReset : MonoBehaviour
{
	GameObject[] obj;
	SpriteRenderer[] CheckSprite;
	// Use this for initialization
	void Start()
	{	
		obj = GameObject.FindGameObjectsWithTag ("Puzzle");
		CheckSprite = new SpriteRenderer[obj.Length];
		for (int i = 0; i < obj.Length; i++)
			CheckSprite[i] = obj[i].GetComponent<SpriteRenderer>();
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
				for (int i = 0; i < obj.Length; i++)
					CheckSprite[i].color = Color.white;
			}
		}
	}
}
