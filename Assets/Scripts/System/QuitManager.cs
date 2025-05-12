using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//---------------------------------------
// �I�����Ǘ�����N���X
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
        {// �G�X�P�[�v�{�^������������
            OnQuitButtonPressed(); // �m�F�_�C�A���O
        }
    }

    public void OnQuitButtonPressed()
    {
        transform.Find("confirmDialog").gameObject.SetActive(true); // �m�F�_�C�A���O�\��
        Time.timeScale = 0f; // ���Ԓ�~

        cursorManager.ShowCursor(true);
    }

    public void OnConfirmQuit()
    {
        Application.Quit(); // ���ۂɏI��
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false; // �G�f�B�^���ł͍Đ����~�߂�
#endif
    }

    public void OnCancelQuit()
    {
        transform.Find("confirmDialog").gameObject.SetActive(false); // �_�C�A���O�����
        Time.timeScale = 1f; // ���ԍĐ�

        cursorManager.ShowCursor(false);
    }
}