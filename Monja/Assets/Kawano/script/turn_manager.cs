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
    public bool turn = true;//turn == true�̎��v���C���[�̃^�[���Afalse�̎��G�̃^�[��
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
        Debug.Log("�o�g���J�n");
        while(true)
        {
            //�v���C���[�̃^�[��
            yield return new WaitForSeconds(30f);
            Changeturn(BattleStatus.Player_Select);
            //�v���C���[�̍U��
            yield return new WaitForSeconds(30f);
            Changeturn(BattleStatus.Player_Attack);
            //�G�l�~�[�̃^�[��
            yield return new WaitForSeconds(30f);
            Changeturn(BattleStatus.Enmey_Select);
            //�G�l�~�[�̍U��
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
                Debug.Log("�v���C���[�̃^�[��");
                break;
            case BattleStatus.Player_Attack:
                Debug.Log("�v���C���[�̍U��");
                Debug.Log("Player��Enemy��" + damage_Calculate.Enemy_Damage + "�_���[�W��^����");
                break;
            case BattleStatus.Enmey_Select:
                Debug.Log("�G�l�~�[�̃^�[��");
                break;
            case BattleStatus.Enmey_Attack:
                Debug.Log("�G�l�~�[�̍U��");
                Debug.Log("Enemy��Player��" + damage_Calculate.Player_Damage + "�_���[�W��^����");
                break;
        }
    }
}