using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Item_Manager : MonoBehaviour
{
    public Button button;
    public bool bowlingball;
    public bool radio;

    // Start is called before the first frame update
    void Start()
    {
        if (button == GameObject.FindWithTag("bowlingball"))
        {
            bowlingball = true;
        }
        else if (button == GameObject.FindWithTag("radio"))
        {
            radio = true;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
