using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//-------------------------------------------------------------------------------------------
// �Q�[���S�̂̊Ǘ����s���N���X
//-------------------------------------------------------------------------------------------
public class GameManager : MonoBehaviour
{
    public static GameManager Instance; // �Q�[���}�l�[�W���[�̃C���X�^���X��ێ�����ϐ�

    private void Awake()
    {
        if (Instance == null)
        {// �N����
            DontDestroyOnLoad(this); // �V�[�����܂����ł��I�u�W�F�N�g��ێ�����
            Instance = this;
        }
        else
        {// �N�����ȊO
            Destroy(this);           // �ȍ~�͏d�����Ȃ��悤�ɔj������
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
