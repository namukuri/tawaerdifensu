using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // TextMeshProを利用するための名前空間
using DG.Tweening;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private TMP_Text txtCost;

    // カレンシーの表示更新
    public void UpdateDisplayCurrency()
    {
        txtCost.text = GameData.instance.currency.ToString();
    }
}
