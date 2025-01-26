using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    [SerializeField]
    private EnemyController enemyControllerPrefab;

    [SerializeField]
    private PathData pathData;

    private GameManager gameManager; //　☆　追加します

    //public bool isEnemyGenerate; //　☆　以下４つの変数を削除します

    //public int generateIntervalTime;

    //public int generateEnemyCount;

    //public int maxEnemyCount;

    // Start is called before the first frame update
    //void Start()
    //{

        // 生成の許可をする
        //isEnemyGenerate = true;

        // 敵の生成準備
        //StartCoroutine(PreparateEnemyGenerate());
    //}

    /// <summary>
    /// 敵の生成準備
    /// </summary>
    /// <returns></returns>
    public IEnumerator PreparateEnemyGenerate(GameManager gameManager)
    {

        this.gameManager = gameManager; //　☆②　処理を追加します

        // 生成用のタイマー用意
        int timer = 0;

        // isEnemyGenetate が true の間はループする
        while (gameManager.isEnemyGenerate)
        {

            // タイマーを加算
            timer++;

            // タイマーの値が敵の生成待機時間を超えたら
            if (timer > gameManager.generateIntervalTime)  //  ☆④　条件の右辺を変更します
            {
                // 次の生成のためにタイマーをリセット
                timer = 0;

                // 敵の生成
                GenerateEnemy();

                // 敵の生成数のカウントアップと List への追加
                gameManager.AddEnemyList(); //　☆追加します

                // 最大生成数を超えたら生成停止
                gameManager.JudgeGenerateEnemysEnd();

                // 生成した数をカウントアップ
                //generateEnemyCount++;

                // 敵の最大生成数を超えたら
                //if (generateEnemyCount >= maxEnemyCount)
                //{
                    // 生成停止
                    //isEnemyGenerate = false;
                //}
            }
            // 1フレーム中断  
            yield return null;
        }

        // TODO 生成終了後の処理を記述する

    }

    // 敵の生成
    public void GenerateEnemy()
    {
    // 指定した位置に敵を生成
    EnemyController enemyController = Instantiate(enemyControllerPrefab, pathData.generateTran.position, Quaternion.identity);

    // TODO 実装したい処理を日本語のコメントとして残しておくようにする

    }
}
