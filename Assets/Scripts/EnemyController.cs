using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System.Linq; //<=�@�錾��ǉ����܂��B


public class EnemyController : MonoBehaviour
{
    [SerializeField, Header("�ړ��o�H�̏��")]
    private PathData pathData;

    [SerializeField, Header("�ړ����x")]
    private float moveSpeed;

    private Vector3[] paths; // �ړ�����e�n�_�������邽�߂̔z��

    private Animator anim; // Animator �R���|�[�l���g�̎擾�p

    //private Vector3 currentPos; // �G�L�����̌��݂̈ʒu���

    // Start is called before the first frame update
    void Start()
    {
        // Animator �R���|�[�l���g���擾���� anim �ϐ��ɑ��
        TryGetComponent(out anim);

        // �ړ�����n�_���擾
        paths = pathData.pathTranArray.Select(x => x.position).ToArray();

        // �ړ�����n�_���擾���邽�߂̔z��̏�����
        // paths = new Vector3[pathData.pathTranArray.Length];

        // �ړ�����ʒu�������Ԃɔz��Ɏ擾
        //for (int i = 0; i < pathData.pathTranArray.Length; i++)
        //{
        //  paths[i] = pathData.pathTranArray[i].position;
        //}

        // �e�n�_�Ɍ����Ĉړ�
        transform.DOPath(paths, 1000 /  moveSpeed).SetEase(Ease.Linear).OnWaypointChange(ChangeAnimeDirection); //<=  �R�ڂ̃��\�b�h��ǉ����܂��B

    }

    //private void Update()
    //{
        // �G�̐i�s�������擾
        //ChangeAnimeDirection();

    //}

    // �G�̐i�s�������擾���āA�ړ��A�j���Ɠ���
    private void ChangeAnimeDirection(int index) //������ǉ����܂�
    {
        Debug.Log(index); //�@<=�@���@�@�ŏI�I�Ȋm�F���I��������A���ƂŃR�����g�A�E�g���Ă����܂��傤

        // ���̈ړ���̒n�_���Ȃ��ꍇ�ɂ́A�����ŏ������I������
        if (index >= paths.Length)
        {
            return;
        }

        // �ڕW�̈ʒu�ƌ��݂̈ʒu�Ƃ̋����ƕ������擾���A���K���������s���A�P�ʃx�N�g���Ƃ���(�����̏��͎����A�����ɂ�鑬�x�����Ȃ����Ĉ��l�ɂ���)
        Vector3 direction = (transform.position - paths[index]).normalized;
        Debug.Log(direction);

        // �A�j���[�V������ Palameter �̒l���X�V���A�ړ��A�j���� BlendTree �𐧌䂵�Ĉړ��̕����ƈړ��A�j���𓯊�
        anim.SetFloat("X", direction.x);
        anim.SetFloat("Y", direction.y);

       // if (transform.position.x > paths[index].x) //�������̉E�ӂ�ύX���܂��B���Z�q�̕����ɒ��ӂ��Ă�������
        //{
            //anim.SetFloat("Y", 0f);
            //anim.SetFloat("X", -1.0f);

            //Debug.Log("������");
        //}
        //else if (transform.position.y < paths[index].y) //�������̉E�ӂ�ύX���܂��B���Z�q�̕����ɒ��ӂ��Ă�������
        //{
            //anim.SetFloat("X", 0f);
            //anim.SetFloat("Y", 1.0f);

            //Debug.Log("�����");
        //}
        //else if (transform.position.y > paths[index].y) //�������̉E�ӂ�ύX���܂��B���Z�q�̕����ɒ��ӂ��Ă�������
        //{
            //anim.SetFloat("X", 0f);
            //anim.SetFloat("Y", -1.0f);
            //Debug.Log("������");
        //}
        //else
        //{
            //anim.SetFloat("Y", 0f);
            //anim.SetFloat("X", 1.0f);

            //Debug.Log("�E����");
        //}

        // ���݂̈ʒu����ێ�
        //currentPos = transform.position;
    }

}
