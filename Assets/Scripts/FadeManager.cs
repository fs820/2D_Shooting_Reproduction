using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// �t�F�[�h���Ǘ�����N���X
public class FadeManager : MonoBehaviour
{
    // �ÓI�ϐ�

    // �p�u���b�N
    public static bool isFadeInstance = false; // �I�u�W�F�N�g����������Ă��邩�ǂ����̃t���O

    // �����ϐ�

    bool isFadeIn = false;  // �t�F�[�h�C���t���O
    bool isFadeOut = false; // �t�F�[�h�A�E�g�t���O

    // �p�u���b�N
    public float alpha = 0.0f;     // �����x
    public float fadeSpeed = 0.0f; // �t�F�[�h�X�s�[�h

    // Start is called before the first frame update
    void Start()
    {
        if (!isFadeInstance)
        {// �N����
            DontDestroyOnLoad(this); // �I�u�W�F�N�g���V�[�����܂����ł���
            isFadeInstance = true;   // �����t���O�𗧂Ă�
        }
        else
        {// �N�����ȊO
            Destroy(this);           // �ȍ~�͏d�����Ȃ��悤�ɔj������
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isFadeIn)
        {// �t�F�[�h�C��
            alpha -= Time.deltaTime / fadeSpeed; // �I�u�W�F�N�g�̓����x

            if (alpha <= 0.0f)
            {// 0.0f�ɂȂ�����I��
                isFadeIn = false;
                alpha = 0.0f;
            }

            this.GetComponentInChildren<Image>().color = new Color(0.0f, 0.0f, 0.0f, alpha); // �����x��K������
        }
        else if (isFadeOut)
        {// �t�F�[�h�A�E�g
            alpha += Time.deltaTime / fadeSpeed; // �I�u�W�F�N�g�̓����x

            if (alpha >= 1.0f)
            {// 1.0f�ɂȂ�����I��
                isFadeOut = false;
                alpha = 1.0f;
            }

            this.GetComponentInChildren<Image>().color = new Color(0.0f, 0.0f, 0.0f, alpha); // �����x��K������
        }
    }

    // �t�F�[�h�C���J�n
    public void fadeIn()
    {
        isFadeIn = true;
        isFadeOut = false;
    }

    // �t�F�[�h�A�E�g�J�n
    public void fadeOut()
    {
        isFadeIn = false;
        isFadeOut = true;
    }
}
