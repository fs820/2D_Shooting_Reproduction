using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;

    // Start is called before the first frame update
    void Start()
    {
        // �G�l�~�[�����݂��Ȃ��ꍇ�̂ݐ���
        if (GameObject.FindWithTag("Enemy") == null)
        {
            GameObject  enemy = Instantiate(enemyPrefab);
            enemy.transform.localScale = new Vector3(1f, 1f, 1f); // x, y, z���ꂼ��2�{�̃X�P�[��
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
