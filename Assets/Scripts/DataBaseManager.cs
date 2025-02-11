using UnityEngine;

public class DataBaseManager : MonoBehaviour
{
    public static DataBaseManager instance;

    public CharaDataSO charaDataSO;

    public AttackRangeSizeSO attackRangeSizeSO;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // AttackRangeType ���� BoxCollier �p�� Size ���擾
    public Vector2 GetAttackRangeSize(AttackRangeType attackRangeType)
    {
        return attackRangeSizeSO.attackRangeSizeList.Find(x => x.attackRangeType == attackRangeType).size;
    }

}
