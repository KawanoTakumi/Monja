using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour
{
    public void hit_se()
    {
        GetComponent<AudioSource>().Play();  // ���ʉ���炷

    }
}