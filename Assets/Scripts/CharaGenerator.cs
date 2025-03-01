using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps; //　<=　タイルマップの機能を扱うために必要な宣言を追加します。

public class CharaGenerator : MonoBehaviour
{
    //[SerializeField]
    //private GameObject charaPrefab; // キャラのプレファブの登録用

    [SerializeField]
    private CharaController charaControllerPrefab; //<=　☆　新しく、CharaCotroller 型で変数を宣言します。アサインするプレファブは同じものです

    [SerializeField]
    private Grid grid; // タイルマップの座標を取得するための情報。Grid_Base 側の Grid を指定する 

    [SerializeField]
    private Tilemap tilemaps; // Walk 側の Tilemap を指定する

    [SerializeField]
    private PlacementCharaSelectPopUp placementCharaSelectPopUpPrefab; //　PlacementCharaSelectPopUp プレファブゲームオブジェクトをアサイン用

    [SerializeField]
    private Transform canvasTran; //　PlacementCharaSelectPopUp ゲームオブジェクトの生成位置の登録用

    [SerializeField, Header("キャラのデータリスト")]
    private List<CharaData> charaDatasList = new List<CharaData>();

    private PlacementCharaSelectPopUp placementCharaSelectPopUp; //　生成された PlacementCharaSelectPopUp ゲームオブジェクトを代入するための変数

    private GameManager gameManager;

    private Vector3Int gridPos; // タイルマップのタイルのセル座標の保持用    

    // Update is called once per frame
    void Update()
    {
        // TODO 配置できる最大キャラ数に達している場合には配置できない
        if (gameManager.GetPlacementCharaCount() >= GameData.instance.maxCharaPlacementCount)
        {
            return;
        }

        // 画面をタップ(マウスクリック)し、かつ、配置キャラポップアップが非表示、かつ、ゲームの現在の進行状態が Play なら
        if (Input.GetMouseButtonDown(0) && !placementCharaSelectPopUp.gameObject.activeSelf && gameManager.currentGameState == GameManager.GameState.Play)
        {
            // タップ(マウスクリック)の位置を取得してワールド座標に変換し、それをさらにタイルのセル座標に変換
            gridPos = grid.WorldToCell(Camera.main.ScreenToWorldPoint(Input.mousePosition));

            // タップした位置のタイルのコライダーの情報を確認し、それが None であるなら
            if(tilemaps.GetColliderType(gridPos) == Tile.ColliderType.None)
            {
                // キャラ生成処理をメソッド化
                //CreateChara(gridPos);

                // 配置キャラ選択用ポップアップの表示
                ActivatePlacementCharaSelectPopUp(); //　<=　☆②　TODO を実装します
            }

        }

    }

    // キャラ生成
    //private void CreateChara(Vector3Int gridPos)
    //{
        // タップした位置にキャラを生成して配置
        //GameObject chara = Instantiate(charaPrefab, gridPos, Quaternion.identity);

        // キャラの位置がタイルの左下を 0,0 として生成しているので、タイルの中央にくるように位置を調整
        //chara.transform.position = new Vector2(chara.transform.position.x + 0.5f, chara.transform.position.y + 0.5f);
    //}

    // 設定
    public IEnumerator SetUpCharaGenerator(GameManager gameManager)
    {
        this.gameManager = gameManager;

        // TODO ステージのデータを取得

        // TODO キャラのデータをリスト化
        CreateHaveCharaDatasList();

        // キャラ配置用のポップアップの生成
        yield return StartCoroutine(CreatePlacementCharaSelectPopUp());

    }

    // 配置キャラ選択用ポップアップ生成
    private IEnumerator CreatePlacementCharaSelectPopUp()
    {
        // ポップアップを生成。キャラ設定用の情報も渡す。
        placementCharaSelectPopUp = Instantiate(placementCharaSelectPopUpPrefab, canvasTran, false);
        // TODO あとでキャラ設定用の情報も渡す
        placementCharaSelectPopUp.SetUpPlacementCharaSelectPopUp(this, charaDatasList); //第2引数を追加します

        // ポップアップを非表示にする
        placementCharaSelectPopUp.gameObject.SetActive(false);

        yield return null;
    }

    // 配置キャラ選択用のポップアップの表示
    public void ActivatePlacementCharaSelectPopUp()
    {
        // TODO ゲームの進行状態をゲーム停止に変更
        gameManager.SetGameState(GameManager.GameState.Stop);

        // TODO すべての敵の移動を一時停止
        gameManager.PauseEnemies();

        // 配置キャラ選択用のポップアップの表示
        placementCharaSelectPopUp.gameObject.SetActive(true);
        placementCharaSelectPopUp.ShowPopUp();
    }

    // 配置キャラ選択用のポップアップの非表示
    public void InactivatePlacementCharaSelectPopUp()
    {
        // 配置キャラ選択用のポップアップの非表示
        placementCharaSelectPopUp.gameObject.SetActive(false);

        // TODO ゲームオーバーやゲームクリアではない場合
        if (gameManager.currentGameState == GameManager.GameState.Stop)
        {
            // TODO ゲームの進行状態をプレイ中に変更して、ゲーム再開
            gameManager.SetGameState(GameManager.GameState.Play);

            // TODO すべての敵の移動を再開
            gameManager.ResumeEnemies();

            // TODO カレンシーの加算処理を再開
            StartCoroutine(gameManager.TimeToCurrency());
        }
    }

    // キャラのデータをリスト化
    private void CreateHaveCharaDatasList()
    {
        // CharaDataSO スクリプタブル・オブジェクト内の CharaData を１つずつリストに追加
        // TODO スクリプタブル・オブジェクトではなく、実際にプレイヤーが所持しているキャラの番号を元にキャラのデータのリストを作成
        for (int i = 0; i < DataBaseManager.instance.charaDataSO.charaDatasList.Count; i++)
        {
            charaDatasList.Add(DataBaseManager.instance.charaDataSO.charaDatasList[i]);
        }
    }

    // 選択したキャラを生成して配置
    public void CreateChooseChara(CharaData charaData)
    {
        // TODO コスト支払い
        GameData.instance.currency -= charaData.cost;

        // カレンシーの画面表示を更新
        gameManager.uiManager.UpdateDisplayCurrency();

        // キャラをタップした位置に生成
        CharaController chara = Instantiate(charaControllerPrefab, gridPos, Quaternion.identity);

        // 位置が左下を 0,0 としているので、中央にくるように調整
        chara.transform.position = new Vector2(chara.transform.position.x + 0.5f, chara.transform.position.y + 0.5f);

        // TODO キャラの設定
        chara.SetUpChara(charaData, gameManager);

        Debug.Log(charaData.charaName);

        // TODO キャラを List に追加
        gameManager.AddChraList(chara);
    }


}
