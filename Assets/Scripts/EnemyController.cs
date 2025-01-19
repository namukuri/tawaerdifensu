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

    // Start is called before the first frame update
    void Start()
    {

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
        transform.DOPath(paths, 1000 /  moveSpeed).SetEase(Ease.Linear);
    }      
    
}
