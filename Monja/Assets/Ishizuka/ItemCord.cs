using UnityEngine;

public class ItemCord : MonoBehaviour
{
    private void Start()
    {
        // �Q�[���I�u�W�F�N�g�̖��O���w�肵�Ď擾
        GameObject myObject = GameObject.Find("y");

        // �擾�����Q�[���I�u�W�F�N�g�����݂��邩�m�F
        if (myObject != null)
        {
            // �擾�����Q�[���I�u�W�F�N�g�ɑ΂��鑀��������ōs��
            Debug.Log("�I�u�W�F�N�g����������܂����F" + myObject.name);
        }
        else
        {
            Debug.LogWarning("�I�u�W�F�N�g���F 'ObjectName'��������܂���");
        }
    }
}