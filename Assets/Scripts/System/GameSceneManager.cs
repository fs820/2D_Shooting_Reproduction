using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;      // スレッド
using UnityEngine.SceneManagement; // シーン

//-------------------------------------------------------------------------------------------
// シーンを管理するクラス
//-------------------------------------------------------------------------------------------
public class GameSceneManager : MonoBehaviour
{
    // 自動変数
    [SerializeField] private FadeManager fadeManager = null; // フェードマネージャー

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {// キーが押されたら
            // 現在のシーンに1を足した数字を持っておく
            int nSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;

            if (nSceneIndex >= SceneManager.sceneCountInBuildSettings)
            {// シーンの最大インデックスを超えないように範囲制限する
                nSceneIndex = 1; // 0はループに関係ないので1に戻る
            }

            // シーンを切り替える
            SceneChange(nSceneIndex);
        }
    }

    // シーン切替関数(インデックス)
    public async void SceneChange(int sceneIndex)
    {
        if (fadeManager.FadeOut())
        {// フェードアウトフラグを立ったら
            float waitTime = fadeManager.fadeTime;     // フェードアウトの時間を取得する
            await Task.Delay((int)(waitTime * 1000f)); // フェードアウト完了まで待つ
            SceneManager.LoadScene(sceneIndex);        // シーンを切り替える
        }
    }

    // シーン切替関数(シーン名)
    public async void SceneChange(string sceneName)
    {
        if (fadeManager.FadeOut())
        {// フェードアウトフラグを立ったら
            float waitTime = fadeManager.fadeTime;     // フェードアウトの時間を取得する
            await Task.Delay((int)(waitTime * 1000f)); // フェードアウト完了まで待つ
            SceneManager.LoadScene(sceneName);         // シーンを切り替える
        }
    }

    // シーン切替検知
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        fadeManager.FadeIn();                     // フェードインフラグを立てる
    }

    // 
    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}