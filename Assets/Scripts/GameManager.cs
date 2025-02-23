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

    [SerializeField]
    private List<EnemyController>enemiesList = new List<EnemyController>(); //�@�G�̏����ꌳ�����ĊǗ����邽�߂̕ϐ��BEnemyController �^�ň���

    private int destoroyEnemyCount; //  �G��j�󂵂����̃J�E���g�p

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
    public void AddEnemyList(EnemyController enemy) //�@TODO�@�G�̏��� List �ɒǉ�����ۂɁA������ǉ�
    {
        //�G�̏��� List �ɒǉ�
        enemiesList.Add(enemy);

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

    // ���ׂĂ̓G�̈ړ����ꎞ��~
    public void PauseEnemies()
    {
        for (int i = 0; i < enemiesList.Count; i++)
        {
            enemiesList[i].PauseMove();
        }
    }

    // ���ׂĂ̓G�̈ړ����ĊJ
    public void ResumeEnemies()
    {
        for (int i = 0; i < enemiesList.Count; i++)
        {
            enemiesList[i].ResumeMove();
        }
    }

    // �G�̏��� List ����폜
    public void RemoveEnemyList(EnemyController removeEnemy)
    {
        enemiesList.Remove(removeEnemy);
    }

    // �j�󂵂��G�̐����J�E���g(���̃��\�b�h���O���̃N���X������s���Ă��炤)
    public void CountUpDestroyEnemyCount(EnemyController enemyController)
    {
        // List ����j�󂳂ꂽ�G�̏����폜
        RemoveEnemyList(enemyController);

        // �G��j�󂵂��������Z
        destoroyEnemyCount++;

        Debug.Log("�j�󂵂��G�̐�:" + destoroyEnemyCount);

        // �Q�[���N���A����
        JudgeGameClear();
    }

    // �Q�[���N���A����
    public void JudgeGameClear()
    {
        // �������𒴂��Ă��邩
        if(destoroyEnemyCount >= maxEnemyCount)
        {
            Debug.Log("�Q�[���N���A");

            // TODO �Q�[���N���A�̏�����ǉ�
        }
    }

}

