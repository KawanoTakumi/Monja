using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Item_SE : MonoBehaviour
{
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();//オーディオソース取得
    }

    public void hit_se()
    {
        GetComponent<AudioSource>().Play();  // 効果音を鳴らす
    }
}