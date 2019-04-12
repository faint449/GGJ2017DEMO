using UnityEngine;
using System.Collections;
using System.Collections.Generic; 

public class Music : MonoBehaviour {
    public AudioSource AudioSource_Music;
    public List<AudioClip> List_Audio = new List<AudioClip>();

    public void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        AudioSource_Music = this.GetComponent<AudioSource>();
        List_Audio.Add(Resources.Load<AudioClip>("Music/Fortaleza"));
        List_Audio.Add(Resources.Load<AudioClip>("Music/Lovers_Squared"));
    }

    public void Start()
    {
       
    }
}
