using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ShortestRecord : MonoBehaviour {
    public Text recordLabel;
    public string minutekey;
    public string secondkey;

	// Use this for initialization
	void Start () {
        recordLabel.text = PlayerPrefs.GetInt(minutekey).ToString("00") + ":" + PlayerPrefs.GetInt(secondkey).ToString("00");
        //Debug.Log(PlayerPrefs.HasKey(minutekey));
	}
	
	// Update is called once per frame
	void Update () {
	
	}
#if UNITY_EDITOR_WIN
    void OnGUI()
    {
        if (GUI.Button(new Rect(0, 200, 100, 50), "reset"))
        {
            //デバッグ用。保存データ初期化
            PlayerPrefs.DeleteAll();
            Debug.Log("データ全消去!!!(・∀・)");
        }
    }
#endif
}
