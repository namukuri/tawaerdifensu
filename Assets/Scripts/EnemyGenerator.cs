using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    [SerializeField]
    private EnemyController enemyControllerPrefab;

    [SerializeField]
    private PathData pathData;

    public bool isEnemyGenerate;

    public int generateIntervalTime;

    public int generateEnemyCount;

    public int maxEnemyCount;

    // Start is called before the first frame update
    void Start()
    {

        // �����̋�������
        isEnemyGenerate = true;

        // �G�̐�������
        StartCoroutine(PreparateEnemyGenerate());
    }

    /// <summary>
    /// �G�̐�������
    /// </summary>
    /// <returns></returns>
    public IEnumerator PreparateEnemyGenerate()
    {
        // �����p�̃^�C�}�[�p��
        int timer = 0;

        // isEnemyGenetate �� true �̊Ԃ̓��[�v����
        while (isEnemyGenerate)
        {

            // �^�C�}�[�����Z
            timer++;

            // �^�C�}�[�̒l���G�̐����ҋ@���Ԃ𒴂�����
            if (timer > generateIntervalTime)
            {
                // ���̐����̂��߂Ƀ^�C�}�[�����Z�b�g
                timer = 0;

                // �G�̐���
                GenerateEnemy();

                // �������������J�E���g�A�b�v
                generateEnemyCount++;

                // �G�̍ő吶�����𒴂�����
                if (generateEnemyCount >= maxEnemyCount)
                {
                    // ������~
                    isEnemyGenerate = false;
                }
            }
            // 1�t���[�����f  
            yield return null;
        }

        // TODO �����I����̏������L�q����

    }

    // �G�̐���
    public void GenerateEnemy()
    {
    // �w�肵���ʒu�ɓG�𐶐�
    EnemyController enemyController = Instantiate(enemyControllerPrefab, pathData.generateTran.position, Quaternion.identity);

    // TODO ������������������{��̃R�����g�Ƃ��Ďc���Ă����悤�ɂ���

    }
}
