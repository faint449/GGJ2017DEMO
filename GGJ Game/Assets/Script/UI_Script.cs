using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UI_Script : MonoBehaviour {
    public GameObject[] Obj_UiTime = new GameObject[3];
    public GameObject[] Obj_UI = new GameObject[5];
    public GameObject[] Obj_UiWifi = new GameObject[3]; 
    public Transform Trans_Target;      //角色的位置

    private int int_CurrectLevel = 1;   //目前所在第幾關卡
    private bool bool_LowHp = false;    //調整殘血UI的透明度 
    private float flo_LowHpSpeed = 2.0f;//殘血UI閃爍的速度
    private float flo_MaxTime = 30.0f;  //遊戲總共有的時間
    private float flo_Currect_Time;     //遊戲目前所剩的時間

    private enum enum_Level
    {
        GameStart , 
        Level_01 , 
    }
    private enum_Level Enum_CurrectLevel; 

    public void Awake()
    {
        Obj_UiTime[0] = GameObject.Find("Canvas_Time");         //抓取UI時間的Canvas
        Obj_UiTime[1] = GameObject.Find("MaxTime");             //最大時間UI
        Obj_UiTime[2] = GameObject.Find("Currect_Time");        //目前時間UI

        Obj_UI[0] = GameObject.Find("Canvas_UI");               //UI畫面的Canvas
        Obj_UI[1] = GameObject.Find("Image_LowHp");             //殘血提醒
        flo_Currect_Time = flo_MaxTime;

        Obj_UiWifi[0] = GameObject.Find("UI_Camera_Phone");     //管理收訊好壞的介面 
         
    }

    public void Start()
    {
        Obj_UiWifi[0].SetActive(false);                         //開場關閉收訊UI
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
            }
        }
    }
}
