using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//-------------------------------------------------------------------------------------------
// ゲーム全体の管理を行うクラス
//-------------------------------------------------------------------------------------------
public class GameManager : MonoBehaviour
{
    public static GameManager Instance; // ゲームマネージャーのインスタンスを保持する変数

    private void Awake()
    {
        if (Instance == null)
        {// 起動時
            DontDestroyOnLoad(this); // シーンをまたいでもオブジェクトを保持する
            Instance = this;
        }
        else
        {// 起動時以外
            Destroy(this);           // 以降は重複しないように破棄する
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
