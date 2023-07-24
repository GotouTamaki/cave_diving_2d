using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEmenyBubbleController : EnemyBulletBase
{
    public override void BulletPlayerHit(PlayerController playerController)
    {
        playerController.State = PlayerController.PlayerState.Slow;
    }
}
