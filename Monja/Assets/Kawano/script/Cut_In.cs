using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Cut_In : MonoBehaviour
{
    public GameObject Cut_Scene; 
    public void Cut_In_Del()
    {
        
        Cut_Scene.SetActive(false);
    }
    public void first_scene()
    {
        if(Item_Power.start_cnt == false)
        {
            Cut_Scene.SetActive(false);
        }
    }
}