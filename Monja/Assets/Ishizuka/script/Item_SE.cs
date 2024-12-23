using UnityEngine;


public class Item_SE : MonoBehaviour
{
    private AudioSource audioSource;

    private void Start()
    {
        //オーディオソース取得
        audioSource = GetComponent<AudioSource>();
    }

    public void hit_se()
    {
        // 効果音を鳴らす
        GetComponent<AudioSource>().Play();  
    }
}