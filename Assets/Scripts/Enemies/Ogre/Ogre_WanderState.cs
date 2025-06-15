using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Ogre_WanderState : FSMState
{
    [HideInInspector]
    public OgreControl parent;
  
    private Vector3 ogrinal_pos;
    private Vector3 pos_move;
    private Vector3 old_pos;
    public override void EnterState()
    {
        Debug.LogError(" enter wander state");
        ogrinal_pos = parent.trans.position;
        float x = UnityEngine.Random.Range(-5f, 5f);
        float z = UnityEngine.Random.Range(-5f, 5f);
        pos_move = ogrinal_pos + new Vector3(x, 0, z);
        old_pos = parent.trans.position;
    }
    public override void UpdateState()
    {
        Vector3 dir = pos_move - parent.trans.position;
        dir.Normalize();
        //parent.trans.forward = dir;
       // parent.trans.forward = Vector3.Lerp(parent.trans.forward, dir, Time.deltaTime * 10);
        Quaternion q = Quaternion.LookRotation(dir, Vector3.up);
        parent.trans.rotation = Quaternion.Slerp(parent.trans.rotation, q, Time.deltaTime * 2);
        //lerp
       // parent.trans.position = Vector3.Lerp(parent.trans.position, pos_move, Time.deltaTime * 1);
        // move to
        parent.trans.position = Vector3.MoveTowards(parent.trans.position, pos_move, Time.deltaTime * 1);
        if (Vector3.Distance(parent.trans.position,pos_move)<=0.1f)
        {
            if (UnityEngine.Random.value > 0.5f)
            {
                float x = UnityEngine.Random.Range(-5f, 5f);
                float z = UnityEngine.Random.Range(-5f, 5f);
                pos_move = ogrinal_pos + new Vector3(x, 0, z);
            }
            else
            {
                parent.GotoState(parent.idleState);
            }

           
        }
    }
    public override void FixedUpdateState()
    {
        base.FixedUpdateState();
        Vector3 delta = parent.trans.position - old_pos;
        parent.databinding.Speed = delta.magnitude*0.5f;
        old_pos = parent.trans.position;
    }
    public override void LateUpdateState()
    {
        base.LateUpdateState();
    }
    public override void ExitState()
    {
        Debug.LogError(" exit  wander state");
        parent.databinding.Speed = 0;
    }
}
