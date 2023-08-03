using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class BulletFlameController : BulletBase
{
    public override void BulletEnemyHit(CharacterBase characterBase)
    {
        characterBase.State = CharacterBase.CharacterState.Burning;
        characterBase.StateTime = _changeStateTime;
    }
}
