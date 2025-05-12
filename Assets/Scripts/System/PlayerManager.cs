using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private GameObject playerPrefab;

    // Start is called before the first frame update
    void Start()
    {
        // �v���C���[�����݂��Ȃ��ꍇ�̂ݐ���
        if (GameObject.FindWithTag("Player") == null)
        {
            GameObject player=Instantiate(playerPrefab);
            player.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f); // x, y, z���ꂼ��2�{�̃X�P�[��
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
