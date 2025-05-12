using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//-------------------------------------------------------------------------------------------
// �t�F�[�h���Ǘ�����N���X
//-------------------------------------------------------------------------------------------
public class FadeManager : MonoBehaviour
{
    public float fadeTime = 0.0f;  // �t�F�[�h����

    [SerializeField] private float alpha = 0.0f;     // �����x

    private Image FadeImage = null; // Fade�p�l���̃C���[�W�̃R���|�[�l���g

    bool isFadeIn = false;  // �t�F�[�h�C���t���O
    bool isFadeOut = false; // �t�F�[�h�A�E�g�t���O

    private void Awake()
    {
        FadeImage = GetComponentInChildren<Image>();            // Canvas�ȓ���Fade�p�l���̃C���[�W�̃R���|�[�l���g���擾
    }

    // Update is called once per frame
    void Update()
    {
        // FadeImage��null�`�F�b�N
        if (FadeImage == null)
        {// FadeImage���j������Ă���ꍇ
            Debug.LogError(FadeImage);
            return;
        }

        if (isFadeIn)
        {// �t�F�[�h�C��
            alpha -= Time.deltaTime / fadeTime; // �I�u�W�F�N�g�̓����x

            if (alpha <= 0.0f)
            {// 0.0f�ɂȂ�����I��
                isFadeIn = false;
                alpha = 0.0f;
            }

            FadeImage.color = new Color(FadeImage.color.r, FadeImage.color.g, FadeImage.color.b, alpha); // �����x��K������
        }
        else if (isFadeOut)
        {// �t�F�[�h�A�E�g
            alpha += Time.deltaTime / fadeTime; // �I�u�W�F�N�g�̓����x

            if (alpha >= 1.0f)
            {// 1.0f�ɂȂ�����I��
                isFadeOut = false;
                alpha = 1.0f;
            }

            FadeImage.color = new Color(FadeImage.color.r, FadeImage.color.g, FadeImage.color.b, alpha); // �����x��K������
        }
    }

    // �t�F�[�h�C���J�n
    public bool FadeIn()
    {
        if (!isFadeIn && !isFadeOut)
        {// �t�F�[�h���s���Ă��Ȃ�
            isFadeIn = true;
            isFadeOut = false;

            return true;
        }
        else
        {// �t�F�[�h��
            return false;
        }
    }

    // �t�F�[�h�A�E�g�J�n
    public bool FadeOut()
    {
        if (!isFadeIn && !isFadeOut)
        {// �t�F�[�h���s���Ă��Ȃ�
            isFadeIn = false;
            isFadeOut = true;

            return true;
        }
        else
        {// �t�F�[�h��
            return false;
        }
    }
}
