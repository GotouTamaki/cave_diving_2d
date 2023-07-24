using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBubbleController : BulletBase
{
    public override void BulletEnemyHit(EnemyBase enemyBase)
    {
        enemyBase.State = EnemyBase.EnemyState.Slow;
    }
}
