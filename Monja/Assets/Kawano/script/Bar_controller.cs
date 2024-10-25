using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bar_controller : MonoBehaviour
{
    public PlayerController playerController;
    public Enemy_controller enemy_Controller;
    public Slider HP_Bar;
    public Slider MP_Bar;
    public Slider Enemy_HP_Bar;

    // Start is called before the first frame update
    void Start()
    {
        HP_Bar.value = 100;
        MP_Bar.value = 100;
        Enemy_HP_Bar.value = 150;
    }

    // Update is called once per frame
    void Update()
    {
        HP_Bar.value = playerController.HP;
        MP_Bar.value = playerController.MP;
        Enemy_HP_Bar.value = enemy_Controller.HP;
    }
}
