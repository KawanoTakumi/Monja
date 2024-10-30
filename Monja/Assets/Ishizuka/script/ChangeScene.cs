using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public string sceneName;//切り替えるシーンの名前を入れる
    public Shop_manager shop;
    public void Start()
    {
        shop = GetComponent<Shop_manager>();
    }
    public void Update()
    {
        
    }

    //シーンを読み込む
    public void Load()
    {
        //shop.button1 = null;
        //shop.button2 = null;
        //shop.button3 = null;
        SceneManager.LoadScene(sceneName);

    }
}
