using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public string sceneName;//�؂�ւ���V�[���̖��O������
    public Shop_manager shop;
    public static bool Scene_Change = false;
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
        if(Scene_Change == false)
        {
            SceneManager.LoadScene(sceneName);
        }
        else if(Scene_Change == true)
        {
            Scene_Change = false;
            SceneManager.LoadScene("shop");
        }
    }

    public void change_scene()
    {
        Scene_Change = true;
    }
}