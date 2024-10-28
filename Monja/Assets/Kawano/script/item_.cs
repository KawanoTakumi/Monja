using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class item_ : MonoBehaviour
{
    public Item_Manager item;
    public RawImage image;
    // Start is called before the first frame update
    void Start()
    {
        item = GetComponent<Item_Manager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(item.radio == true)
        {
            
        }
    }
}
