using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//-------------------------------------------------------------------------------------------
// フェードを管理するクラス
//-------------------------------------------------------------------------------------------
public class FadeManager : MonoBehaviour
{
    public float fadeTime = 0.0f;  // フェード時間

    [SerializeField] private float alpha = 0.0f;     // 透明度

    private Image FadeImage = null; // Fadeパネルのイメージのコンポーネント

    bool isFadeIn = false;  // フェードインフラグ
    bool isFadeOut = false; // フェードアウトフラグ

    private void Awake()
    {
        FadeImage = GetComponentInChildren<Image>();            // Canvasな内のFadeパネルのイメージのコンポーネントを取得
    }

    // Update is called once per frame
    void Update()
    {
        // FadeImageのnullチェック
        if (FadeImage == null)
        {// FadeImageが破棄されている場合
            Debug.LogError(FadeImage);
            return;
        }

        if (isFadeIn)
        {// フェードイン
            alpha -= Time.deltaTime / fadeTime; // オブジェクトの透明度

            if (alpha <= 0.0f)
            {// 0.0fになったら終了
                isFadeIn = false;
                alpha = 0.0f;
            }

            FadeImage.color = new Color(FadeImage.color.r, FadeImage.color.g, FadeImage.color.b, alpha); // 透明度を適応する
        }
        else if (isFadeOut)
        {// フェードアウト
            alpha += Time.deltaTime / fadeTime; // オブジェクトの透明度

            if (alpha >= 1.0f)
            {// 1.0fになったら終了
                isFadeOut = false;
                alpha = 1.0f;
            }

            FadeImage.color = new Color(FadeImage.color.r, FadeImage.color.g, FadeImage.color.b, alpha); // 透明度を適応する
        }
    }

    // フェードイン開始
    public bool FadeIn()
    {
        if (!isFadeIn && !isFadeOut)
        {// フェードが行われていない
            isFadeIn = true;
            isFadeOut = false;

            return true;
        }
        else
        {// フェード中
            return false;
        }
    }

    // フェードアウト開始
    public bool FadeOut()
    {
        if (!isFadeIn && !isFadeOut)
        {// フェードが行われていない
            isFadeIn = false;
            isFadeOut = true;

            return true;
        }
        else
        {// フェード中
            return false;
        }
    }
}
