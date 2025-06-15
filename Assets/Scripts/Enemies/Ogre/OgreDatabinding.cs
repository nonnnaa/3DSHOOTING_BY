using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OgreDatabinding : MonoBehaviour
{
    [SerializeField]
    private Animator animator;
    public float speed_mul = 2f;
    private float cur_speed;
    private float new_speed;
    public float Speed
    {
        set
        {
            new_speed = value;
        }
    }
    public bool Attack
    {
        set
        {
            if (value)
            {
                animator.SetTrigger(AK_Attack);
                int index = UnityEngine.Random.Range(1, 3);
                animator.SetInteger(AK_Index_Attack, index);
            }
        }
    }
   
    public bool Dead
    {
        set
        {
            if (value)
                animator.SetTrigger(AK_Dead);
        }
    }

    private int AK_Speed;
    private int AK_Attack;
    private int AK_Index_Attack;
    private int AK_Dead;
    // Start is called before the first frame update
    private void Awake()
    {
        AK_Speed = Animator.StringToHash("Speed");
        AK_Attack = Animator.StringToHash("Attack");
        AK_Index_Attack = Animator.StringToHash("Index_Attack");
        AK_Dead = Animator.StringToHash("Dead");
    }
    public void PlayAnimIdle()
    {
        if (UnityEngine.Random.value > 0.7f)
        {
            animator.Play("LookLeft", 0, 0);
        }
        else if (UnityEngine.Random.value > 0.3f)
        {
            animator.Play("LookRight", 0, 0);
        }
        else
        {
            //
        }
    }
    // Update is called once per frame
    void Update()
    {
        cur_speed = Mathf.Lerp(cur_speed, new_speed, Time.deltaTime * 3.5f);
        animator.SetFloat(AK_Speed, cur_speed * speed_mul);
    }
    //public void OnAttack(int index)
    //{
    //    Debug.LogError(" data attack : " + index);
    //}
}
