using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Setting : MonoBehaviour
{
    [Header("Sound")]
    public Image soundOn;
    public Image soundOff;
    public Sprite checkImage;
    public Sprite offImage;
    public static bool isSound;

    [Header("EffectSound")]
    public Image effectOn;
    public Image effectOff;
    public Sprite effectCheckImage;
    public Sprite effectOffImage;
    public static bool isEffect;
    void Start()
    {
        if(PlayerPrefs.GetString("Sound") == "On")
        {
            isSound = true;
            SoundOn();
        }
        else
        {
            isSound = false;
            SoundOff();
        }

        if (PlayerPrefs.GetString("Effect") == "On")
        {
            isEffect = true;
            EffectOn();
        }
        else
        {
            isEffect = false;
            EffectOff();
        }
    }

    public void SoundOn()
    {
        isSound = true;
        soundOn.sprite = checkImage;
        soundOff.sprite = offImage;
        PlayerPrefs.SetString("Sound", "On");
    }
    public void SoundOff()
    {
        isSound = false;
        soundOn.sprite = offImage;
        soundOff.sprite = checkImage;
        PlayerPrefs.SetString("Sound", "Off");
    }

    public void EffectOn()
    {
        isEffect = true;
        effectOn.sprite = effectCheckImage;
        effectOff.sprite = effectOffImage;
        PlayerPrefs.SetString("Effect", "On");
    }
    public void EffectOff()
    {
        isEffect = false;
        effectOn.sprite = effectOffImage;
        effectOff.sprite = effectCheckImage;
        PlayerPrefs.SetString("Effect", "Off");
    }
    public void ResetGameData()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene("Start");
    }
}
