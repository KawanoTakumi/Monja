using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class Shop_manager: MonoBehaviour
{
    //表示させる画像オブジェクトのRaw画像コンポーネント
    public RawImage img1;
    public RawImage img2;
    public RawImage img3;

    //bool stop1 = false;
    //bool stop2 = false;
    //bool stop3 = false;
    //bool restart = false;

    //表示させる画像リスト
    public List<Texture> texture_list = new List<Texture>();

    // Start is called before the first frame update
    void Start()
    {

        img1 = GameObject.Find("DisplayImage").GetComponent<RawImage>();
        img2 = GameObject.Find("DisplayImage2").GetComponent<RawImage>();
        img3 = GameObject.Find("DisplayImage3").GetComponent<RawImage>();
        //1～10の画像を読み込む
        read_img(6);
        ChangeImage1();
        ChangeImage2();
        ChangeImage3();

       
    }

    private void Update()
    {

       
    }

    //リソースから表示させたい画像を指定した個数だけ読み込む関数
    public void read_img(int n)
    {
        Texture tmp;
        for (int i = 1; i < n + 1; i++)
        {
            tmp = Resources.Load("img/"+i) as Texture;
            texture_list.Add(tmp);
        }
    }

    //ボタンで呼び出される関数
    public void ChangeImage1()
    {
        //１～表示する画像の数をランダムで算出
        int random1 = Random.Range(0, texture_list.Count);

        Debug.Log("ランダム値1は" + random1);

        img1.texture = texture_list[random1];
        texture_list.Remove(img1.texture);
    }

    public void ChangeImage2()
    {
        //１～表示する画像の数をランダムで算出
        int random2 = Random.Range(0, texture_list.Count);

        Debug.Log("ランダム値2は" + random2);

        img2.texture = texture_list[random2];
        texture_list.Remove(img2.texture);
    }

    public void ChangeImage3()
    {
        //１～表示する画像の数をランダムで算出
        int random3 = Random.Range(0, texture_list.Count);

        Debug.Log("ランダム値3は" + random3);

        img3.texture = texture_list[random3];
        texture_list.Remove(img3.texture);
    }
}
