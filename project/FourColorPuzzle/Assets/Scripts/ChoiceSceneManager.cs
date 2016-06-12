using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class ChoiceSceneManager : MonoBehaviour {


    private const int SceneNum = 25;

    private GameObject[] buttons;   // ボタンのゲームオブジェクト

    private int nowClearStage = 0;

    [SerializeField]
    private Text debugText;

    private Color choiceColor    = new Color( 1.0f, 1.0f, 1.0f );
    private Color notChoiceColor = new Color( 0.3f, 0.3f, 0.3f );


    // デバッグ用
    public void Clear()
    {
        nowClearStage = (++nowClearStage)%SceneNum;

        string str = "";
        str += "クリアステージ：";
        str += nowClearStage;
        debugText.text = str;
        ButtonSetting();
    }

    public void ChoiceStage(int stage)
    {

        if (stage > nowClearStage + 1)
        {
            return;
        }

        switch (stage)
        {
            case 1: /*ステージ1に呼ばす処理*/ break;
            case 2: /*ステージ2に呼ばす処理*/ break;
            case 3: /*ステージ3に呼ばす処理*/ break;
            case 4: /*ステージ4に呼ばす処理*/ break;
            case 5: /*ステージ5に呼ばす処理*/ break;
            case 6: /*ステージ6に呼ばす処理*/ break;
            case 7: /*ステージ7に呼ばす処理*/ break;
                // .
                // .
                // .
                // .
                // .
                // .
        }


    }


    void Awake()
    {
        buttons = new GameObject[SceneNum];
        GameObject[] obj = GameObject.FindGameObjectsWithTag("ChoiceButton");

        for (int i = 0; i < SceneNum; ++i)
        {
            for (int j = 0; j < SceneNum; ++j)
            {
                string str = "";
                str += (i+1);

                if (obj[j].name == str)
                {
                    buttons[i] = obj[j];
                }
            }
        }
        ButtonSetting();
    }


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    // ボタンの色をセットする
    void ButtonSetting()
    {
        for (int i = 0; i < SceneNum; ++i)
        {
            if (i < (nowClearStage + 1))
            {
                // クリア済み + 1ステージ
                buttons[i].GetComponent<Image>().color = choiceColor;
                buttons[i].GetComponent<Button>().interactable = true;
            }
            else
            {
                // クリア前
                ColorBlock cb = buttons[i].GetComponent<Button>().colors;
                cb.disabledColor = notChoiceColor;
                buttons[i].GetComponent<Button>().colors = cb;
                buttons[i].GetComponent<Button>().interactable = false;
            }
        }
    }


}
