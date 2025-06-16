using UnityEngine;


[RequireComponent(typeof(Animator))]
public class DataBinding : BYSingletonMono<DataBinding>
{
    public Animator animator;

    #region Animation parameter keys
    private int AK_X;
    private int AK_Z;
    private int AK_isGrounded;
    private int AK_jumpVelocity;
    private int AK_jumpTrigger;
    #endregion

    public Vector3 MoveDir
    {
        set
        {
            animator.SetFloat(AK_X, value.x);
            animator.SetFloat(AK_Z, value.z);
        }
    }    
    public bool IsGrounded
    {
        set => animator.SetBool(AK_isGrounded, value);
    }
    public float JumpVelocity
    {
        set
        {
            animator.SetFloat(AK_jumpVelocity, value);
        }
    }
    public void JumpTrigger()
    {
        animator.SetTrigger(AK_jumpTrigger);    
    }
    private void Awake()
    {
        animator = GetComponent<Animator>();
        AK_X = Animator.StringToHash("X");
        AK_Z = Animator.StringToHash("Z");
        AK_isGrounded = Animator.StringToHash("isGrounded");
        AK_jumpVelocity = Animator.StringToHash("jumpVelocity");
        AK_jumpTrigger = Animator.StringToHash("jumpTrigger");
    }
    public void ChangeAnimator(AnimatorOverrideController animatorOverrideController)
    {
        if (animatorOverrideController != null)
        {
            animator.runtimeAnimatorController = animatorOverrideController;
        }
    }

    public void DrawWeapon()
    {
        animator.Play("Draw", 1, 0);
    }

}
