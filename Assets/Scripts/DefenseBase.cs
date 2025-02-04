using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenseBase : MonoBehaviour
{
    [SerializeField, Header("�ϋv�l")]
    private int maxDefenseBaseDurability;

    private int defenseBaseDurability; // �ϋv�͂̌��ݒl


    // Start is called before the first frame update
    void Start()
    {
        // �ϋv�͂̏����l�̐ݒ�
        defenseBaseDurability = maxDefenseBaseDurability;

    }

    // TODO �ݒ�p�̃��\�b�h�̍쐬�B�쐬��� Start ���\�b�h���폜

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // �N�����Ă����Q�[���I�u�W�F�N�g�̊m�F�ƓG�L�����̏��̎擾
        if(collision.gameObject.TryGetComponent(out EnemyController enemyController))
        {
            // �G�L�����̍U���͕������ϋv�͂����Z���A�ϋv�͂̒l�̉����Ə�����Ɏ��܂�悤�ɐ��䂵����ōX�V
            defenseBaseDurability = Mathf.Clamp(defenseBaseDurability - enemyController.attackPower, 0, maxDefenseBaseDurability);

            // �G�̔j��
            enemyController.DestroyEnemy();
        }

        // TODO �_���[�W���o����

        // TODO �Q�[����ʂɑϋv�͂̕\��������ꍇ�A���̕\�����X�V

        // �ϋv�͂̎c����m�F
        if (defenseBaseDurability <= 0)
        {
            Debug.Log("Game Over");

            // TODO �Q�[���I�[�o�[����
        }

        
    }

    // TODO�_���[�W���o�����p�̃��\�b�h�̍쐬
     
    
}
