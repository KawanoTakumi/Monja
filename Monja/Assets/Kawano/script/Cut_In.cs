using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Cut_In : MonoBehaviour
{
    public GameObject Cut_Scene;
    public static bool first_flag = true;//‰‰ñ‚Ì‚İÄ¶

    public void Update()
    {
        if (first_flag == false)
            Destroy(Cut_Scene);
    }

    public void Cut_In_Del()
    {
        if(first_flag == true)
        {
            Cut_Scene.SetActive(false);
            first_flag = false;
        }
    }
    public void first_scene()
    {
        if(Item_Power.start_cnt == false)
        {
            Cut_Scene.SetActive(false);
        }
    }
}