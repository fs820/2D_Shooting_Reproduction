using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// フェードを管理するクラス
public class FadeManager : MonoBehaviour
{
    // 静的変数

    // パブリック
    public static bool isFadeInstance = false; // オブジェクトが生成されているかどうかのフラグ

    // 自動変数

    bool isFadeIn = false;  // フェードインフラグ
    bool isFadeOut = false; // フェードアウトフラグ

    // パブリック
    public float alpha = 0.0f;     // 透明度
    public float fadeSpeed = 0.0f; // フェードスピード

    // Start is called before the first frame update
    void Start()
    {
        if (!isFadeInstance)
        {// 起動時
            DontDestroyOnLoad(this); // オブジェクトをシーンをまたいでもつ
            isFadeInstance = true;   // 生成フラグを立てる
        }
        else
        {// 起動時以外
            Destroy(this);           // 以降は重複しないように破棄する
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isFadeIn)
        {// フェードイン
            alpha -= Time.deltaTime / fadeSpeed; // オブジェクトの透明度

            if (alpha <= 0.0f)
            {// 0.0fになったら終了
                isFadeIn = false;
                alpha = 0.0f;
            }

            this.GetComponentInChildren<Image>().color = new Color(0.0f, 0.0f, 0.0f, alpha); // 透明度を適応する
        }
        else if (isFadeOut)
        {// フェードアウト
            alpha += Time.deltaTime / fadeSpeed; // オブジェクトの透明度

            if (alpha >= 1.0f)
            {// 1.0fになったら終了
                isFadeOut = false;
                alpha = 1.0f;
            }

            this.GetComponentInChildren<Image>().color = new Color(0.0f, 0.0f, 0.0f, alpha); // 透明度を適応する
        }
    }

    // フェードイン開始
    public void fadeIn()
    {
        isFadeIn = true;
        isFadeOut = false;
    }

    // フェードアウト開始
    public void fadeOut()
    {
        isFadeIn = false;
        isFadeOut = true;
    }
}
