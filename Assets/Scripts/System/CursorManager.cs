using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//-------------------------------------------------------------------------------------------
// カーソルの表示・非表示を管理するクラス
//-------------------------------------------------------------------------------------------
public class CursorManager : MonoBehaviour
{
    public void ShowCursor(bool show)
    {
        Cursor.visible = show;
        Cursor.lockState = show ? CursorLockMode.None : CursorLockMode.Locked;
    }
}
