using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_controller : MonoBehaviour
{
    //player status
    public int HP = 100;
    public int MP = 100;
    public int Attack = 50;
    public int Armor = 50;
    public int magic = 50;
    public int magic_armor = 50;
    // Start is called before the first frame update
    void Start()
    {
        HP = 100; MP = 100; Attack = 50; Armor = 50; magic = 50;magic_armor = 50;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
