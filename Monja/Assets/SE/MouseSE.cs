using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MouseSE : MonoBehaviour
{
    //private new AudioSource audio;
    GameObject obj;
    AudioSource button_Audio;//�{�^���p��SE
    AudioClip Sound;
    bool first_hit = false;//�ŏ��ɃI�u�W�F�N�g�ɏ��������������������

    public void Start()
    {
        //Sound = GetComponent<AudioClip>();
        obj = GameObject.Find("button_audio");
        button_Audio = obj.GetComponent<AudioSource>();
    }

    //�}�E�X��UI�̏�ɏ�����特����
    public void OnMouseEnter()
    {
        if (first_hit == false)
        {
            //Debug.Log("�}�E�X���I�u�W�F�N�g�ɏ���Ă��܂�");
            button_Audio.Play();
            first_hit = true;//��x�����炷
        }
    }
    //�}�E�X��UI���痣�ꂽ�Ƃ�
    public void OnMouseExit()
    {
        //Debug.Log("�}�E�X���I�u�W�F�N�g���痣��܂����B");
        first_hit = false;
    }
}