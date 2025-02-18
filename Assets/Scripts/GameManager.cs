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

    // GameState の変更
    public void SetGameState(GameState nextGameState)
    {
        currentGameState = nextGameState;
    } 

}

     