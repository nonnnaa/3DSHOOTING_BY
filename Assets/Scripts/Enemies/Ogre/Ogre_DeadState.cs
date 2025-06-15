using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Ogre_DeadState : FSMState
{
    public OgreControl parent;

    public override void EnterState()
    {
        parent.databinding.Dead = true;
    }

    public override void OnExitAnim()
    {
        base.OnExitAnim();
        parent.OnDead();
    }
}
