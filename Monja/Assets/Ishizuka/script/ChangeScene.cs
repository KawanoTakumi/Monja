using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public string sceneName;//�؂�ւ���V�[���̖��O������
    public Shop_manager shop;
    public void Start()
    {
        shop = GetComponent<Shop_manager>();
    }
    public void Update()
    {
        
    }

    //�V�[����ǂݍ���
    public void Load()
    {
        //shop.button1 = null;
        //shop.button2 = null;
        //shop.button3 = null;
        SceneManager.LoadScene(sceneName);

    }
}
