using UnityEngine;

public class GameObjectFinder : MonoBehaviour
{
    private void Start()
    {
        // タグを指定してゲームオブジェクトを取得
        GameObject[] enemyObjects = GameObject.FindGameObjectsWithTag("Enemy");

        // 取得したゲームオブジェクトに対する操作をループで行う
        foreach (GameObject enemy in enemyObjects)
        {
            Debug.Log("Enemyタグを持ったオブジェクト名：" + enemy.name);
        }
    }
}