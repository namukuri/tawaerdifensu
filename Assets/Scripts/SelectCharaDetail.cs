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

    // SelectCharaDetail �̐ݒ�
    public void SetUpSelectCharaDetail(PlacementCharaSelectPopUp placementCharaSelectPop, CharaData charaData)
    {
        this.placementCharaSelectPop = placementCharaSelectPop;
        this.charaData = charaData;

        // TODO �{�^���������Ȃ���Ԃɐ؂�ւ���
        ChangeActivateButton(false);

        imgChara.sprite = this.charaData.charaSprite;

        // �{�^���Ƀ��\�b�h��o�^
        btnSelectCharaDetail.onClick.AddListener(OnClickSelectCharaDetail);

        // TODO �R�X�g�ɉ����ă{�^���������邩�ǂ�����؂�ւ���
        ChangeActivateButton(JudgePermissionCost(GameData.instance.currency));

    }

    // SelectCharaDetail ���������̏���
    private void OnClickSelectCharaDetail()
    {
        // TODO �A�j�����o

        // �^�b�v���� SelectCharaDetail �̏����|�b�v�A�b�v�ɑ���
        // TODO ���̎菇�ŁAPlacementCharaSelectPop �X�N���v�g���� SetSelectCharaDetail ���\�b�h���쐬���邽�߁A����܂ŃR�����g�A�E�g���Ă����Ă�������
        placementCharaSelectPop.SetSelectCharaDetail(charaData);
    }

    // �{�^�����������Ԃ̐؂�ւ�
    public void ChangeActivateButton(bool isSwitch)
    {
        btnSelectCharaDetail.interactable = isSwitch;
    }
    // �R�X�g���x�����邩�m�F����
    public bool JudgePermissionCost(int value)
    {
        Debug.Log("�R�X�g�m�F"); //�@<=�@��������\������邱�ƂɂȂ�܂��̂ŁA�����̊m�F����ꂽ��R�����g�A�E�g���Ă��������B

        // �R�X�g���x������ꍇ
        if (charaData.cost <= value)
        {
            // �{�^�����������Ԃɂ���
            ChangeActivateButton(true);
            return true;
        }
        return false;
    }

    // �{�^���̏�Ԃ̎擾(����̂��߂Ɏ���
    public bool GetActivateButtonState()
    {
        return btnSelectCharaDetail.interactable;
    }

    // CharaData �̎擾(����̂��߂Ɏ���)
    public CharaData GetCharaData()
    {
        return charaData;
    }
}
