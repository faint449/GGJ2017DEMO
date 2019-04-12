using UnityEngine;
using System.Collections;
using UnityEngine.UI; 

public class Player : MonoBehaviour {
    public Rigidbody2D Rigidbody2D_Player;  //角色剛體
    public GameObject Obj_WifiEffect;       //載入Wifi等待時，所產生的特效物件
    public GameObject Obj_Exit;            //是否開啟出口，當載入Wifi成功時開啟
    public GameObject[] Obj_Wifi = new GameObject[6]; //關於Wifi的所有物件
    public GameObject[] Obj_ScreenOver = new GameObject[2];     //遊戲結束，畫面總結 (成功 、 失敗)
    public UI_Script UseUiScript;           //抓取UI腳本

    private bool bool_OverLevel = false;    //通過關卡
    private bool bool_DownloadOver = false; //是否成功載入Wifi
    private bool bool_StartDownload = false;//是否開始載入
    private float flo_DownloadTime = 5.0f;  //Wifi載入所需的時間
    private float flo_MoveSpeed = 10;       //移動速度
    private float flo_Distance;             //角色與Wifi的距離
    private float[] flo_WifiDistance = new float[5]; //Wifi訊號強度距離
    private float flo_Width = 31.0f;        //最大寬度
    private float flo_High = 15.0f;         //最大長度
    
    public void Awake()
    {
        UseUiScript = GameObject.FindObjectOfType<UI_Script>(); 
        Rigidbody2D_Player = this.GetComponent<Rigidbody2D>();

        Obj_Wifi[0] = GameObject.Find("Wifi");        //Wifi訊號位置
        Obj_Wifi[1] = GameObject.Find("Loading");     //判斷是否可以顯示地圖
        Obj_Wifi[2] = GameObject.Find("WifiSignal3"); //Wifi訊號滿格
        Obj_Wifi[3] = GameObject.Find("WifiSignal2"); //Wifi訊號三格
        Obj_Wifi[4] = GameObject.Find("WifiSignal1"); //Wifi訊號兩格
        Obj_Wifi[5] = GameObject.Find("WifiSignalDot"); //Wifi訊號一格

        Obj_WifiEffect = GameObject.Find("WifiOK");   //Wifi載入的特效物件

        Obj_Exit = GameObject.Find("UI_Win") ;          //抓取出口的物件
        Obj_Exit.SetActive(false);                      //出口關閉 

        Obj_ScreenOver[0] = GameObject.Find("UI_Camera_Lose");      //遊戲失敗UI畫面 
        Obj_ScreenOver[0].SetActive(false);                         //暫時關閉遊戲失敗UI

        Obj_ScreenOver[1] = GameObject.Find("UI_Camera_Win");       //遊戲成功UI畫面
        Obj_ScreenOver[1].GetComponent<Canvas>().enabled = false;   //暫時關閉遊戲成功UI
        Obj_ScreenOver[1].transform.GetChild(0).gameObject.SetActive(false); 
    }

    public void Start()
    {
        flo_WifiDistance[0] = 5.0f;         //訊號滿格，可開啟地圖
        flo_WifiDistance[1] = 10.0f;        //訊號三格，快接近訊號區
        flo_WifiDistance[2] = 18.0f;        //訊號二格，收訊不好
        flo_WifiDistance[3] = 24.0f;        //訊號一格，收訊很不好
        flo_WifiDistance[4] = 30.0f;        //訊號零格，在海外

        Obj_WifiEffect.SetActive(false);    //關閉Wifi載入的特效物件
        Obj_Exit.SetActive(false);          //關閉 Win 粒子特效

        UI_Script.Enum_CurrectLevel = UI_Script.enum_Level.Level_01; 
    }


    public void FixedUpdate()
    {
        if (UI_Script.Enum_CurrectLevel != UI_Script.enum_Level.GameEnd)
        {
            Rigidbody2D_Player.velocity = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")) * flo_MoveSpeed;
            if (this.transform.position.x >= flo_Width)
            {
                this.transform.position = new Vector3(flo_Width, this.transform.position.y, this.transform.position.z);
            }
            else if (this.transform.position.x < -flo_Width)
            {
                this.transform.position = new Vector3(-flo_Width, this.transform.position.y, this.transform.position.z);
            }

            if (this.transform.position.y >= flo_High)
            {
                this.transform.position = new Vector3(this.transform.position.x, flo_High, this.transform.position.z);
            }
            else if (this.transform.position.y < -flo_High)
            {
                this.transform.position = new Vector3(this.transform.position.x, -flo_High, this.transform.position.z);
            }

            if (Obj_Wifi[0] != null)
            {
                flo_Distance = Vector3.Distance(this.transform.position, Obj_Wifi[0].transform.position);           //取的玩家與Wifi相差的距離
                Fn_Wifi(flo_Distance, flo_WifiDistance, Obj_Wifi);            //相差的距離 、 Wifi判斷訊號的距離 、 需要開啟或關閉的物件
            }


            if (bool_DownloadOver)
            {
                Obj_Wifi[1].SetActive(false);           //已經獲得訊號，關閉訊號不好等待的UI
            }
            else
            {
                Obj_Wifi[1].SetActive(true);            //沒有得到訊號，開啟訊號不好等待的畫面
            }


            if (bool_StartDownload)                           //載入Wifi階段
            {
                Obj_WifiEffect.SetActive(true);         //開啟Wifi載入的特效物件
                flo_DownloadTime -= Time.deltaTime;
                Vector3 Vector3_ControlPosition = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0);
                if (Vector3_ControlPosition.sqrMagnitude > 0.001f || bool_DownloadOver)     //玩家移動了
                {
                    flo_DownloadTime = 5.0f;              //玩家移動，重新計算時間
                    Debug.Log("載入失敗");
                }

                if (flo_DownloadTime <= 0.0f)
                {
                    Obj_Exit.SetActive(true);
                    Obj_WifiEffect.SetActive(false);    //關閉Wifi載入的特效物件
                    bool_StartDownload = false;
                    Debug.Log("載入成功");
                    bool_DownloadOver = true;           //載入成功
                    Destroy(Obj_Wifi[0]);               //刪除Wifi   
                }
            }
        }
        else
        {
            Rigidbody2D_Player.velocity = Vector2.zero;
            flo_MoveSpeed = 0.0f;
            if (bool_DownloadOver == false || !bool_OverLevel)      //沒有載入Wifi或到達出口，算失敗
            {
                Obj_ScreenOver[0].SetActive(true);      //暫時關閉遊戲失敗UI
            }
        }
        
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Wifi")
        {
            StartCoroutine(StartDownload());  
        }

        if (other.gameObject.name == "UI_Win" && bool_DownloadOver)           //碰到勝利 Win 的範圍且載入成功，玩家贏得勝利
        {
            Obj_ScreenOver[1].GetComponent<Canvas>().enabled = true;          //暫時關閉遊戲成功UI
            Obj_ScreenOver[1].transform.GetChild(0).gameObject.SetActive(true);//開啟 Win 粒子特效
            bool_OverLevel = true;                                              //通過關卡
            UI_Script.Enum_CurrectLevel = UI_Script.enum_Level.GameEnd;         //遊戲結束
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.name == "Wifi")
        {
            bool_StartDownload = false;
            Obj_WifiEffect.SetActive(false);    //關閉Wifi載入的特效物件
        }
    }

    IEnumerator StartDownload()
    {
        Debug.Log("開始載入");
        yield return new WaitForSeconds(0.3f);
        bool_StartDownload = true;  //開始載入
    }

    public void Fn_Wifi(float flo_Distance , float[] flo_Value , GameObject[] Obj_WifiO)
    {

        if (flo_Distance <= flo_Value[1] && flo_Distance > flo_Value[0])        //訊號三格，差點滿格
        {
            Obj_Wifi[2].SetActive(true);     
        }
        else if (flo_Distance > flo_Value[1])
        {
            Obj_Wifi[2].SetActive(false);
        }

        if (flo_Distance <= flo_Value[2] && flo_Distance > flo_Value[1])        //訊號兩格
        {
            Obj_Wifi[3].SetActive(true);
        }
        else if (flo_Distance > flo_Value[2])
        {
            Obj_Wifi[3].SetActive(false);
        }

        if (flo_Distance <= flo_Value[3] && flo_Distance > flo_Value[2])        //訊號一格
        {
            Obj_Wifi[4].SetActive(true);
        }
        else if (flo_Distance > flo_Value[3])
        {
            Obj_Wifi[4].SetActive(false);
        }

        if (flo_Distance <= flo_Value[4] && flo_Distance > flo_Value[3])        //訊號零格
        {
            Obj_Wifi[5].SetActive(true);
        }
        else if (flo_Distance > flo_Value[4])
        {
            Obj_Wifi[5].SetActive(false);
        }
    }

    public void Fn_Return()             //重新開始
    {
        Application.LoadLevel(0); 
    }
}
