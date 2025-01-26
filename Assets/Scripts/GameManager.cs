using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private EnemyGenerator enemyGenerator;

    public bool isEnemyGenerate;  // ‚±‚±‚É EnemyGenerator ƒXƒNƒŠƒvƒg‘¤‚Ì•Ï”‚ð‚S‚ÂˆÚŠÇ‚µ‚Ü‚·

    public int generateIntervalTime;

    public int generateEnemyCount;

    public int maxEnemyCount;

    // Start is called before the first frame update
    void Start()
    {
        isEnemyGenerate = true;

        // “G‚Ì¶¬€”õŠJŽn
        StartCoroutine(enemyGenerator.PreparateEnemyGenerate(this));
    }

    // “G‚Ìî•ñ‚ð List ‚É’Ç‰Á
    public void AddEnemyList() //@TODO@“G‚Ìî•ñ‚ð List ‚É’Ç‰Á‚·‚éÛ‚ÉAˆø”‚ð’Ç‰Á
    {
        //@TODO@“G‚Ìî•ñ‚ð List ‚É’Ç‰Á

        // “G‚Ì¶¬”‚ðƒJƒEƒ“ƒgƒAƒbƒv
        generateEnemyCount++;
    }

    // “G‚Ì¶¬‚ð’âŽ~‚·‚é‚©”»’è
    public void JudgeGenerateEnemysEnd()
    {
        if (generateEnemyCount >= maxEnemyCount)
        {
            isEnemyGenerate = false;

        }
    }
}

     