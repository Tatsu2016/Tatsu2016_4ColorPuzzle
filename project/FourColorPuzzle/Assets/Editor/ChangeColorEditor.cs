using UnityEngine;
using System.Collections;
using UnityEditor;

public class ChangeColorEditor : EditorWindow
{
	GameObject[] TargetGameObject;
	int TargetGameObjectCount;
	string ObjectName;
	bool isSerialNumber;
	bool isAdd;
	
	[MenuItem("ComponentSettings/ChangeColor")]
	static void CreateWindow()
	{
		// ウインドウの取得.
		var Window = EditorWindow.GetWindow(typeof(ChangeColorEditor));
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
				TargetGameObject[i].AddComponent<ChangeColor>();
				Debug.Log(TargetGameObject[i].name + "にChangeColorを追加");
			}
			else
			{
				GameObject.DestroyImmediate(TargetGameObject[i].GetComponent<ChangeColor>());
				Debug.Log(TargetGameObject[i].name + "からChangeColorを削除");
			}
		}
	}


}
