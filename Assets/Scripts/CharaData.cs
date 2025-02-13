using UnityEngine;

// �L�����̏ڍ׃f�[�^
[System.Serializable]
public class CharaData
{
    public int charaNo;
    public int cost;
    public Sprite charaSprite;
    public string charaName;

    public int attackPower;
    public AttackRangeType attackRange;
    public float intervalAttackTime;
    public int maxAttackCount;

    [Multiline]
    public string discription;

    public AnimationClip charaAmim;

    // TODO ���ɂ�����Βǉ�
        
}
