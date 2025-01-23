using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharaController : MonoBehaviour
{
    [SerializeField, Header("�U����")]
    private int attackPower = 1;

    [SerializeField, Header("�U������܂ł̑ҋ@����")]
    private float intervalAttackTime = 60.0f;

    [SerializeField]
    private bool isAttack;

    [SerializeField]
    private EnemyController enemy;
        
    private void OnTriggerStay2D(Collider2D collision)
    {
        // �U�����ł͂Ȃ��ꍇ�ŁA���A�G�̏��𖢎擾�ł���ꍇ
        if (collision.tag == "Enemy" && !isAttack && !enemy)
        {
            Debug.Log("�G����");

            // Destroy(collision.gameObject);

            // �G�̏��(EnemyController)���擾����BEnemyController ���A�^�b�`����Ă���Q�[���I�u�W�F�N�g�𔻕ʂ��Ă���̂ŁA�����ŁA���܂ł� Tag �ɂ�锻��Ɠ�������Ŕ��肪�s���܂��B
            // ���̂��߁A���@�̏������� Tag �̏������폜���Ă��܂�
            if (collision.gameObject.TryGetComponent(out enemy))
            {
                // �����擾�ł�����A�U����Ԃɂ���
                isAttack = true;

                // �U���̏����ɓ���
                StartCoroutine(PrepareteAttack());
            }

        }        
    }

    // �U������
    public IEnumerator PrepareteAttack()
    {
        Debug.Log("�U�������J�n");

        int timer = 0;

        // �U�����̊Ԃ������[�v�������J��Ԃ�
        while(isAttack)
        {

            // TODO �Q�[���v���C���̂ݍU������

            timer++;

            // �U���̂��߂̑ҋ@���Ԃ��o�߂�����
            if (timer > intervalAttackTime)
            {
                // ���̍U���ɔ����āA�ҋ@���Ԃ̃^�C�}�[�����Z�b�g
                timer = 0;

                // �U��
                Attack();

                // TODO �U���񐔊֘A�̏����������ɋL�q����
            }

            // �P�t���[�������𒆒f����(���̏����������Y���Ɩ������[�v�ɂȂ�AUnity �G�f�B�^�[�������Ȃ��Ȃ��čċN�����邱�ƂɂȂ�܂��B���ӁI)
            yield return null;
        }
    }

    // �U��
    private void Attack()
    {
        Debug.Log("�U��");

        // TODO �L�����̏�ɍU���G�t�F�N�g�𐶐�

        // TODO �G�L�������ɗp�ӂ����_���[�W�v�Z�p�̃��\�b�h���Ăяo���āA�G�Ƀ_���[�W��^����

        // �G�L�������ɗp�ӂ����_���[�W�v�Z�p�̃��\�b�h���Ăяo���āA�G�Ƀ_���[�W��^����
        enemy.CulcDamage(attackPower);

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.TryGetComponent(out enemy))
        {

            Debug.Log("�G�Ȃ�");

            isAttack = false;
            enemy = null;
        }
    }


}
