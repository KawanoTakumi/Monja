using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turn_manager : MonoBehaviour
{
    public bool turn = true;
    PlayerController playerController;
    Enemy_controller enemy_Controller;
    // Start is called before the first frame update
    void Start()
    {
        GameObject player = GameObject.Find("Player");
        playerController = player.GetComponent<PlayerController>();
        GameObject enemy = GameObject.Find("Monster");
        enemy_Controller = enemy.GetComponent<Enemy_controller>();
    }

    // Update is called once per frame
    void Update()
    {
        if (turn == true)
        {
            Debug.Log("プレイヤーのターン");
            playerController.Player_turn = true;
        }
        else
        {
            Debug.Log("エネミーのターン");
            enemy_Controller.Enemy_turn = true;
        }
    }
}