using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SetTimer : MonoBehaviour {
    private int minute;
    private float second;
    private int oldsecond;
    public Text timeLabel;
    public ClearCheck clear;
    public string minutekey;
    public string secondkey;

	// Use this for initialization
	void Start () {
        minute = 0;
        second = 0;
        oldsecond = 0;

  //      PlayerPrefs.DeleteAll();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale > 0 && clear.isClear == false)
        {
            second += Time.deltaTime;
            if (second >= 60.0f)
            {
                second = 0;
                minute++;
            }
            if ((int)second != oldsecond)
                timeLabel.text = minute.ToString("00") + ":" + second.ToString("00");

            oldsecond = (int)second;

            //Debug.Log(PlayerPrefs.HasKey(minutekey));
        }

        if (clear.isClear == true)
        {
            if (PlayerPrefs.HasKey(minutekey) == false)
            {
                PlayerPrefs.SetInt(minutekey, minute);
            }
            if (PlayerPrefs.HasKey(secondkey) == false)
            {
                PlayerPrefs.SetInt(secondkey, (int)second);
            }

            if (PlayerPrefs.GetInt(minutekey) > minute)
            {
                PlayerPrefs.SetInt(minutekey, minute);
            }
            if (PlayerPrefs.GetInt(secondkey) > (int)second)
            {
                PlayerPrefs.SetInt(secondkey, (int)second);
            }

        }
    }

    //void OnGUI()
    //{
    //    if (GUI.Button(new Rect(0, 0, 150, 100), "reset"))
    //    {
    //        //デバッグ用。保存データ初期化
    //        PlayerPrefs.DeleteAll();
    //        Debug.Log("データ全消去したわよッ!!(・∀・)");
    //    }
    //}
}
