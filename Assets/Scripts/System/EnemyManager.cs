using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;

    // Start is called before the first frame update
    void Start()
    {
        // エネミーが存在しない場合のみ生成
        if (GameObject.FindWithTag("Enemy") == null)
        {
            GameObject  enemy = Instantiate(enemyPrefab);
            enemy.transform.localScale = new Vector3(1f, 1f, 1f); // x, y, zそれぞれ2倍のスケール
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
