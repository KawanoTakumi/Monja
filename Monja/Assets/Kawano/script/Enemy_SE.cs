using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_SE : MonoBehaviour
{
    public AudioSource SE_Source;
    [SerializeField] AudioClip se_1;
    [SerializeField] AudioClip se_2;
    [SerializeField] AudioClip se_3;

    public void SE_Monster(int num)
    {
        switch (num)
        {
            case 1:SE_Source.PlayOneShot(se_1);break;
            case 2:SE_Source.PlayOneShot(se_2);break;
            case 3:SE_Source.PlayOneShot(se_3);break;
        }
    }
    public void SE_Del()
    {
        SE_Source.Stop();
    }
}