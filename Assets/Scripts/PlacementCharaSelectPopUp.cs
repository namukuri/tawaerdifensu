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

    [SerializeField]
    private Image imgPickupChara;

    [SerializeField]
    private Text txtPickupCharaName;

    [SerializeField]
    private Text txtPickupCharaAttackPower;

    [SerializeField]
    private Text txtPickupCharaAttackRangeType;

    [SerializeField]
    private Text txtPickupCharaCost;

    [SerializeField]
    private Text txtPickupCharaMaxAttackCount;

    [SerializeField]
    private SelectCharaDetail selectCharaDetailPrefab; //�L�����̃{�^���p�̃v���t�@�u���A�T�C������

    [SerializeField]
    private Transform selectCharaDetailTran; //�L�����̃{�^���𐶐�����ʒu���A�T�C������

    [SerializeField]
    private List<SelectCharaDetail> selectCharaDetailsList = new List<SelectCharaDetail>(); //���������L�����̃{�^�����Ǘ�����
                                    
    private CharaData chooseCharaData; //���ݑI�����Ă���L�����̏����Ǘ�����
                      
   

    // �|�b�v�A�b�v�̐ݒ�
    public void SetUpPlacementCharaSelectPopUp(CharaGenerator charaGenerator, List<CharaData> haveCharaDataList)
    {
        this.charaGenerator = charaGenerator;

        // TODO ���ɐݒ荀�ڂ���������ǉ�����

        // �|�b�v�A�b�v����x�����Ȃ���Ԃɂ���
        canvasGroup.alpha = 0;

        // �e�{�^���̑���������Ȃ���Ԃɂ���
        SwithcActivateButtons(false);

        // �X�N���v�^�u���E�I�u�W�F�N�g�ɓo�^����Ă���L������(�����Ŏ󂯎�������)�𗘗p����
        for (int i = 0; i < haveCharaDataList.Count; i++)
        {
            // �{�^���̃Q�[���I�u�W�F�N�g�𐶐�
            SelectCharaDetail selectCharaDetail = Instantiate(selectCharaDetailPrefab, selectCharaDetailTran, false);

            // �{�^���̃Q�[���I�u�W�F�N�g�̐ݒ�iCharaData ��ݒ肷��j
            selectCharaDetail.SetUpSelectCharaDetail(this, haveCharaDataList[i]);

            // List�ɒǉ�
            selectCharaDetailsList.Add(selectCharaDetail);

            //�ŏ��ɐ��������{�^���̏ꍇ
            if (i == 0)
            {
                // �I�����Ă���L�����Ƃ��ď����l�ɐݒ�
                SetSelectCharaDetail(haveCharaDataList[i]);
            }
        }

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
        CheckAllCharaButtons();

        // �|�b�v�A�b�v�̕\��
        canvasGroup.DOFade(1.0f, 0.5f);
    }

    // �I�����Ă���L������z�u����{�^�����������ۂ̏���
    private void OnClickSubmitChooseChara()
    {
        // TODO �R�X�g�̎x�������\���ŏI�m�F
        if (chooseCharaData.cost > GameData.instance.currency)
        {
            return;
        }

        // TODO �I�����Ă���L�����̐���
        charaGenerator.CreateChooseChara(chooseCharaData);

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
        CheckAllCharaButtons();

        // �|�b�v�A�b�v�̔�\��
        canvasGroup.DOFade(0, 0.5f).OnComplete(() => charaGenerator.InactivatePlacementCharaSelectPopUp());
    }

    // �I�����ꂽ SelectCharaDetail �̏����|�b�v�A�b�v���̃s�b�N�A�b�v�ɕ\������
    public void SetSelectCharaDetail(CharaData charaData)
    {
        chooseCharaData = charaData;
        
        // �e�l�̐ݒ�
        imgPickupChara.sprite = charaData.charaSprite;

        txtPickupCharaName.text = charaData.charaName;

        txtPickupCharaAttackPower.text = charaData.attackPower.ToString();

        txtPickupCharaAttackRangeType.text = charaData.attackRange.ToString();

        txtPickupCharaCost.text = charaData.cost.ToString();

        txtPickupCharaMaxAttackCount.text = charaData.maxAttackCount.ToString();

    }

    // �R�X�g���x�����邩�ǂ����� �e SelectCharaDetail �Ŋm�F���ă{�^�������@�\��؂�ւ�
    private void CheckAllCharaButtons()
    {
        // �z�u�ł���L����������ꍇ�̂ݏ������s��
        if(selectCharaDetailsList.Count > 0) 
        {
            // �e�L�����̃R�X�g�ƃJ�����V�[���m�F���āA�z�u�ł��邩�ǂ����𔻒肵�ă{�^���̉����L����ݒ�
            for (int i = 0; i < selectCharaDetailsList.Count; i++)
            {
                selectCharaDetailsList[i].ChangeActivateButton(selectCharaDetailsList[i].JudgePermissionCost(GameData.instance.currency));
            }
        }
    }

}
