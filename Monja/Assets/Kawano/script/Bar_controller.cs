using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bar_controller : MonoBehaviour
{
    public PlayerController playerController;
    public Slider HP_Bar;
    public Slider MP_Bar;

    // Start is called before the first frame update
    void Start()
    {
        HP_Bar.value = 100;
        MP_Bar.value = 100;
    }

    // Update is called once per frame
    void Update()
    {
        HP_Bar.value = playerController.HP;
        MP_Bar.value = playerController.MP;
    }
}
