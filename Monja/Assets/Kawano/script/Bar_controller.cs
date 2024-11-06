using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bar_controller : MonoBehaviour
{
    public Slider HP_Bar;
    public Slider MP_Bar;
    public Slider Enemy_HP_Bar;

    // Start is called before the first frame update
    void Start()
    {
        HP_Bar.value = PlayerController.HP_max;
        HP_Bar.maxValue = PlayerController.HP_max;
        MP_Bar.value = PlayerController.MP_max;
        MP_Bar.maxValue = PlayerController.MP_max;
        Enemy_HP_Bar.maxValue = Enemy_controller.HP_MAX;
        // Enemy_HP_Bar.value = Enemy_controller.HP;
        //Enemy_HP_Bar.maxValue = Enemy_controller.HP;
    }

    // Update is called once per frame
    void Update()
    {
        HP_Bar.value = PlayerController.HP;
        MP_Bar.value = PlayerController.MP;
        Enemy_HP_Bar.value = Enemy_controller.HP;

    }
}