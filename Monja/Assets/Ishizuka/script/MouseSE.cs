using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseSE : MonoBehaviour
{
   
    //�}�E�X��UI�̏�ɏ�����特����
    void OnMouseEnter()
    {
        Debug.Log("abcd");
            GetComponent<AudioSource>().Play();  // ���ʉ���炷
    }
    void OnMouseExit()
    {
        Debug.Log("�}�E�X���I�u�W�F�N�g���痣��܂����B");
        
    }
}
