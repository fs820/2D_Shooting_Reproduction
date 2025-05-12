using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//-------------------------------------------------------------------------------------------
// �J�[�\���̕\���E��\�����Ǘ�����N���X
//-------------------------------------------------------------------------------------------
public class CursorManager : MonoBehaviour
{
    [SerializeField] private string noCursorScene = "GameScene"; // �J�[�\�����B���V�[��(��{�Q�[��)

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F4))
        {// F4�������ꂽ��
            ToggleCursor(); // �J�[�\�����g�O��
        }
    }

    // �J�[�\���\���ؑ�
    public void ShowCursor(bool show)
    {// �J�[�\���̕\���ؑ�
        Cursor.visible = show;
        Cursor.lockState = show ? CursorLockMode.None : CursorLockMode.Locked;
    }

    // �J�[�\���g�O��
    public void ToggleCursor()
    {// �J�[�\�����o�Ă���Ώ����A�����Ă���Ώo��
        Cursor.visible = !Cursor.visible;
        Cursor.lockState = (Cursor.lockState == CursorLockMode.Locked) ? CursorLockMode.None : CursorLockMode.Locked;
    }

    //-------------------
    // �V�[�����m�@�\
    //-------------------

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        ShowCursor(scene.name != noCursorScene); // �J�[�\�����B���V�[���łȂ���΃J�[�\����\��
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
    // �V�[�����m�@�\ End
    //-------------------
}