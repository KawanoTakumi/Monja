using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Cut_In : MonoBehaviour
{
    public GameObject Cut_Scene;//�J�b�g�V�[��
    public AudioSource Cut_In_SE;//�J�b�g�C���pSE
    public AudioClip clip;//���y�f�[�^
    public static bool first_flag = true;//����t���O
    public void Update()
    {
        //fairst_flag��false�̂Ƃ��A�J�b�g�V�[�����폜
        if (first_flag == false)
            Destroy(Cut_Scene);
    }
    //�J�b�g�C��
    public void Cut_In_Del()
    {
        if(first_flag == true)
        {
            Cut_Scene.SetActive(false);
            first_flag = false;
        }
    }
    //�ŏ��̃V�[���ȊO�ł̓J�b�g�V�[�����폜
    public void First_scene()
    {
        if(Enemy_controller.turn != 1)
        {
            Cut_Scene.SetActive(false);
        }
    }
    //�J�b�g�C���T�E���h�֐�
    public void Cut_In_Sound()
    {
        Cut_In_SE.PlayOneShot(clip);
    }
}