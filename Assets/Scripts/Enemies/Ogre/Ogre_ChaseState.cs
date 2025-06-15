using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Ogre_ChaseState : FSMState
{
    public OgreControl parent;
    private Transform tr_palyer;
  

    public override void EnterState()
    {
        Debug.LogError(" enter chase state ");
    }
    public override void EnterState(object data)
    {
         tr_palyer = (Transform)data;
        Debug.LogError(" enter chase state  data "+tr_palyer.name);

        parent.databinding.Speed = 1;
    }
    public override void UpdateState()
    {
        Vector3 pos_move = tr_palyer.position;
        Vector3 dir = pos_move - parent.trans.position;
        dir.Normalize();
        //parent.trans.forward = dir;
        // parent.trans.forward = Vector3.Lerp(parent.trans.forward, dir, Time.deltaTime * 10);
        Quaternion q = Quaternion.LookRotation(dir, Vector3.up);
        parent.trans.rotation = Quaternion.Slerp(parent.trans.rotation, q, Time.deltaTime * 2);
        //lerp
        // parent.trans.position = Vector3.Lerp(parent.trans.position, pos_move, Time.deltaTime * 1);
        // move to
        parent.trans.position = Vector3.MoveTowards(parent.trans.position, pos_move, Time.deltaTime * 1.5f);
        if (Vector3.Distance(parent.trans.position, pos_move) <= parent.attack_rank)
        {
            parent.GotoState(parent.attackState, tr_palyer);


        }
    }
    public override void ExitState()
    {
        base.ExitState();
        parent.databinding.Speed = 0;
    }

}
