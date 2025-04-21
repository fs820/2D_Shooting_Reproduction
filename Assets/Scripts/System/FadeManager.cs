using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//-------------------------------------------------------------------------------------------
// �t�F�[�h���Ǘ�����N���X
//-------------------------------------------------------------------------------------------
public class FadeManager : MonoBehaviour
{
    // �ÓI�ϐ�

    [SerializeField] private GameObject FadeCanvasFrefab; // FadeCanvas(�t�F�[�h�p�̃p�l��)��Prefab(�C���X�y�N�^�ŕҏW�\�ȃv���C�x�[�g�ϐ�)

    // �����ϐ�

    bool isFadeIn = false;  // �t�F�[�h�C���t���O
    bool isFadeOut = false; // �t�F�[�h�A�E�g�t���O

    // �p�u���b�N
    public float alpha = 0.0f;     // �����x
    public float fadeTime = 0.0f;  // �t�F�[�h����

    private void Awake()
    {
        Instantiate(FadeCanvasFrefab); // �t�F�[�h�p�̃p�l���𐶐�����
    }

    // Update is called once per frame
    void Update()
    {
        if (isFadeIn)
        {// �t�F�[�h�C��
            alpha -= Time.deltaTime / fadeTime; // �I�u�W�F�N�g�̓����x

            if (alpha <= 0.0f)
            {// 0.0f�ɂȂ�����I��
                isFadeIn = false;
                alpha = 0.0f;
            }

            FadeCanvasFrefab.GetComponentInChildren<Image>().color = new Color(0.0f, 0.0f, 0.0f, alpha); // �����x��K������
        }
        else if (isFadeOut)
        {// �t�F�[�h�A�E�g
            alpha += Time.deltaTime / fadeTime; // �I�u�W�F�N�g�̓����x

            if (alpha >= 1.0f)
            {// 1.0f�ɂȂ�����I��
                isFadeOut = false;
                alpha = 1.0f;
            }

            FadeCanvasFrefab.GetComponentInChildren<Image>().color = new Color(0.0f, 0.0f, 0.0f, alpha); // �����x��K������
        }
    }

    // �t�F�[�h�C���J�n
    public void FadeIn()
    {
        isFadeIn = true;
        isFadeOut = false;
    }

    // �t�F�[�h�A�E�g�J�n
    public void FadeOut()
    {
        isFadeIn = false;
        isFadeOut = true;
    }
}
