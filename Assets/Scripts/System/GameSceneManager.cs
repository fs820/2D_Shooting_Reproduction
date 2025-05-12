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
    [SerializeField] private FadeManager fadeManager = null; // �t�F�[�h�}�l�[�W���[

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {// �L�[�������ꂽ��
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

    // �V�[���ؑ֊֐�(�C���f�b�N�X)
    public async void SceneChange(int sceneIndex)
    {
        if (fadeManager.FadeOut())
        {// �t�F�[�h�A�E�g�t���O�𗧂�����
            float waitTime = fadeManager.fadeTime;     // �t�F�[�h�A�E�g�̎��Ԃ��擾����
            await Task.Delay((int)(waitTime * 1000f)); // �t�F�[�h�A�E�g�����܂ő҂�
            SceneManager.LoadScene(sceneIndex);        // �V�[����؂�ւ���
        }
    }

    // �V�[���ؑ֊֐�(�V�[����)
    public async void SceneChange(string sceneName)
    {
        if (fadeManager.FadeOut())
        {// �t�F�[�h�A�E�g�t���O�𗧂�����
            float waitTime = fadeManager.fadeTime;     // �t�F�[�h�A�E�g�̎��Ԃ��擾����
            await Task.Delay((int)(waitTime * 1000f)); // �t�F�[�h�A�E�g�����܂ő҂�
            SceneManager.LoadScene(sceneName);         // �V�[����؂�ւ���
        }
    }

    // �V�[���ؑ֌��m
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        fadeManager.FadeIn();                     // �t�F�[�h�C���t���O�𗧂Ă�
    }

    // 
    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}