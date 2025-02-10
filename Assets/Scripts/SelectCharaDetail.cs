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

        imgChara.sprite = this.charaData.charaSprite;

        // �{�^���Ƀ��\�b�h��o�^
        btnSelectCharaDetail.onClick.AddListener(OnClickSelectCharaDetail);

        // TODO �R�X�g�ɉ����ă{�^���������邩�ǂ�����؂�ւ���

    }

    // SelectCharaDetail ���������̏���
    private void OnClickSelectCharaDetail()
    {
        // TODO �A�j�����o

        // �^�b�v���� SelectCharaDetail �̏����|�b�v�A�b�v�ɑ���
        // TODO ���̎菇�ŁAPlacementCharaSelectPop �X�N���v�g���� SetSelectCharaDetail ���\�b�h���쐬���邽�߁A����܂ŃR�����g�A�E�g���Ă����Ă�������
        //placementCharaSelectPop.SetSelectCharaDetail(charaData);
    }
}
