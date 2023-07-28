using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBubbleController : BulletBase
{
    public override void BulletEnemyHit(CharacterBase characterBase)
    {
        characterBase.State = CharacterBase.CharacterState.Slow;
    }
}
