using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//-------------------------------------------------------------------------------------------
// カーソルの表示・非表示を管理するクラス
//-------------------------------------------------------------------------------------------
public class CursorManager : MonoBehaviour
{
    [SerializeField] private string noCursorScene = "GameScene"; // カーソルを隠すシーン(基本ゲーム)

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F4))
        {// F4が押されたら
            ToggleCursor(); // カーソルをトグル
        }
    }

    // カーソル表示切替
    public void ShowCursor(bool show)
    {// カーソルの表示切替
        Cursor.visible = show;
        Cursor.lockState = show ? CursorLockMode.None : CursorLockMode.Locked;
    }

    // カーソルトグル
    public void ToggleCursor()
    {// カーソルが出ていれば消す、消えていれば出す
        Cursor.visible = !Cursor.visible;
        Cursor.lockState = (Cursor.lockState == CursorLockMode.Locked) ? CursorLockMode.None : CursorLockMode.Locked;
    }

    //-------------------
    // シーン検知機構
    //-------------------

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        ShowCursor(scene.name != noCursorScene); // カーソルを隠すシーンでなければカーソルを表示
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    //-------------------
    // シーン検知機構 End
    //-------------------
}