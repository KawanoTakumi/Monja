using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Cut_In : MonoBehaviour
{
    public GameObject Cut_scene;            //�J�b�g�V�[��
    public AudioSource Cut_in_SE;           //�J�b�g�C���pSE
    public AudioClip Clip;                  //�I�[�f�B�I�N���b�v
    public static bool FIRST_FLAG = true;   //����t���O

    //�A�b�v�f�[�g���\�b�h
    //�����E�E�E��x�Đ����ꂽ��J�b�g�V�[�����폜
    public void Update()
    {
        //����t���O��false�̎��A�J�b�g�C�����Đ����Ȃ�
        if (FIRST_FLAG == false)
            Destroy(Cut_scene);
    }
    //�J�b�g�C���폜���\�b�h
    public void Cut_In_Del()
    {
        if(FIRST_FLAG == true)
        {
            Cut_scene.SetActive(false);
            FIRST_FLAG = false;
        }
    }
    //�ŏ��̃V�[���ȊO�ł̓J�b�g�V�[�����폜
    public void First_scene()
    {
        if(Enemy_controller.turn != 1)
        {
            Cut_scene.SetActive(false);
        }
    }
    //�J�b�g�C���T�E���h�֐�
    public void Cut_In_Sound()
    {
        Cut_in_SE.PlayOneShot(Clip);//�N���b�v���Đ�
    }
}