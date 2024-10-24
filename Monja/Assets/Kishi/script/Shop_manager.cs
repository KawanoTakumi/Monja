using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class Shop_manager : MonoBehaviour
{
    public RawImage img;
    public List<Texture> texture_list = new List<Texture>();
    void Start()
    {
        img = GameObject.Find("DisplayImage").GetComponent<RawImage>();
        read_img(6);

       


    }

    // Update is called once per frame
    void Update()
    {
        ChangeImage();
    }
    public void read_img(int n)
    {
        Texture tmp;
        for(int i=1;i<n+1;i++)
        {
            tmp = Resources.Load("img/" + i) as Texture;
            texture_list.Add(tmp);
        }
    }
     void ChangeImage()
    {
        int random = Random.Range(1, texture_list.Count);

        Debug.Log("ƒ‰ƒ“ƒ_ƒ€’l‚Í" + random);

        img.texture = texture_list[random];
    }
}
