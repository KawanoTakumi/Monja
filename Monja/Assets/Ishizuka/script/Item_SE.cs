using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Item_SE : MonoBehaviour
{
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        //if()
        //{
          
        //}
        //else
        //{
        
        //}
    }

    public void hit_se()
    {
        GetComponent<AudioSource>().Play();  // ���ʉ���炷

    }
}