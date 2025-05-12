using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // シーン

//-------------------------------------------------------------------------------------------
// 起動時に最初に一度だけ実行されるクラス(GameManagerなど全体にかかわるものの生成などを行う)
//-------------------------------------------------------------------------------------------
public class BootstrapLoader : MonoBehaviour
{
    [SerializeField] private GameObject gameManagerPrefab = null; // ゲームマネージャーのPrefab(インスペクタで編集可能なプライベート変数)

    // 初期生成処理
    private void Awake()
    {
        if (GameManager.Instance == null)
        {// ゲームマネージャーが存在していない
            Instantiate(gameManagerPrefab); // ゲームマネージャーを生成

            SceneManager.LoadScene(1); // 最初の本編シーンへ遷移
        }
    }
}