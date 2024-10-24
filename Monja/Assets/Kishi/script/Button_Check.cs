using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button_Check : MonoBehaviour
{
    public static Button_Check instance;
    public bool isTouched1;
    public bool isTouched2;
    public bool isTouched3;

    public void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }
    void Start()
    {
        isTouched1 = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void button_check1()
    {
        isTouched1 = true;
    }

    public void button_checks2()
    {
        isTouched2 = true;
    }

    public void button_checks3()
    {
        isTouched3 = true;
    }


}
