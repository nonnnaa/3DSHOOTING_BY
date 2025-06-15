using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSMSystem : MonoBehaviour
{
    public FSMState cur_state;

    public void GotoState(FSMState newState)
    {
        if(cur_state!=null)
        {
            cur_state.ExitState();

        }
        cur_state = newState;
        cur_state.EnterState();
    }
    public void GotoState(FSMState newState, object data)
    {
        cur_state?.ExitState();

        cur_state = newState;
        cur_state.EnterState(data);
    }

    protected virtual void FixedUpdate()
    {
        cur_state?.FixedUpdateState();
    }
    protected virtual  void LateUpdate()
    {
        cur_state?.LateUpdateState();
    }
    // Start is called before the first frame update
    protected virtual void Awake()
    {

    }
    protected virtual void Start()
    {
    }
    // Update is called once per frame
    protected virtual void Update()
    {
        cur_state?.UpdateState();
    }
    public void OnEnterAnim()
    {
        cur_state?.OnEnterAnim();
    }
    public void OnMidleAnim()
    {
        cur_state?.OnMidleAnim();
    }
    public void OnExitAnim()
    {
        cur_state?.OnExitAnim();
    }
}
