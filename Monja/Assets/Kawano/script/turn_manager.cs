using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turn_manager : MonoBehaviour
{
    enum BattleStatus
    {
        Player_Select,
        Player_Attack,
        Enmey_Select,
        Enmey_Attack,
    }
    BattleStatus status = BattleStatus.Player_Select;
    Damage_calculate damage_Calculate;
    public bool turn = true;//turn == trueの時プレイヤーのターン、falseの時敵のターン
    // Start is called before the first frame update
    void Start()
    {
        damage_Calculate = GetComponent<Damage_calculate>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator Battle()
    {
        Debug.Log("バトル開始");
        while(true)
        {
            //プレイヤーのターン
            yield return new WaitForSeconds(30f);
            Changeturn(BattleStatus.Player_Select);
            //プレイヤーの攻撃
            yield return new WaitForSeconds(30f);
            Changeturn(BattleStatus.Player_Attack);
            //エネミーのターン
            yield return new WaitForSeconds(30f);
            Changeturn(BattleStatus.Enmey_Select);
            //エネミーの攻撃
            yield return new WaitForSeconds(30f);
            Changeturn(BattleStatus.Enmey_Attack);

        }
    }

    void Changeturn(BattleStatus battleStatus)
    {
        status = battleStatus;
        switch (status)
        {
            case BattleStatus.Player_Select:
                Debug.Log("プレイヤーのターン");
                break;
            case BattleStatus.Player_Attack:
                Debug.Log("プレイヤーの攻撃");
                Debug.Log("PlayerはEnemyに" + damage_Calculate.Enemy_Damage + "ダメージを与えた");
                break;
            case BattleStatus.Enmey_Select:
                Debug.Log("エネミーのターン");
                break;
            case BattleStatus.Enmey_Attack:
                Debug.Log("エネミーの攻撃");
                Debug.Log("EnemyはPlayerに" + damage_Calculate.Player_Damage + "ダメージを与えた");
                break;
        }
    }
}