using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSM_Anim_State : StateMachineBehaviour
{
    private FSMSystem system_;
    public float time_middle;
    private float time_count;
    private bool isCall;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        isCall = false;
        time_count = 0;
        Debug.LogError("OnStateMachineEnter ");
        if (system_ == null)
        {
            system_ = animator.GetComponent<FSMSystem>();
        }
        system_?.OnEnterAnim();
    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        system_?.OnExitAnim();

    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        time_count += Time.deltaTime;
        if(time_count>=time_middle&&!isCall)//isCall==false
        {
            isCall = true;
            system_?.OnMidleAnim();
        }
    }

    


}
