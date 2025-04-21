using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//-------------------------------------------------------------------------------------------
// フェードを管理するクラス
//-------------------------------------------------------------------------------------------
public class FadeManager : MonoBehaviour
{
    // 静的変数

    [SerializeField] private GameObject FadeCanvasFrefab; // FadeCanvas(フェード用のパネル)のPrefab(インスペクタで編集可能なプライベート変数)

    // 自動変数

    bool isFadeIn = false;  // フェードインフラグ
    bool isFadeOut = false; // フェードアウトフラグ

    // パブリック
    public float alpha = 0.0f;     // 透明度
    public float fadeTime = 0.0f;  // フェード時間

    private void Awake()
    {
        Instantiate(FadeCanvasFrefab); // フェード用のパネルを生成する
    }

    // Update is called once per frame
    void Update()
    {
        if (isFadeIn)
        {// フェードイン
            alpha -= Time.deltaTime / fadeTime; // オブジェクトの透明度

            if (alpha <= 0.0f)
            {// 0.0fになったら終了
                isFadeIn = false;
                alpha = 0.0f;
            }

            FadeCanvasFrefab.GetComponentInChildren<Image>().color = new Color(0.0f, 0.0f, 0.0f, alpha); // 透明度を適応する
        }
        else if (isFadeOut)
        {// フェードアウト
            alpha += Time.deltaTime / fadeTime; // オブジェクトの透明度

            if (alpha >= 1.0f)
            {// 1.0fになったら終了
                isFadeOut = false;
                alpha = 1.0f;
            }

            FadeCanvasFrefab.GetComponentInChildren<Image>().color = new Color(0.0f, 0.0f, 0.0f, alpha); // 透明度を適応する
        }
    }

    // フェードイン開始
    public void FadeIn()
    {
        isFadeIn = true;
        isFadeOut = false;
    }

    // フェードアウト開始
    public void FadeOut()
    {
        isFadeIn = false;
        isFadeOut = true;
    }
}
