using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseSE : MonoBehaviour
{
    private new AudioSource audio;
    public AudioSource button_Audio;//�{�^���p��SE
    public AudioClip Sound;
    bool first_hit = false;//�ŏ��ɃI�u�W�F�N�g�ɏ��������������������

    //�}�E�X��UI�̏�ɏ�����特����
    public void OnMouseEnter()
    {
        if (first_hit == false)
        {
            //Debug.Log("�}�E�X���I�u�W�F�N�g�ɏ���Ă��܂�");
            button_Audio.Play();  // ���ʉ���炷
            first_hit = true;
        }
    }
    //�}�E�X��UI���痣�ꂽ�Ƃ�
    public void OnMouseExit()
    {
        //Debug.Log("�}�E�X���I�u�W�F�N�g���痣��܂����B");
        first_hit = false;
    }
}