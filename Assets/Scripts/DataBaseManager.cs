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

    // AttackRangeType から BoxCollier 用の Size を取得
    public Vector2 GetAttackRangeSize(AttackRangeType attackRangeType)
    {
        return attackRangeSizeSO.attackRangeSizeList.Find(x => x.attackRangeType == attackRangeType).size;
    }

}
