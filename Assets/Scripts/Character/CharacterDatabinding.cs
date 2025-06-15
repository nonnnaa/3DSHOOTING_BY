using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterDatabinding : MonoBehaviour
{
    public Animator animator;
    public Vector3 MoveDir
    {
        set
        {
            animator.SetFloat(AK_X, value.x);
            animator.SetFloat(AK_Z, value.z);
        }
    }
    //0.5->1.25->2
    public float JumpVelocity
    {
        set
        {
           // animator.SetFloat(AK_Jump_Velocity, value);
        }
    }
    public bool IsGround
    {
        set
        {
            //animator.SetBool(AK_IsGround, value);
        }
    }
    public void ShowGun()
    {
        animator.Play("Show", 1, 0);
    }
    public void Fire()
    {
        animator.Play("Fire",1, 0);
    }
    public void Reload()
    {
        animator.Play("Reload", 1, 0);
    }
    private int AK_X;
    private int AK_Z;
    private int AK_IsGround;
    private int AK_Jump_Velocity;
    // Start is called before the first frame update
    void Start()
    {
        AK_X = Animator.StringToHash("X");
        AK_Z = Animator.StringToHash("Z");

        AK_IsGround = Animator.StringToHash("IsGround");
        AK_Jump_Velocity = Animator.StringToHash("Jump_Velocity");
    }

    // Update is called once per frame
   public void ChangeAnim(AnimatorOverrideController animatorOverrideController)
    {
        animator.runtimeAnimatorController = animatorOverrideController;
    }
}
