using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class SelectCharaDetail : MonoBehaviour
{
    [SerializeField]
    private Button btnSelectCharaDetail;

    [SerializeField]
    private Image imgChara;

    private PlacementCharaSelectPopUp placementCharaSelectPop;

    private CharaData charaData;

    // SelectCharaDetail の設定
    public void SetUpSelectCharaDetail(PlacementCharaSelectPopUp placementCharaSelectPop, CharaData charaData)
    {
        this.placementCharaSelectPop = placementCharaSelectPop;
        this.charaData = charaData;

        // TODO ボタンを押せない状態に切り替える
        ChangeActivateButton(false);

        imgChara.sprite = this.charaData.charaSprite;

        // ボタンにメソッドを登録
        btnSelectCharaDetail.onClick.AddListener(OnClickSelectCharaDetail);

        // TODO コストに応じてボタンを押せるかどうかを切り替える
        ChangeActivateButton(JudgePermissionCost(GameData.instance.currency));

    }

    // SelectCharaDetail を押したの処理
    private void OnClickSelectCharaDetail()
    {
        // TODO アニメ演出

        // タップした SelectCharaDetail の情報をポップアップに送る
        // TODO 次の手順で、PlacementCharaSelectPop スクリプト内に SetSelectCharaDetail メソッドを作成するため、それまでコメントアウトしておいてください
        placementCharaSelectPop.SetSelectCharaDetail(charaData);
    }

    // ボタンを押せる状態の切り替え
    public void ChangeActivateButton(bool isSwitch)
    {
        btnSelectCharaDetail.interactable = isSwitch;
    }
    // コストが支払えるか確認する
    public bool JudgePermissionCost(int value)
    {
        Debug.Log("コスト確認"); //　<=　たくさん表示されることになりますので、処理の確認が取れたらコメントアウトしてください。

        // コストが支払える場合
        if (charaData.cost <= value)
        {
            // ボタンを押せる状態にする
            ChangeActivateButton(true);
            return true;
        }
        return false;
    }

    // ボタンの状態の取得(今後のために実装
    public bool GetActivateButtonState()
    {
        return btnSelectCharaDetail.interactable;
    }

    // CharaData の取得(今後のために実装)
    public CharaData GetCharaData()
    {
        return charaData;
    }
}
