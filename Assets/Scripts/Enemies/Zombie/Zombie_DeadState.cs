using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Zombie_DeadState : FSMState
{
    public ZombieControl parent;

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
