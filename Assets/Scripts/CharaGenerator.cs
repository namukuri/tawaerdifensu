using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps; //�@<=�@�^�C���}�b�v�̋@�\���������߂ɕK�v�Ȑ錾��ǉ����܂��B

public class CharaGenerator : MonoBehaviour
{
    [SerializeField]
    private GameObject charaPrefab; // �L�����̃v���t�@�u�̓o�^�p
    [SerializeField]
    private Grid grid; // �^�C���}�b�v�̍��W���擾���邽�߂̏��BGrid_Base ���� Grid ���w�肷�� 
    [SerializeField]
    private Tilemap tilemaps; // Walk ���� Tilemap ���w�肷��
    private Vector3Int gridPos; // �^�C���}�b�v�̃^�C���̃Z�����W�̕ێ��p    

    // Update is called once per frame
    void Update()
    {
        // TODO �z�u�ł���ő�L�������ɒB���Ă���ꍇ�ɂ͔z�u�ł��Ȃ�

        // ��ʂ��^�b�v(�}�E�X�N���b�N)������
        if(Input.GetMouseButtonDown(0))
        {
            // �^�b�v(�}�E�X�N���b�N)�̈ʒu���擾���ă��[���h���W�ɕϊ����A���������Ƀ^�C���̃Z�����W�ɕϊ�
            gridPos = grid.WorldToCell(Camera.main.ScreenToWorldPoint(Input.mousePosition));

            // �^�b�v�����ʒu�̃^�C���̃R���C�_�[�̏����m�F���A���ꂪ None �ł���Ȃ�
            if(tilemaps.GetColliderType(gridPos) == Tile.ColliderType.None)
            {
                // �L�����������������\�b�h��
                CreateChara(gridPos);
            }

        }

    }

    // �L��������
    private void CreateChara(Vector3Int gridPos)
    {
        // �^�b�v�����ʒu�ɃL�����𐶐����Ĕz�u
        GameObject chara = Instantiate(charaPrefab, gridPos, Quaternion.identity);

        // �L�����̈ʒu���^�C���̍����� 0,0 �Ƃ��Đ������Ă���̂ŁA�^�C���̒����ɂ���悤�Ɉʒu�𒲐�
        chara.transform.position = new Vector2(chara.transform.position.x + 0.5f, chara.transform.position.y + 0.5f);
    }
}
