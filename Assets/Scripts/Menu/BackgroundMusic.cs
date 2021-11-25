using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
    AudioSource bgm;
    void Start()
    {
        bgm = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (PlayerPrefs.GetString("Sound") == "On")
        {
            bgm.volume = 0.3f;
        }
        else
        {
            bgm.volume = 0;
        }
    }
}
