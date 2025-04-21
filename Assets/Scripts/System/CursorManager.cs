using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//-------------------------------------------------------------------------------------------
// �J�[�\���̕\���E��\�����Ǘ�����N���X
//-------------------------------------------------------------------------------------------
public class CursorManager : MonoBehaviour
{
    public void ShowCursor(bool show)
    {
        Cursor.visible = show;
        Cursor.lockState = show ? CursorLockMode.None : CursorLockMode.Locked;
    }
}
