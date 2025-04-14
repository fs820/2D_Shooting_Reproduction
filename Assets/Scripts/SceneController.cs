using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;      // �X���b�h
using UnityEngine.SceneManagement; // �V�[��

public class SceneController : MonoBehaviour
{
    // �����ϐ�

    // �p�u���b�N
    public GameObject fade; // �C���X�y�N�^����Prefab������Canvas������p�̕ϐ�

    // ���[�J��
    GameObject fadeCanvas;  // Canvas����p

    // Start is called before the first frame update
    void Start()
    {
        // FadeManager.cs��isFadeInstance���Q��
        if (!FadeManager.isFadeInstance)
        {// ��������Ă��Ȃ����
            Instantiate(fade); // ��������
        }

        // �N������Canvas�̐�����҂�
        Invoke("findFadeObject", 0.02f);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {// �X�y�[�X�L�[�������ꂽ��
            // ���݂̃V�[����1�𑫂��������������Ă���
            int nSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;

            if (nSceneIndex >= SceneManager.sceneCountInBuildSettings)
            {// �V�[���̍ő�C���f�b�N�X�𒴂��Ȃ��悤�ɔ͈͐�������
                nSceneIndex = 0;
            }

            // �V�[����؂�ւ���
            sceneChange(nSceneIndex);
        }
    }

    // Canvas��������֐�
    void findFadeObject()
    {
        fadeCanvas = GameObject.FindGameObjectWithTag("Fade"); // Canvas��������

        fadeCanvas.GetComponent<FadeManager>().fadeIn();       // �t�F�[�h�C���t���O�𗧂Ă�
    }

    // �V�[���ؑ֊֐�
    public async void sceneChange(int sceneIndex)
    {
        fadeCanvas.GetComponent<FadeManager>().fadeOut(); // �t�F�[�h�A�E�g�t���O�𗧂Ă�
        await Task.Delay(200);                            // �t�F�[�h�A�E�g�����܂ő҂�
        SceneManager.LoadScene(sceneIndex);               // �V�[����؂�ւ���
    }
}
