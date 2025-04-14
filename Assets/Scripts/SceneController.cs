using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;      // スレッド
using UnityEngine.SceneManagement; // シーン

public class SceneController : MonoBehaviour
{
    // 自動変数

    // パブリック
    public GameObject fade; // インスペクタからPrefab化したCanvasを入れる用の変数

    // ローカル
    GameObject fadeCanvas;  // Canvas操作用

    // Start is called before the first frame update
    void Start()
    {
        // FadeManager.csのisFadeInstanceを参照
        if (!FadeManager.isFadeInstance)
        {// 生成されていなければ
            Instantiate(fade); // 生成する
        }

        // 起動時にCanvasの生成を待つ
        Invoke("findFadeObject", 0.02f);
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
                nSceneIndex = 0;
            }

            // シーンを切り替える
            sceneChange(nSceneIndex);
        }
    }

    // Canvasを見つける関数
    void findFadeObject()
    {
        fadeCanvas = GameObject.FindGameObjectWithTag("Fade"); // Canvasを見つける

        fadeCanvas.GetComponent<FadeManager>().fadeIn();       // フェードインフラグを立てる
    }

    // シーン切替関数
    public async void sceneChange(int sceneIndex)
    {
        fadeCanvas.GetComponent<FadeManager>().fadeOut(); // フェードアウトフラグを立てる
        await Task.Delay(200);                            // フェードアウト完了まで待つ
        SceneManager.LoadScene(sceneIndex);               // シーンを切り替える
    }
}
