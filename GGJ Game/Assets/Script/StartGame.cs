using UnityEngine;
using System.Collections;
using System;
using UnityEngine.Events; 

public class StartGame : MonoBehaviour {
    public GameObject[] Obj_StartUI = new GameObject[4];
    public GameObject[] Obj_Introduction = new GameObject[2];
    public UnityEvent OnStart; 

    private enum Enum_StateScenes
    {
        Main , 
        GameStart ,
        GameIntroduction , 
        GameEnd , 
    }
    private Enum_StateScenes Enum_CurrectState;
    
    public void Awake()
    {
        Obj_StartUI[0] = GameObject.Find("Canvas_StartUI");
        Obj_StartUI[1] = GameObject.Find("Button_StartGame");
        Obj_StartUI[2] = GameObject.Find("Button_GameIntroduction");
        Obj_StartUI[3] = GameObject.Find("Button_EndGame");

        Obj_Introduction[0] = GameObject.Find("Canvas_Introduction");           //遊戲介紹Canvas
        Obj_Introduction[1] = GameObject.Find("Text_Introduction");             //遊戲介紹
        this.OnStart.Invoke();
    }
    

    public void Update()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked; 

        if (Enum_CurrectState == Enum_StateScenes.Main)
        {
            Obj_StartUI[0].GetComponent<Canvas>().enabled = true; 
        }
        else
        {
            this.OnStart.Invoke(); 
            Obj_StartUI[0].GetComponent<Canvas>().enabled = false;
        }

        if (Enum_CurrectState == Enum_StateScenes.GameStart)
        {
            Application.LoadLevel("test"); 
        }

        if (Enum_CurrectState == Enum_StateScenes.GameIntroduction)
        {
            Obj_Introduction[0].GetComponent<Canvas>().enabled = true;

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Enum_CurrectState = Enum_StateScenes.Main; 
            }
        }
        else
        {
            Obj_Introduction[0].GetComponent<Canvas>().enabled = false;
        }

        if (Enum_CurrectState == Enum_StateScenes.GameEnd)
        {
            Application.Quit(); 
        }
    }

    public void Fn_Start()
    {
        Enum_CurrectState = Enum_StateScenes.GameStart; 
    }

    public void Fn_Introduction()
    {
        Enum_CurrectState = Enum_StateScenes.GameIntroduction;
    }

    public void Fn_End()
    {
        Enum_CurrectState = Enum_StateScenes.GameEnd;
    }
}

