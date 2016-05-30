using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class TestSceneChange : MonoBehaviour
{
	public void ButtonPush(string text)
	{
		SceneManager.LoadScene(text);
	}
}
