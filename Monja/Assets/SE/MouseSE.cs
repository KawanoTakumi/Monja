using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MouseSE : MonoBehaviour
{
    //private new AudioSource audio;
    GameObject Obj;
    AudioSource Button_Audio;//�{�^���p��SE
    bool First_hit = false;//�ŏ��ɃI�u�W�F�N�g�ɏ��������������������

    public void Start()
    {
        //Sound = GetComponent<AudioClip>();
        Obj = GameObject.Find("button_audio");
        Button_Audio = Obj.GetComponent<AudioSource>();
    }

    //�}�E�X��UI�̏�ɏ�����特����
    public void OnMouseEnter()
    {
        if (First_hit == false)
        {
            //Debug.Log("�}�E�X���I�u�W�F�N�g�ɏ���Ă��܂�");
            Button_Audio.Play();
            First_hit = true;//��x�����炷
        }
    }
    //�}�E�X��UI���痣�ꂽ�Ƃ�
    public void OnMouseExit()
    {
        //Debug.Log("�}�E�X���I�u�W�F�N�g���痣��܂����B");
        First_hit = false;
    }
}