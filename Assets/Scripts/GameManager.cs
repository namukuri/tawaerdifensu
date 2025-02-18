using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
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

    ////*  �V���� enum �̍쐬�� enum �^�̕ϐ��̐錾��ǉ�  *////
    // �Q�[���̏��
    public enum GameState
    {
        Preparate, // �Q�[���J�n�O�̏�����
        Play, // �Q�[���v���C��
        Stop, // �Q�[�����̏����̈ꎞ��~��
        GameUp // �Q�[���I��(�Q�[���I�[�o�[�A�N���A����)
    }

    public GameState currentGameState; // ���݂� GameState �̏�ԁB��L�� GameState �̗񋓎q���P������������̂ŁA���� GameState �Ƌ������Ȃ�


    // Start is called before the first frame update
    void Start()
    {
        // �Q�[���̐i�s��Ԃ��������ɐݒ�
        SetGameState(GameState.Preparate);

        // TODO �Q�[���f�[�^��������

        // TODO �X�e�[�W�̐ݒ� + �X�e�[�W���Ƃ� PathData ��ݒ�

        // �L�����z�u�p�|�b�v�A�b�v�̐����Ɛݒ�
        StartCoroutine(charaGenerator.SetUpCharaGenerator(this));

        // TODO ���_�̐ݒ�

        // TODO �I�[�v�j���O���o�Đ�

        isEnemyGenerate = true;

        // �Q�[���̐i�s��Ԃ��v���C���ɕύX
        SetGameState(GameState.Play);

        // �G�̐��������J�n
        StartCoroutine(enemyGenerator.PreparateEnemyGenerate(this));

        // TODO �J�����V�[�̎����l�������̊J�n
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

    // GameState �̕ύX
    public void SetGameState(GameState nextGameState)
    {
        currentGameState = nextGameState;
    } 

}

     