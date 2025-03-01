using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps; //�@<=�@�^�C���}�b�v�̋@�\���������߂ɕK�v�Ȑ錾��ǉ����܂��B

public class CharaGenerator : MonoBehaviour
{
    //[SerializeField]
    //private GameObject charaPrefab; // �L�����̃v���t�@�u�̓o�^�p

    [SerializeField]
    private CharaController charaControllerPrefab; //<=�@���@�V�����ACharaCotroller �^�ŕϐ���錾���܂��B�A�T�C������v���t�@�u�͓������̂ł�

    [SerializeField]
    private Grid grid; // �^�C���}�b�v�̍��W���擾���邽�߂̏��BGrid_Base ���� Grid ���w�肷�� 

    [SerializeField]
    private Tilemap tilemaps; // Walk ���� Tilemap ���w�肷��

    [SerializeField]
    private PlacementCharaSelectPopUp placementCharaSelectPopUpPrefab; //�@PlacementCharaSelectPopUp �v���t�@�u�Q�[���I�u�W�F�N�g���A�T�C���p

    [SerializeField]
    private Transform canvasTran; //�@PlacementCharaSelectPopUp �Q�[���I�u�W�F�N�g�̐����ʒu�̓o�^�p

    [SerializeField, Header("�L�����̃f�[�^���X�g")]
    private List<CharaData> charaDatasList = new List<CharaData>();

    private PlacementCharaSelectPopUp placementCharaSelectPopUp; //�@�������ꂽ PlacementCharaSelectPopUp �Q�[���I�u�W�F�N�g�������邽�߂̕ϐ�

    private GameManager gameManager;

    private Vector3Int gridPos; // �^�C���}�b�v�̃^�C���̃Z�����W�̕ێ��p    

    // Update is called once per frame
    void Update()
    {
        // TODO �z�u�ł���ő�L�������ɒB���Ă���ꍇ�ɂ͔z�u�ł��Ȃ�
        if (gameManager.GetPlacementCharaCount() >= GameData.instance.maxCharaPlacementCount)
        {
            return;
        }

        // ��ʂ��^�b�v(�}�E�X�N���b�N)���A���A�z�u�L�����|�b�v�A�b�v����\���A���A�Q�[���̌��݂̐i�s��Ԃ� Play �Ȃ�
        if (Input.GetMouseButtonDown(0) && !placementCharaSelectPopUp.gameObject.activeSelf && gameManager.currentGameState == GameManager.GameState.Play)
        {
            // �^�b�v(�}�E�X�N���b�N)�̈ʒu���擾���ă��[���h���W�ɕϊ����A���������Ƀ^�C���̃Z�����W�ɕϊ�
            gridPos = grid.WorldToCell(Camera.main.ScreenToWorldPoint(Input.mousePosition));

            // �^�b�v�����ʒu�̃^�C���̃R���C�_�[�̏����m�F���A���ꂪ None �ł���Ȃ�
            if(tilemaps.GetColliderType(gridPos) == Tile.ColliderType.None)
            {
                // �L�����������������\�b�h��
                //CreateChara(gridPos);

                // �z�u�L�����I��p�|�b�v�A�b�v�̕\��
                ActivatePlacementCharaSelectPopUp(); //�@<=�@���A�@TODO ���������܂�
            }

        }

    }

    // �L��������
    //private void CreateChara(Vector3Int gridPos)
    //{
        // �^�b�v�����ʒu�ɃL�����𐶐����Ĕz�u
        //GameObject chara = Instantiate(charaPrefab, gridPos, Quaternion.identity);

        // �L�����̈ʒu���^�C���̍����� 0,0 �Ƃ��Đ������Ă���̂ŁA�^�C���̒����ɂ���悤�Ɉʒu�𒲐�
        //chara.transform.position = new Vector2(chara.transform.position.x + 0.5f, chara.transform.position.y + 0.5f);
    //}

    // �ݒ�
    public IEnumerator SetUpCharaGenerator(GameManager gameManager)
    {
        this.gameManager = gameManager;

        // TODO �X�e�[�W�̃f�[�^���擾

        // TODO �L�����̃f�[�^�����X�g��
        CreateHaveCharaDatasList();

        // �L�����z�u�p�̃|�b�v�A�b�v�̐���
        yield return StartCoroutine(CreatePlacementCharaSelectPopUp());

    }

    // �z�u�L�����I��p�|�b�v�A�b�v����
    private IEnumerator CreatePlacementCharaSelectPopUp()
    {
        // �|�b�v�A�b�v�𐶐��B�L�����ݒ�p�̏����n���B
        placementCharaSelectPopUp = Instantiate(placementCharaSelectPopUpPrefab, canvasTran, false);
        // TODO ���ƂŃL�����ݒ�p�̏����n��
        placementCharaSelectPopUp.SetUpPlacementCharaSelectPopUp(this, charaDatasList); //��2������ǉ����܂�

        // �|�b�v�A�b�v���\���ɂ���
        placementCharaSelectPopUp.gameObject.SetActive(false);

        yield return null;
    }

    // �z�u�L�����I��p�̃|�b�v�A�b�v�̕\��
    public void ActivatePlacementCharaSelectPopUp()
    {
        // TODO �Q�[���̐i�s��Ԃ��Q�[����~�ɕύX
        gameManager.SetGameState(GameManager.GameState.Stop);

        // TODO ���ׂĂ̓G�̈ړ����ꎞ��~
        gameManager.PauseEnemies();

        // �z�u�L�����I��p�̃|�b�v�A�b�v�̕\��
        placementCharaSelectPopUp.gameObject.SetActive(true);
        placementCharaSelectPopUp.ShowPopUp();
    }

    // �z�u�L�����I��p�̃|�b�v�A�b�v�̔�\��
    public void InactivatePlacementCharaSelectPopUp()
    {
        // �z�u�L�����I��p�̃|�b�v�A�b�v�̔�\��
        placementCharaSelectPopUp.gameObject.SetActive(false);

        // TODO �Q�[���I�[�o�[��Q�[���N���A�ł͂Ȃ��ꍇ
        if (gameManager.currentGameState == GameManager.GameState.Stop)
        {
            // TODO �Q�[���̐i�s��Ԃ��v���C���ɕύX���āA�Q�[���ĊJ
            gameManager.SetGameState(GameManager.GameState.Play);

            // TODO ���ׂĂ̓G�̈ړ����ĊJ
            gameManager.ResumeEnemies();

            // TODO �J�����V�[�̉��Z�������ĊJ
            StartCoroutine(gameManager.TimeToCurrency());
        }
    }

    // �L�����̃f�[�^�����X�g��
    private void CreateHaveCharaDatasList()
    {
        // CharaDataSO �X�N���v�^�u���E�I�u�W�F�N�g���� CharaData ���P�����X�g�ɒǉ�
        // TODO �X�N���v�^�u���E�I�u�W�F�N�g�ł͂Ȃ��A���ۂɃv���C���[���������Ă���L�����̔ԍ������ɃL�����̃f�[�^�̃��X�g���쐬
        for (int i = 0; i < DataBaseManager.instance.charaDataSO.charaDatasList.Count; i++)
        {
            charaDatasList.Add(DataBaseManager.instance.charaDataSO.charaDatasList[i]);
        }
    }

    // �I�������L�����𐶐����Ĕz�u
    public void CreateChooseChara(CharaData charaData)
    {
        // TODO �R�X�g�x����
        GameData.instance.currency -= charaData.cost;

        // �J�����V�[�̉�ʕ\�����X�V
        gameManager.uiManager.UpdateDisplayCurrency();

        // �L�������^�b�v�����ʒu�ɐ���
        CharaController chara = Instantiate(charaControllerPrefab, gridPos, Quaternion.identity);

        // �ʒu�������� 0,0 �Ƃ��Ă���̂ŁA�����ɂ���悤�ɒ���
        chara.transform.position = new Vector2(chara.transform.position.x + 0.5f, chara.transform.position.y + 0.5f);

        // TODO �L�����̐ݒ�
        chara.SetUpChara(charaData, gameManager);

        Debug.Log(charaData.charaName);

        // TODO �L������ List �ɒǉ�
        gameManager.AddChraList(chara);
    }


}
