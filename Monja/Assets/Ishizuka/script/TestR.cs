using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestR : MonoBehaviour
{
    [SerializeField] public GameObject bowlingball;
    [SerializeField] public GameObject cd;
    [SerializeField] public GameObject cdplayer;
    [SerializeField] public GameObject radio;
    [SerializeField] public GameObject healdrink;
    [SerializeField] public GameObject hourglass;
    public Button button;

    

    // Start is called before the first frame update
    void Start()
    {
        bowlingball = GameObject.FindWithTag("bowlingball");
        if (bowlingball == GameObject.FindWithTag("bowlingball"))
        {
           // bowlingball.SetActive(true);
        }
        cd = GameObject.FindWithTag("cd");
        //cd.SetActive(true);

        cdplayer = GameObject.FindWithTag("CDplayer");
        //cdplayer.SetActive(true);

        radio = GameObject.FindWithTag("radio");
        //radio.SetActive(true);

        healdrink = GameObject.FindWithTag("healdrink");
        //healdrink.SetActive(true);

        hourglass = GameObject.FindWithTag("hourglass");
        //hourglass.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
