using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Cut_In : MonoBehaviour
{
    public GameObject Cut_Scene;
    public AudioSource Cut_In_SE;//�J�b�g�C���pSE
    public AudioClip clip;
    public static bool first_flag = true;//����̂ݍĐ�

    public void Update()
    {
        if (first_flag == false)
            Destroy(Cut_Scene);
    }

    public void Cut_In_Del()
    {
        if(first_flag == true)
        {
            Cut_Scene.SetActive(false);
            first_flag = false;
        }
    }
    public void first_scene()
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