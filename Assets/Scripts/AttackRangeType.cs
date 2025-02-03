using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AttackRangeType
{
    // 攻撃範囲の種類
    Short,  // BoxCollider の Size x = 2, y = 2 など。これは後程、設定を行う
    Middle,
    Long,
    Wide

    // TODO　追加する場合は、この下に追記していく
    
}
