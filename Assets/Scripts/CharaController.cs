using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharaController : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D collision)
    {
        // �U���͈͗p�̃R���C�_�[�ɐN�������Q�[���I�u�W�F�N�g�� Tag �� Enemy �ł���ꍇ
        if (collision.tag == "Enemy")
        {
            Debug.Log("�G����");

            Destroy(collision.gameObject);

            // TODO �G�̏��(EnemyController)���擾����

            // TODO �����擾�ł�����A�U����Ԃɂ���

            // TODO �U���̏����ɓ���

        }
    }
    
}
