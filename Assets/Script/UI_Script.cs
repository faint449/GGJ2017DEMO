using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UI_Script : MonoBehaviour {
    public GameObject[] Obj_UiTime = new GameObject[3];
    public GameObject[] Obj_UI = new GameObject[5];
    public GameObject[] Obj_UiWifi = new GameObject[3];
    public GameObject Obj_ScreenEffect ;   //遊戲背景，(( 閃爍畫面 ))
    public Music Music_Script;                      //使用Music腳本

    [Header("遊戲總共可以執行的時間")]
    public float flo_MaxTime = 10;          //遊戲總共有的時間

    private int int_CurrectLevel = 1;   //目前所在第幾關卡
    private bool bool_LowHp = false;    //遊戲時間條 - 用來判斷切換時間條顏色的變化
    private bool bool_ScreenColor=false;//遊戲背景 -  用來判斷切換背景顏色的變化
    private float flo_Currect_Time;     //遊戲目前所剩的時間

    public enum enum_Level
    {
        GameStart , 
        Level_01 , 
        GameEnd , 
    }
    public static enum_Level Enum_CurrectLevel; 

    public void Awake()
    {
        Music_Script = GameObject.FindObjectOfType<Music>(); 
        Obj_UiTime[0] = GameObject.Find("Canvas_Time");         //抓取UI時間的Canvas
        Obj_UiTime[1] = GameObject.Find("MaxTime");             //最大時間UI
        Obj_UiTime[2] = GameObject.Find("Currect_Time");        //目前時間UI

        Obj_UI[0] = GameObject.Find("Canvas_UI");               //UI畫面的Canvas
        Obj_UI[1] = GameObject.Find("Image_LowHp");             //殘血提醒
       

        Obj_UiWifi[0] = GameObject.Find("UI_Camera_Phone");     //管理收訊好壞的介面 

        Obj_ScreenEffect = GameObject.Find("Image_Background"); //抓取遊戲背景閃爍的畫面
    }

    public void Start()
    {
        Obj_UiWifi[0].SetActive(false);                         //開場關閉收訊UI
        Obj_ScreenEffect.SetActive(false);                      //關閉遊戲背景
        flo_Currect_Time = flo_MaxTime;

        Music_Script.AudioSource_Music.GetComponent<AudioSource>().clip = Music_Script.List_Audio[1];
        Music_Script.AudioSource_Music.GetComponent<AudioSource>().Play();

    }

    public void Update()
    {
        
        if (Enum_CurrectLevel == enum_Level.GameStart)          //遊戲開始狀態
        {
            Enum_CurrectLevel = enum_Level.Level_01; 
        }
        else if (Enum_CurrectLevel == enum_Level.Level_01)      //第一關關卡
        {
            flo_Currect_Time -= Time.deltaTime; 
            Obj_UiTime[2].GetComponent<Image>().fillAmount = (flo_Currect_Time / flo_MaxTime );

            if (Obj_UiTime[2].GetComponent<Image>().fillAmount > 0.0f )
            {
                if (bool_LowHp)
                {
                    Obj_UiTime[2].GetComponent<Image>().color = Color.Lerp(Obj_UiTime[2].GetComponent<Image>().color , new Color(1, 1, 1, 0.1f) , 1.5f * Time.deltaTime);
                    if (Obj_UiTime[2].GetComponent<Image>().color.a <= 0.15f)
                    {
                        bool_LowHp = false; 
                    }
                }
                else
                {
                    Obj_UiTime[2].GetComponent<Image>().color = Color.Lerp(Obj_UiTime[2].GetComponent<Image>().color, new Color(1, 1, 1, 1), 1.5f * Time.deltaTime);
                    if (Obj_UiTime[2].GetComponent<Image>().color.a >= 0.8f)
                    {
                        bool_LowHp = true;
                    }
                }

                if (Obj_UiTime[2].GetComponent<Image>().fillAmount <= 0.5f)
                {
                    Obj_ScreenEffect.SetActive(true);                   //打開遊戲背景 
                    if (bool_ScreenColor)
                    {
                        Obj_ScreenEffect.GetComponent<Image>().color = Color.Lerp(Obj_ScreenEffect.GetComponent<Image>().color , new Color(1, 0 , 0, 0.05f) , Time.deltaTime);
                        if (Obj_ScreenEffect.GetComponent<Image>().color.a <= 0.06f)
                        {
                            bool_ScreenColor = false; 
                        }
                    }
                    else
                    {
                        Obj_ScreenEffect.GetComponent<Image>().color = Color.Lerp(Obj_ScreenEffect.GetComponent<Image>().color, new Color(1, 0, 0, 0.2f), Time.deltaTime);
                        if (Obj_ScreenEffect.GetComponent<Image>().color.a > 0.18f )
                        {
                            bool_ScreenColor = true;
                        }
                    }
                }
            }
            else
            {
                Debug.Log("遊戲失敗");
                Enum_CurrectLevel = enum_Level.GameEnd;                 //遊戲失敗
            }
        }
    }
}
