using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // �V�[��

//-------------------------------------------------------------------------------------------
// �N�����ɍŏ��Ɉ�x�������s�����N���X(GameManager�ȂǑS�̂ɂ��������̂̐����Ȃǂ��s��)
//-------------------------------------------------------------------------------------------
public class BootstrapLoader : MonoBehaviour
{
    [SerializeField] private GameObject gameManagerPrefab; // �Q�[���}�l�[�W���[��Prefab(�C���X�y�N�^�ŕҏW�\�ȃv���C�x�[�g�ϐ�)

    // ������������
    private void Awake()
    {
        if (GameManager.Instance == null)
        {
            Instantiate(gameManagerPrefab);
        }

        SceneManager.LoadScene(1); // �ŏ��̖{�҃V�[���֑J��
    }
}