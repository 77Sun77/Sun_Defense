using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseClick : MonoBehaviour
{
    AudioSource click;
    void Start()
    {
        click = GetComponent<AudioSource>();
    }

    
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            click.Play();
        }

        if(PlayerPrefs.GetString("Effect") == "On")
        {
            click.volume = 0.3f;
        }
        else
        {
            click.volume = 0;
        }
    }
}
