using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Slider_Manager : MonoBehaviour
{
    public Slider obj;
    public static float Music_Volume;

    // Start is called before the first frame update
    void Start()
    {
        //•Û‚µ‚½”’l‚ğ“Ç‚İ‚Ş
        obj.value = Music_Volume;
    }

    // Update is called once per frame
    void Update()
    {
        Music_Volume = obj.value;
    }
}
