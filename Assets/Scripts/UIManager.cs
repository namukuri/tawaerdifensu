using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // TextMeshPro�𗘗p���邽�߂̖��O���
using DG.Tweening;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private TMP_Text txtCost;

    // �J�����V�[�̕\���X�V
    public void UpdateDisplayCurrency()
    {
        txtCost.text = GameData.instance.currency.ToString();
    }
}
