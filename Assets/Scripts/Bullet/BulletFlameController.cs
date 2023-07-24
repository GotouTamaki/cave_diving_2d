using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class BulletFlameController : BulletBase
{
    public override void BulletEnemyHit(EnemyBase enemyBase)
    {
        enemyBase.State = EnemyBase.EnemyState.Burning;
    }
}
