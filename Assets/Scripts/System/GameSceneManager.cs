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
    static private FadeManager fadeManager; // フェードマネージャー

    // Start is called before the first frame update
    private void Awake()
    {
        fadeManager = FindAnyObjectByType<FadeManager>(); // フェードマネージャーを取得する
    }

    // Start is called before the first frame update
    void Start()
    {
        fadeManager.FadeIn();       // フェードインフラグを立てる
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {// スペースキーが押されたら
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

    // シーン切替関数
    public async void SceneChange(int sceneIndex)
    {
        fadeManager.FadeOut();                     // フェードアウトフラグを立てる
        float waitTime = fadeManager.fadeTime;     // フェードアウトの時間を取得する
        await Task.Delay((int)(waitTime * 1000f)); // フェードアウト完了まで待つ
        SceneManager.LoadScene(sceneIndex);        // シーンを切り替える
    }
}