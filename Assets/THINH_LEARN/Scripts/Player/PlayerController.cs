using System.Collections;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(DataBinding))]
public class PlayerController : MonoBehaviour
{
    [Header("COMPONENT")]
    #region Component
    public CharacterController characterControl;
    public DataBinding dataBinding;
    #endregion


    [Header("PLAYER DATA")]
    #region Player Data
    public float speedRun;
    public float jumpVelocity;
    public float jumpCooldown;
    public float gravity = -30f;
    #endregion


    [Header("Gizmos")]
    [SerializeField] private Transform anchor;
    [SerializeField] private Vector3 offsetCheckGround;


    [Header("Layer")]
    [SerializeField] private LayerMask groundLayer;


    [Header("Temp Variable")]
    #region Temp Variable
    [SerializeField] public bool isGrounded;
    [SerializeField] private bool canJump;
    private Vector3 moveDirection;
    private Vector3 curentVelocity;
    private float yPosition;
    
    #endregion


    private void Awake()
    {
        characterControl = GetComponent<CharacterController>();
        dataBinding = GetComponent<DataBinding>();
  
    }
    void Start()
    {
        InputManager.instance.IsJump.AddListener(Jump);
        canJump = true;
    }

    private void FixedUpdate()
    {
        
    }

    void Update()
    {
        moveDirection = InputManager.instance.MoveDirection;
        dataBinding.MoveDir = moveDirection;// Chi cap nhat 2 bien x, z lay theo anim
        


        isGrounded = IsGrounded();
        dataBinding.IsGrounded = isGrounded;
        
        



        curentVelocity = new Vector3(moveDirection.x * speedRun, curentVelocity.y, moveDirection.z * speedRun);

        curentVelocity.y += gravity * Time.deltaTime;

        if (isGrounded && curentVelocity.y < 0)
        {
            curentVelocity.y = 0f;
        }
        if(!isGrounded)
        {
            dataBinding.JumpVelocity = curentVelocity.y;
        }
        characterControl.Move(curentVelocity * Time.deltaTime);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(anchor.position, anchor.position + offsetCheckGround);
    }

    private bool IsGrounded()
    {
        return Physics.Linecast(anchor.position , anchor.position + offsetCheckGround, groundLayer);
    }

    private void Jump()
    {
        //Debug.Log("JUMPING");
        if(isGrounded && canJump)
        {
            StartCoroutine(JumpCooldown());
        }
    }

    private IEnumerator JumpCooldown()
    {
        canJump = false;
        curentVelocity.y = jumpVelocity;
        dataBinding.JumpTrigger();
        yield return new WaitForSeconds(jumpCooldown);
        canJump = true;
    }    
        
}
