using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private GameObject playerPrefab;

    // Start is called before the first frame update
    void Start()
    {
        // プレイヤーが存在しない場合のみ生成
        if (GameObject.FindWithTag("Player") == null)
        {
            GameObject player=Instantiate(playerPrefab);
            player.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f); // x, y, zそれぞれ2倍のスケール
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
