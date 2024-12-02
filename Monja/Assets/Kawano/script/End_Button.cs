using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class End_Button : MonoBehaviour
{
    public void End_button()
    {
        Application.Quit();
    }
    public void Update()
    {
        if(Input.GetKey(KeyCode.Escape))
        {

        }
    }
}
