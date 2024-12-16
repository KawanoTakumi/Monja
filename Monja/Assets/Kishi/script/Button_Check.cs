using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button_Check : MonoBehaviour
{
    public static Button_Check instance1;
    public static Button_Check instance2;
    public static Button_Check instance3;
    public bool isTouched1;
    public bool isTouched2;
    public bool isTouched3;

    public void Awake()
    {
        //インスタンスがnullの時、インスタンスをtrueにする
        if(instance1 == null)
        {
            instance1 = this;
        }
        if (instance2 == null)
        {
            instance2 = this;
        }
        if (instance3 == null)
        {
            instance3 = this;
        }
    }
    void Start()
    {
        isTouched1 = false;
        isTouched2 = false;
        isTouched3 = false;
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