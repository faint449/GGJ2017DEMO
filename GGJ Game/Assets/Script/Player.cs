using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
    public Rigidbody2D Rigidbody2D_Player;  //角色剛體
    public GameObject Obj_Background;       //背景
    public GameObject[] Obj_Wifi = new GameObject[6]; //關於Wifi的所有物件
    
    private bool bool_GetWifi = false;      //玩家是否取得了Wifi
    private float flo_MoveSpeed = 10;       //移動速度
    private float flo_Distance;             //角色與Wifi的距離
    private float[] flo_WifiDistance = new float[5]; //Wifi訊號強度距離
    private float flo_Width = 31.0f;        //最大寬度
    private float flo_High = 15.0f;         //最大長度

    public void Awake()
    {
        Rigidbody2D_Player = this.GetComponent<Rigidbody2D>();
        Obj_Background = GameObject.Find("Background"); 

        Obj_Wifi[0] = GameObject.Find("Wifi");        //Wifi訊號位置
        Obj_Wifi[1] = GameObject.Find("Loading");     //判斷是否可以顯示地圖
        Obj_Wifi[2] = GameObject.Find("WifiSignal3"); //Wifi訊號滿格
        Obj_Wifi[3] = GameObject.Find("WifiSignal2"); //Wifi訊號三格
        Obj_Wifi[4] = GameObject.Find("WifiSignal1"); //Wifi訊號兩格
        Obj_Wifi[5] = GameObject.Find("WifiSignalDot"); //Wifi訊號一格


        flo_WifiDistance[0] = 5.0f;        //訊號滿格，可開啟地圖
        flo_WifiDistance[1] = 10.0f;        //訊號三格，快接近訊號區
        flo_WifiDistance[2] = 18.0f;        //訊號二格，收訊不好
        flo_WifiDistance[3] = 24.0f;        //訊號一格，收訊很不好
        flo_WifiDistance[4] = 30.0f;        //訊號零格，在海外
    }
   
    
    public void Update()
    {
        Rigidbody2D_Player.velocity = new Vector2(Input.GetAxisRaw("Horizontal") , Input.GetAxisRaw("Vertical")) * flo_MoveSpeed;
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
            this.transform.position = new Vector3(this.transform.position.x , flo_High, this.transform.position.z);
        }
        else if (this.transform.position.y < -flo_High)
        {
            this.transform.position = new Vector3(this.transform.position.x, -flo_High, this.transform.position.z);
        }

        flo_Distance = Vector3.Distance(this.transform.position, Obj_Wifi[0].transform.position);           //取的玩家與Wifi相差的距離
        Fn_Wifi(flo_Distance , flo_WifiDistance , Obj_Wifi);            //相差的距離 、 Wifi判斷訊號的距離 、 需要開啟或關閉的物件

        if (bool_GetWifi)
        {
            Obj_Wifi[1].SetActive(false);           //已經獲得訊號，關閉訊號不好等待的UI
        }
        else
        {
            Obj_Wifi[1].SetActive(true);            //沒有得到訊號，開啟訊號不好等待的畫面
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Wifi")
        {
            Debug.Log("玩家取得了Wifi，出口開啟"); 
            bool_GetWifi = true;        //玩家已經取得Wifi
            /*Obj_Background.GetComponent<SpriteRenderer>().enabled = false;
            Obj_Background.GetComponent<Renderer>().material = null; */
        }
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
}
