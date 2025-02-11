using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private EnemyGenerator enemyGenerator;

    [SerializeField]
    private CharaGenerator charaGenerator;
    
    public bool isEnemyGenerate;  // ������ EnemyGenerator �X�N���v�g���̕ϐ����S�ڊǂ��܂�

    public int generateIntervalTime;

    public int generateEnemyCount;

    public int maxEnemyCount;

    // Start is called before the first frame update
    void Start()
    {
        // �L�����z�u�p�|�b�v�A�b�v�̐����Ɛݒ�
        StartCoroutine(charaGenerator.SetUpCharaGenerator(this));

        isEnemyGenerate = true;

        // �G�̐��������J�n
        StartCoroutine(enemyGenerator.PreparateEnemyGenerate(this));
    }

    // �G�̏��� List �ɒǉ�
    public void AddEnemyList() //�@TODO�@�G�̏��� List �ɒǉ�����ۂɁA������ǉ�
    {
        //�@TODO�@�G�̏��� List �ɒǉ�

        // �G�̐��������J�E���g�A�b�v
        generateEnemyCount++;
    }

    // �G�̐������~���邩����
    public void JudgeGenerateEnemysEnd()
    {
        if (generateEnemyCount >= maxEnemyCount)
        {
            isEnemyGenerate = false;

        }
    }
}

     