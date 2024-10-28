using UnityEngine;

public class ItemCord : MonoBehaviour
{
    private void Start()
    {
        // ゲームオブジェクトの名前を指定して取得
        GameObject myObject = GameObject.Find("y");

        // 取得したゲームオブジェクトが存在するか確認
        if (myObject != null)
        {
            // 取得したゲームオブジェクトに対する操作をここで行う
            Debug.Log("オブジェクト名が見つかりました：" + myObject.name);
        }
        else
        {
            Debug.LogWarning("オブジェクト名： 'ObjectName'が見つかりません");
        }
    }
}