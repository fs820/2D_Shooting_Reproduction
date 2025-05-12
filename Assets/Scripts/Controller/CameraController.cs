using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//--------------------------------------------
// カメラ操作クラス(ゲームシーン用)
//--------------------------------------------
public class CameraController : MonoBehaviour
{
    private GameObject Enemy = null; // エネミーの格納用
    private Rigidbody2D enemyRb = null; // エネミーの物理

    // Start is called before the first frame update
    void Start()
    {
        Enemy = GameObject.FindGameObjectWithTag("Enemy"); // Enemyタグのオブジェクトを見つける
        if (Enemy != null)
        {
            enemyRb = Enemy.GetComponent<Rigidbody2D>();        // Enemyの物理
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Enemy == null)
        {
            Enemy = GameObject.FindGameObjectWithTag("Enemy"); // Enemyタグのオブジェクトを見つける

            if (Enemy == null) return; // まだ見つからなければ何もしない
        }

        if (Enemy != null && enemyRb == null)
        {
            enemyRb = Enemy.GetComponent<Rigidbody2D>();        // Enemyの物理

            if (enemyRb == null) return; // まだ見つからなければ何もしない
        }

        transform.position = new Vector3(enemyRb.position.x, enemyRb.position.y, transform.position.z);
    }
}