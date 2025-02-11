using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private EnemyGenerator enemyGenerator;

    [SerializeField]
    private CharaGenerator charaGenerator;
    
    public bool isEnemyGenerate;  // ここに EnemyGenerator スクリプト側の変数を４つ移管します

    public int generateIntervalTime;

    public int generateEnemyCount;

    public int maxEnemyCount;

    // Start is called before the first frame update
    void Start()
    {
        // キャラ配置用ポップアップの生成と設定
        StartCoroutine(charaGenerator.SetUpCharaGenerator(this));

        isEnemyGenerate = true;

        // 敵の生成準備開始
        StartCoroutine(enemyGenerator.PreparateEnemyGenerate(this));
    }

    // 敵の情報を List に追加
    public void AddEnemyList() //　TODO　敵の情報を List に追加する際に、引数を追加
    {
        //　TODO　敵の情報を List に追加

        // 敵の生成数をカウントアップ
        generateEnemyCount++;
    }

    // 敵の生成を停止するか判定
    public void JudgeGenerateEnemysEnd()
    {
        if (generateEnemyCount >= maxEnemyCount)
        {
            isEnemyGenerate = false;

        }
    }
}

     