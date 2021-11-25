using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Money : MonoBehaviour
{
    public static int money;
    Text text;
    void Start()
    {
        text = GetComponent<Text>();
        money = PlayerPrefs.GetInt("money");
    }

    // Update is called once per frame
    void Update()
    {
        text.text = money.ToString();
    }
}
