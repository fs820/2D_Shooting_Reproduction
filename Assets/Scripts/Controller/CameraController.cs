using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//--------------------------------------------
// �J��������N���X(�Q�[���V�[���p)
//--------------------------------------------
public class CameraController : MonoBehaviour
{
    private GameObject Enemy = null; // �G�l�~�[�̊i�[�p
    private Rigidbody2D enemyRb = null; // �G�l�~�[�̕���

    // Start is called before the first frame update
    void Start()
    {
        Enemy = GameObject.FindGameObjectWithTag("Enemy"); // Enemy�^�O�̃I�u�W�F�N�g��������
        if (Enemy != null)
        {
            enemyRb = Enemy.GetComponent<Rigidbody2D>();        // Enemy�̕���
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Enemy == null)
        {
            Enemy = GameObject.FindGameObjectWithTag("Enemy"); // Enemy�^�O�̃I�u�W�F�N�g��������

            if (Enemy == null) return; // �܂�������Ȃ���Ή������Ȃ�
        }

        if (Enemy != null && enemyRb == null)
        {
            enemyRb = Enemy.GetComponent<Rigidbody2D>();        // Enemy�̕���

            if (enemyRb == null) return; // �܂�������Ȃ���Ή������Ȃ�
        }

        transform.position = new Vector3(enemyRb.position.x, enemyRb.position.y, transform.position.z);
    }
}