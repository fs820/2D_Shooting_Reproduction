using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;      // �X���b�h
using UnityEngine.SceneManagement; // �V�[��

//-------------------------------------------------------------------------------------------
// �V�[�����Ǘ�����N���X
//-------------------------------------------------------------------------------------------
public class GameSceneManager : MonoBehaviour
{
    // �����ϐ�
    static private FadeManager fadeManager; // �t�F�[�h�}�l�[�W���[

    // Start is called before the first frame update
    private void Awake()
    {
        fadeManager = FindAnyObjectByType<FadeManager>(); // �t�F�[�h�}�l�[�W���[���擾����
    }

    // Start is called before the first frame update
    void Start()
    {
        fadeManager.FadeIn();       // �t�F�[�h�C���t���O�𗧂Ă�
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
                nSceneIndex = 1; // 0�̓��[�v�Ɋ֌W�Ȃ��̂�1�ɖ߂�
            }

            // �V�[����؂�ւ���
            SceneChange(nSceneIndex);
        }
    }

    // �V�[���ؑ֊֐�
    public async void SceneChange(int sceneIndex)
    {
        fadeManager.FadeOut();                     // �t�F�[�h�A�E�g�t���O�𗧂Ă�
        float waitTime = fadeManager.fadeTime;     // �t�F�[�h�A�E�g�̎��Ԃ��擾����
        await Task.Delay((int)(waitTime * 1000f)); // �t�F�[�h�A�E�g�����܂ő҂�
        SceneManager.LoadScene(sceneIndex);        // �V�[����؂�ւ���
    }
}