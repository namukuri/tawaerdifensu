using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq; //�@<=�@���@�ǉ����܂�


public class EnemyGenerator : MonoBehaviour
{
    [SerializeField]
    private EnemyController enemyControllerPrefab;

    [SerializeField]
    private PathData[] pathDatas; //�z��ɕύX���A�ϐ����������`�ɏC�����܂�

    [SerializeField]
    private DrawPathLine pathLinePrefab;

    private GameManager gameManager; //�@���@�ǉ����܂�

    //public bool isEnemyGenerate; //�@���@�ȉ��S�̕ϐ����폜���܂�

    //public int generateIntervalTime;

    //public int generateEnemyCount;

    //public int maxEnemyCount;

    // Start is called before the first frame update
    //void Start()
    //{

        // �����̋�������
        //isEnemyGenerate = true;

        // �G�̐�������
        //StartCoroutine(PreparateEnemyGenerate());
    //}

    /// <summary>
    /// �G�̐�������
    /// </summary>
    /// <returns></returns>
    public IEnumerator PreparateEnemyGenerate(GameManager gameManager)
    {

        this.gameManager = gameManager; //�@���A�@������ǉ����܂�

        // �����p�̃^�C�}�[�p��
        int timer = 0;

        // isEnemyGenetate �� true �̊Ԃ̓��[�v����
        while (gameManager.isEnemyGenerate)
        {
            if(this.gameManager.currentGameState == GameManager.GameState.Play) //�@<=�@���@�@GameState �� Play �ȊO�ł͐������ꎞ��~
            {
                // �^�C�}�[�����Z
                timer++;

                // �^�C�}�[�̒l���G�̐����ҋ@���Ԃ𒴂�����
                if (timer > gameManager.generateIntervalTime)
                {
                    // ���̐����̂��߂Ƀ^�C�}�[�����Z�b�g
                    timer = 0;

                    //GenerateEnemy();                              //  <=  ���A�@�R�����g�A�E�g���܂�

                    // �G�̐������A�G�̐������̃J�E���g�A�b�v�� List �ւ̒ǉ�
                    gameManager.AddEnemyList(GenerateEnemy()); //�@<=�@���B�@������ GenerateEnemy ���\�b�h��ݒ肵�܂�

                    // �ő吶�����𒴂����琶����~
                    gameManager.JudgeGenerateEnemysEnd();
                }
            }
                       
            // 1�t���[�����f  
            yield return null;
        }

        // TODO �����I����̏������L�q����

    }

    // �G�̐���
    public EnemyController GenerateEnemy(int generateNo = 0) //�@<=�@���@�@�߂�l��ύX���A������ǉ����܂�
    {
        // �����_���Ȓl��z��̍ő�v�f�����Ŏ擾
        int randomValue = Random.Range(0, pathDatas.Length); //�@<=�@���@�@������ǉ����܂�


        // �w�肵���ʒu�ɓG�𐶐�
        EnemyController enemyController = Instantiate(enemyControllerPrefab, pathDatas[randomValue].generateTran.position, Quaternion.identity); //�@<=�@���A�@��2������z��̗v�f�ԍ����Q�Ƃ���悤�ɏC�����܂�

        // TODO ������

        // �ړ�����n�_���擾(<=�@���܂܂�EnemyController �X�N���v�g���ōs���Ă���������������Ɉړ����܂�)
        Vector3[] pathdatas = pathDatas[randomValue].pathTranArray.Select(x => x.position).ToArray(); //�@<=�@���B�@�����Ώۂ�z��̗v�f�ԍ����Q�Ƃ���悤�ɏC�����܂�

        // �G�̏��̐ݒ�
        enemyController.SetUpEnemyController(pathdatas);
              
         // �G�̈ړ��o�H�̃��C���\���𐶐��̏���
        StartCoroutine(PreparateCreatePathLine(pathdatas, enemyController));

        return enemyController;

    }

    // ���C�������̏���
    private IEnumerator PreparateCreatePathLine(Vector3[] paths, EnemyController enemyController)
    {
        // ���C���̐����ƍ폜�B���̏������I������܂ł́A���̏�����艺�̏����͎��s����Ȃ�
        yield return StartCoroutine(CreatePathLine(paths));

        // ���@�|�C���g�ł��B���̏��������̕K�v�Ȃ̂����l���Ă݂܂��傤�B
        yield return new WaitUntil(() => gameManager.currentGameState == GameManager.GameState.Play);

        // �G�̈ړ����ĊJ
        enemyController.ResumeMove();
    }

    // �ړ��o�H�p�̃��C���̐����Ɣj��
    private IEnumerator CreatePathLine(Vector3[] paths)
    {
        // List �̐錾�Ə�����
        List<DrawPathLine> drawPathLinesList = new List<DrawPathLine>();

        // �P�� Path ���ƂɂP�����ԂɃ��C���𐶐�
        for (int i = 0; i < paths.Length - 1; i++)
        {
            DrawPathLine drawPathLine = Instantiate(pathLinePrefab, transform.position, Quaternion.identity);

            Vector3[] drawPaths = new Vector3[2] { paths[i], paths[i + 1] };

            drawPathLine.CreatePathLine(drawPaths);

            drawPathLinesList.Add(drawPathLine);

            yield return new WaitForSeconds(0.1f);
        }

        // ���ׂẴ��C���𐶐����đҋ@
        yield return new WaitForSeconds(0.5f);

        // �P�̃��C�������Ԃɍ폜����
        for (int i = 0; i < drawPathLinesList.Count; i++)
        {
            Destroy(drawPathLinesList[i].gameObject);

            yield return new WaitForSeconds(0.1f);
        }
    }
}
