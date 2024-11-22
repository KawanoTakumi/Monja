using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class intro_script : MonoBehaviour
{
    public Text text_box;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Change_Text(int text_num)
    {
        switch (text_num)
        {
            default:text_box.text = "";break;
            case 1: text_box.text = "ある日、突如として街の中に大穴が現れた";break;
            case 2: text_box.text = "大穴の奥地で発見された未知の物質\n’パラレライト鉱石。'";break;
            case 3: text_box.text = "この物質はとても貴重で高額で取引されている。\n主人公は大金持ちになるため\n大穴の中へ向かうのであった。"; break;
            case 4: text_box.text = "・・・足を滑らせて穴の中に落ちながら。";break;
            case 5: SceneManager.LoadScene("work_01");break;
        }
    }
}