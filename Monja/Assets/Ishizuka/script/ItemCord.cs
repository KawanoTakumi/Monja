using UnityEngine;

public class GameObjectFinder : MonoBehaviour
{
    private void Start()
    {
        // �^�O���w�肵�ăQ�[���I�u�W�F�N�g���擾
        GameObject[] enemyObjects = GameObject.FindGameObjectsWithTag("Enemy");

        // �擾�����Q�[���I�u�W�F�N�g�ɑ΂��鑀������[�v�ōs��
        foreach (GameObject enemy in enemyObjects)
        {
            Debug.Log("Enemy�^�O���������I�u�W�F�N�g���F" + enemy.name);
        }
    }
}