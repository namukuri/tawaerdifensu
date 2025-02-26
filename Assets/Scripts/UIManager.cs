using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private Text txtCost;

    // �J�����V�[�̕\���X�V
    public void UpdateDisplayCurrency()
    {
        txtCost.text = GameData.Instance.currency.ToString();
    }
}
