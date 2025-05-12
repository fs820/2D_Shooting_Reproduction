using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//---------------------------------------
// 終了を管理するクラス
//---------------------------------------
public class QuitManager : MonoBehaviour
{
    CursorManager cursorManager;

    private void Start()
    {
        cursorManager = FindObjectOfType<CursorManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {// エスケープボタンを押したら
            OnQuitButtonPressed(); // 確認ダイアログ
        }
    }

    public void OnQuitButtonPressed()
    {
        transform.Find("confirmDialog").gameObject.SetActive(true); // 確認ダイアログ表示
        Time.timeScale = 0f; // 時間停止

        cursorManager.ShowCursor(true);
    }

    public void OnConfirmQuit()
    {
        Application.Quit(); // 実際に終了
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false; // エディタ内では再生を止める
#endif
    }

    public void OnCancelQuit()
    {
        transform.Find("confirmDialog").gameObject.SetActive(false); // ダイアログを閉じる
        Time.timeScale = 1f; // 時間再生

        cursorManager.ShowCursor(false);
    }
}