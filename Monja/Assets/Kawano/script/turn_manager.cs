using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turn_manager : MonoBehaviour
{
    public bool turn = true;
    public PlayerController playerController;
    // Start is called before the first frame update
    void Start()
    {
        GameObject player = GameObject.Find("Player");
        playerController = player.GetComponent<PlayerController>();
        Debug.Log(playerController);

        //EnemyController enemyController = GetComponent<EnemyController>();
    }

    // Update is called once per frame
    void Update()
    {

        
        if (turn == true)
        {
            playerController.Player_turn = true;
        }
        else
        {

        }
    }
}