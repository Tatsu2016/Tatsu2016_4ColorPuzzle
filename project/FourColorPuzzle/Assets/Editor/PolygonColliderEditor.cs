using UnityEngine;
using System.Collections;
using UnityEditor;

public class PolygonColliderEditor : EditorWindow
{
	GameObject[] TargetGameObject;
	int TargetGameObjectCount;
	string ObjectName;
	bool isSerialNumber;
	bool isAdd;

	[MenuItem("ComponentSettings/PolygonCollider")]
	static void CreateWindow()
	{
		// ウインドウの取得.
		// ここの引数、動的に指定出来るように変更したい.
		// 動的にしたらエディタ拡張(スクリプトアタッチ系)のクラス1つで済む.
		var Window = EditorWindow.GetWindow(typeof(PolygonColliderEditor));
		// ウインドウの表示.
		Window.Show();
	}

	void OnGUI()
	{
		// テキストフィールド.
		ObjectName = EditorGUILayout.TextField("対象GameObject名", ObjectName);
		isSerialNumber = EditorGUILayout.Toggle("対象の名前に連番を含める", isSerialNumber);
		EditorGUILayout.LabelField("↓連番を含める場合のみ有効");
		TargetGameObjectCount = EditorGUILayout.IntField("対象となるGameObject数", TargetGameObjectCount);
		isAdd = EditorGUILayout.Toggle("追加する(falseで削除)", isAdd);

		if (GUILayout.Button("確定"))
		{
			if (!isSerialNumber)
				TargetGameObjectCount = 1;

			SetComponent();
		}
	}

	void SetComponent()
	{
		TargetGameObject = new GameObject[TargetGameObjectCount];
		for (int i = 0; i < TargetGameObjectCount; i++)
		{
			if (i > 0)
				TargetGameObject[i] = GameObject.Find(ObjectName + " (" + i + ")");
			else
				TargetGameObject[i] = GameObject.Find(ObjectName);

			if (isAdd)
			{
				TargetGameObject[i].AddComponent<PolygonCollider2D>();
				Debug.Log(TargetGameObject[i].name + "にPolygonCollider2Dを追加");
			}
			else
			{
				// http://baba-s.hatenablog.com/entry/2015/07/12/100000
				// Destroyだとエラーが出るので回避
				GameObject.DestroyImmediate(TargetGameObject[i].GetComponent<PolygonCollider2D>());
				Debug.Log(TargetGameObject[i].name + "からPolygonCollider2Dを削除");
			}
		}
	}


}
