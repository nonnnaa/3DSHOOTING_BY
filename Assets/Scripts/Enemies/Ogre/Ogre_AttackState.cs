using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Ogre_AttackState : FSMState
{
    [HideInInspector]
    public OgreControl parent;
    private Transform tr_palyer;
    public override void EnterState(object data)
    {
        base.EnterState(data);
        tr_palyer = (Transform)data;
    }
    public override void UpdateState()
    {
       
        if (parent.time_count_attack >=parent.attack_speed)
        {
            parent.time_count_attack = 0;

            //
            parent.databinding.Attack = true;
        }
    }

    public override void ExitState()
    {
        Debug.LogError(" exit  attack state");
    }
    public override void OnEnterAnim()
    {
    }
    public override void OnMidleAnim()
    {
        base.OnMidleAnim();
        // detect , damge player // check play in range attack , check player infront of 
        Vector3 cur_pos = parent.trans.position;
        Vector3 dir_forward = parent.trans.forward;

        Vector3 pos_player = tr_palyer.position;
        pos_player.y = cur_pos.y;

        float dis = Vector3.Distance(cur_pos, pos_player);

        Vector3 dir_zombie_2_player = pos_player - cur_pos;
        dir_zombie_2_player.Normalize();
        float dot = Vector3.Dot(dir_forward, dir_zombie_2_player);
        if(dis<=parent.attack_rank)
        {
            if(dot>=0)// 90
            {
                // player 
                tr_palyer.GetComponent<NinjaCharacter>().OnDamage(parent);
            }
        }


    }
    public override void OnExitAnim()
    {
    
        parent.GotoState(parent.chaseState);
    }
}
