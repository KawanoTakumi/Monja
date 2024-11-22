using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseSE : MonoBehaviour
{
    private new AudioSource audio;
    public AudioClip Sound;
    private string songName;

    Camera mainCamera;
    GameObject targetObject;
    RaycastHit hit;

    void Start()
    {
        audio = GetComponent<AudioSource>();
        mainCamera = Camera.main;

        SetCursor(true);
    }
    void Update()
    {
        // マウスの左ボタンが押下されたら、対象オブジェクトを調べる処理
        if (Input.GetMouseButtonDown(0))
        {
            LookUpTargetObject();
            return;
        }
        CastRay();
    }
    void OnDisable()
    {
        SetCursor(true);
    }
    ////マウスがUIの上に乗ったら音が鳴る
    //void OnMouseEnter()
    //{
    //    Debug.Log("abcd");
    //        GetComponent<AudioSource>().Play();  // 効果音を鳴らす
    //}
    //void OnMouseExit()
    //{
    //    Debug.Log("マウスがオブジェクトから離れました。");
        
    //}
    // マウスカーソルの位置から「レイ」を飛ばして、何かのコライダーに当たるかどうかをチェック
    void CastRay()
    {
        //Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        Vector3 origin = Input.mousePosition;
        Vector3 direction = new Vector3(0, 0, 1);
        //Debug.Log(direction);
        //Debug.Log(origin);
        //if (Physics.Raycast(ray.origin, direction, out hit, Mathf.Infinity))
        if (Physics.Raycast(origin, direction, out hit, Mathf.Infinity))
            {
                Debug.Log("narasuyo");

            targetObject = hit.collider.gameObject;
            SetCursor(false);
            Debug.Log("abcd");
            songName = "Mouse SE";
            Sound = (AudioClip)Resources.Load("Sound/" + songName);
            audio.PlayOneShot(Sound);
        }
        else
        {
            targetObject = null;
            SetCursor(true);
        }
    }
    void LookUpTargetObject()
    {
        //if (targetObject == null)
        //{
        //    return;
        //}
        //else if (targetObject == CompareTag("UI"))
        //{

        //}

        SetCursor(true);
        targetObject.CompareTag("UI");
        // このコンポーネントを無効にする（そうしないと調べている最中に別のオブジェクトを調べることができてしまう）
        enabled = false;
    }
    void SetCursor(bool isDefault)
    {
        ;
    }
}
