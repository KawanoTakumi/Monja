using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpItem : MonoBehaviour
{
    public Dictionary item;
    public Sprite sprite;
    // Start is called before the first frame update
    void Start()
    {
        //設定したアイコンを表示させる
        sprite = GetComponent<Sprite>();
    }

    // Update is called once per frame
    void Update()
    {
        Inventry.instance.Add(item);
        Destroy(gameObject);
    }
}