using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Ogre_IdleState : FSMState
{
    [HideInInspector]
    public OgreControl parent;
    private float time_count;
    private float time_;
    public override void EnterState()
    {
        Debug.LogError(" enter idle state");
        time_count = 0;
        time_ = UnityEngine.Random.Range(4f, 6f);
        parent.databinding.PlayAnimIdle();
    }
    public override void UpdateState()
    {
       
        time_count += Time.deltaTime;
        if (time_count > time_)
        {
            parent.GotoState(parent.wanderState);
        }
    }

    public override void ExitState()
    {
        Debug.LogError(" exit  idle state");
    }
}
