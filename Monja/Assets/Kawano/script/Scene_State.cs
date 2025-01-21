using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene_State : MonoBehaviour
{
    public Animator anim;
    void Update()
    {
        //シーンカウント毎に移動アニメーションを変更する
        switch (ChangeScene.SCENE_CNT)
        {
            case 1: anim.SetBool("anim1", true); break;
            case 4: anim.SetBool("anim1", true); break;
            case 7: anim.SetBool("anim1", true);break;
            case 2: anim.SetBool("anim2", true); break;
            case 5: anim.SetBool("anim2", true); break;
            case 8: anim.SetBool("anim2", true);break;
            case 3: anim.SetBool("anim3", true); break;
            case 6: anim.SetBool("anim3", true); break;
            case 9: anim.SetBool("anim3", true);break;
        }
    }
}