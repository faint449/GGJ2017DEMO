using UnityEngine;
using System.Collections;
using System;
using UnityEngine.Events;
using UnityEngine.UI; 

public class StartGame : MonoBehaviour {
    public Music Music_Script; 
    
    public void Awake()
    {
        Music_Script = GameObject.FindObjectOfType<Music>();
    }

    public void Start()
    {
        
        Music_Script.AudioSource_Music.GetComponent<AudioSource>().clip = Music_Script.List_Audio[0];
        Music_Script.AudioSource_Music.GetComponent<AudioSource>().Play();
    }
    
    public void Fn_StartGame()
    {
        Application.LoadLevel("test"); 
    }

    public void Fn_EndGame()
    {
        Application.Quit(); 
    }
}

