using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;


public class PlacementCharaSelectPopUp : MonoBehaviour
{
    [SerializeField]
    private Button btnClosePopUp;

    [SerializeField]
    private Button btnChooseChara;

    [SerializeField]
    private CanvasGroup canvasGroup;

    private CharaGenerator charaGenerator;

    // TODO ������s�������e�R���|�[�l���g�̏����A�T�C�����邽�߂̕ϐ��Q��ǉ�����

    // �|�b�v�A�b�v�̐ݒ�
    public void SetUpPlacementCharaSelectPopUp(CharaGenerator charaGenerator)
    {
        this.charaGenerator = charaGenerator;

        // TODO ���ɐݒ荀�ڂ���������ǉ�����

        // �|�b�v�A�b�v����x�����Ȃ���Ԃɂ���
        canvasGroup.alpha = 0;

        // �e�{�^���̑���������Ȃ���Ԃɂ���
        SwithcActivateButtons(false);

        // TODO �X�N���v�^�u���E�I�u�W�F�N�g�ɓo�^����Ă���L�������̃{�^���̃Q�[���I�u�W�F�N�g�𐶐�

        // TODO �ŏ��ɐ��������{�^���̏ꍇ

        // TODO �I�����Ă���L�����Ƃ��ď����l�ɐݒ�

        // �e�{�^���Ƀ��\�b�h��o�^
        btnChooseChara.onClick.AddListener(OnClickSubmitChooseChara);

        btnClosePopUp.onClick.AddListener(OnClickClosePopUp);

        // �e�{�^�����������Ԃɂ���
        SwithcActivateButtons(true);

    }

    // �e�{�^���̃A�N�e�B�u��Ԃ̐؂�ւ�
    public void SwithcActivateButtons(bool isSwitch)
    {
        btnChooseChara.interactable = isSwitch;
        btnClosePopUp.interactable = isSwitch;

    }

    // �|�b�v�A�b�v�̕\��
    public void ShowPopUp()
    {

        // TODO �e�L�����̃{�^���̐���

        // �|�b�v�A�b�v�̕\��
        canvasGroup.DOFade(1.0f, 0.5f);
    }

    // �I�����Ă���L������z�u����{�^�����������ۂ̏���
    private void OnClickSubmitChooseChara()
    {
        // TODO �R�X�g�̎x�������\���ŏI�m�F

        // TODO �I�����Ă���L�����̐���

        // �|�b�v�A�b�v�̔�\��
        HidePopUp();
    }

    // �z�u���~�߂�{�^�����������ۂ̏���
    private void OnClickClosePopUp()
    {
        // �|�b�v�A�b�v�̔�\��
        HidePopUp();
    }

    // �|�b�v�A�b�v�̔�\��
    private void HidePopUp()
    {
        // TODO �e�L�����̃{�^���̐���

        // �|�b�v�A�b�v�̔�\��
        canvasGroup.DOFade(0, 0.5f).OnComplete(() => charaGenerator.InactivatePlacementCharaSelectPopUp()); // ���̎菇�Ń��\�b�h��ǉ�����̂ŁA����܂ŃR�����g�A�E�g���Ă����Ă��������B
    }
   
}
