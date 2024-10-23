using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button_Check : MonoBehaviour
{
    public static Button_Check instance;
    public bool isTouched;

    public void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }
    void Start()
    {
        isTouched = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void button_check()
    {
        isTouched = true;
    }
}
