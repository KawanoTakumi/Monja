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

    public void hit_se()
    {
        GetComponent<AudioSource>().Play();  // Œø‰Ê‰¹‚ð–Â‚ç‚·

    }
}