using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour
{
    public void hit_se()
    {
        GetComponent<AudioSource>().Play();  // 効果音を鳴らす

    }
}