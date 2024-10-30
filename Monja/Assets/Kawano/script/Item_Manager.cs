using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Item_Manager : MonoBehaviour
{

    public IDictionary<string, bool> Item = new Dictionary<string, bool>();


    private void Awake()
    {
        DontDestroyOnLoad(this);

        //é´èëÇ…ÉLÅ[Çê›íË
        if (Item.ContainsKey("healdrink") == false)
        {
            Item.Add("healdrink", false);
            Item.Add("bowlingball", false);
            Item.Add("CDplayer", false);
            Item.Add("cd", false);
            Item.Add("radio", false);
            Item.Add("hourglass", false);
        }

    }

    public void Start()
    {
    }
}