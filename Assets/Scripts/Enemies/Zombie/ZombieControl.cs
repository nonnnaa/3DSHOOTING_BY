using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class ZombieControl : EnemyControl
{
    public Zombie_AttackState attackState;
    public Zombie_ChaseState chaseState;
    public Zombie_DeadState deadState;
    public Zombie_WanderState wanderState;
    public Zombie_IdleState idleState;
    public ZombieDatabinding databinding;


    protected override void Start()
    {
        base.Start();
        attackState.parent = this;
        chaseState.parent = this;
        deadState.parent = this;
        wanderState.parent = this;
        idleState.parent = this;
        GotoState(wanderState);
    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            DetectPlayer(other.transform);

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.LogError(" OnTriggerExit " + other.name);
            if (cur_state != idleState)
            {

                GotoState(idleState);
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            DetectPlayer(other.transform);

        }
    }
    private void DetectPlayer(Transform trans_player)
    {
        if (cur_state == idleState || cur_state == wanderState)
        {

            // vector forward:   trans.forward
            // vector AB:
            Vector3 A = trans.position;
            Vector3 B = trans_player.position;
            B = new Vector3(B.x, A.y, B.z);

            Vector3 AB = B - A;
            AB.Normalize();

            float dot = Vector3.Dot(trans.forward, AB);
            if (dot > 0)
                GotoState(chaseState, trans_player);
        }
    }
    protected override void Update()
    {
        base.Update();

        time_count_attack += Time.deltaTime;
    }
    //    public void OnAttack(int index)
    //    {
    //        Debug.LogError(" control attack : " + index);
    //    }
    public override void OnDamage(int damage)
    {
        base.OnDamage(damage);

        HP -= damage;
        if(HP<=0)
        {
            HP = 0;
            if(cur_state!=deadState)
            {
                GotoState(deadState);
            }
        }
    }
}
