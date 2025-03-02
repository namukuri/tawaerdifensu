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

    ////*  新しい enum の作成と enum 型の変数の宣言を追加  *////
    // ゲームの状態
    public enum GameState
    {
        Preparate, // ゲーム開始前の準備中
        Play, // ゲームプレイ中
        Stop, // ゲーム内の処理の一時停止中
        GameUp // ゲーム終了(ゲームオーバー、クリア両方)
    }

    public GameState currentGameState; // 現在の GameState の状態。上記の GameState の列挙子が１つだけ代入されるので、他の GameState と競合しない

    [SerializeField]
    private List<EnemyController> enemiesList = new List<EnemyController>(); //　敵の情報を一元化して管理するための変数。EnemyController 型で扱う

    private int destroyEnemyCount; //  敵を破壊した数のカウント用

    public UIManager uiManager;

    [SerializeField]
    private List<CharaController> charaList = new List<CharaController>(); // 配置したキャラの情報を一元化して管理するための変数。CharaController 型で扱う

    // Start is called before the first frame update
    void Start()
    {
        // ゲームの進行状態を準備中に設定
        SetGameState(GameState.Preparate);

        // TODO ゲームデータを初期化

        // TODO ステージの設定 + ステージごとの PathData を設定

        // キャラ配置用ポップアップの生成と設定
        StartCoroutine(charaGenerator.SetUpCharaGenerator(this));

        // TODO 拠点の設定

        // TODO オープニング演出再生

        isEnemyGenerate = true;

        // ゲームの進行状態をプレイ中に変更
        SetGameState(GameState.Play);

        // 敵の生成準備開始
        StartCoroutine(enemyGenerator.PreparateEnemyGenerate(this));

        // TODO カレンシーの自動獲得処理の開始
        StartCoroutine(TimeToCurrency());
    }

    // 敵の情報を List に追加
    public void AddEnemyList(EnemyController enemy) //　TODO　敵の情報を List に追加する際に、引数を追加
    {
        //敵の情報を List に追加
        enemiesList.Add(enemy);

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

    // GameState の変更
    public void SetGameState(GameState nextGameState)
    {
        currentGameState = nextGameState;
    }

    // すべての敵の移動を一時停止
    public void PauseEnemies()
    {
        for (int i = 0; i < enemiesList.Count; i++)
        {
            enemiesList[i].PauseMove();
        }
    }

    // すべての敵の移動を再開
    public void ResumeEnemies()
    {
        for (int i = 0; i < enemiesList.Count; i++)
        {
            enemiesList[i].ResumeMove();
        }
    }

    // 敵の情報を List から削除
    public void RemoveEnemyList(EnemyController removeEnemy)
    {
        enemiesList.Remove(removeEnemy);
    }

    // 破壊した敵の数をカウント(このメソッドを外部のクラスから実行してもらう)
    public void CountUpDestroyEnemyCount(EnemyController enemyController)
    {
        // List から破壊された敵の情報を削除
        RemoveEnemyList(enemyController);

        // 敵を破壊した数を加算
        destroyEnemyCount++;

        Debug.Log("破壊した敵の数:" + destroyEnemyCount);

        // ゲームクリア判定
        JudgeGameClear();
    }

    // ゲームクリア判定
    public void JudgeGameClear()
    {
        // 生成数を超えているか
        if (destroyEnemyCount >= maxEnemyCount)
        {
            Debug.Log("ゲームクリア");

            // TODO ゲームクリアの処理を追加
        }
    }

    // 時間の経過に応じてカレンシーを加算
    public IEnumerator TimeToCurrency()
    {
        int timer = 0;

        // ゲームプレイ中のみ加算
        while (currentGameState == GameState.Play)
        {
            timer++;

            // 規定の時間が経過し、カレンシーが最大値でなければ
            if (timer > GameData.instance.currencyIntervalTime && GameData.instance.currency < GameData.instance.maxCurrency)
            {
                timer = 0;

                // 最大値以下になるようにカレンシーを加算
                GameData.instance.currency = Mathf.Clamp(GameData.instance.currency += GameData.instance.addCurrencyPoint, 0, GameData.instance.maxCurrency);

                // カレンシーの画面表示を更新
                uiManager.UpdateDisplayCurrency();
            }

            yield return null;
        }

    }

    // 選択したキャラの情報を List に追加
    public void AddCharaList(CharaController chara)
    {
        charaList.Add(chara);
    }

    // 選択したキャラを破棄し、情報を List から削除
    public void RemoveCharaList(CharaController chara)
    {
        Destroy(chara.gameObject);
        charaList.Remove(chara);
    }

    // 現在の配置しているキャラの数の取得
    public int GetPlacementCharaCount()
    {
        return charaList.Count;
    }
}

