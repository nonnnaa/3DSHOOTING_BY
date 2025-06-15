using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControl : MonoBehaviour
{
    public Transform trans_cam;
    private Transform trans;
    public float speed = 2;
    // public Rigidbody rigidbody_;
    public CharacterController characterController_;
    public CharacterDatabinding databinding;
    public float jump_velocity;
    private float a = -12f;
    public float jump_Y;
    public Transform anchor_foot;
    public LayerMask ground_mask;
    private float time_delay;
    public Transform target;
    private void Awake()
    {
        trans = transform;
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if(target!=null)
        {
            Vector3 tar_pos = target.position;
            tar_pos.y = trans.position.y;

            Vector3 dir_target = tar_pos - trans.position;
            dir_target.Normalize();


            trans.forward = dir_target;
        }
        time_delay -= Time.deltaTime;
       // time_delay = time_delay - Time.deltaTime;
        float t = Time.deltaTime;
        if (InputCharacterManager.instance.isJump)
        {
            jump_velocity = 5;
            time_delay = 0.25f;
            jump_Y = 0;
            databinding.JumpVelocity = 0.5f;
        }
        Vector3 moveDir = InputCharacterManager.instance.Move_dir;
        jump_Y = jump_Y + jump_velocity * t + a * t * t * 0.5f;
        // trans.position = Vector3.Lerp(trans.position, trans.position + moveDir, Time.deltaTime * speed);
        //rigidbody_.position= Vector3.Lerp(rigidbody_.position, rigidbody_.position + moveDir, Time.deltaTime * speed);

        Vector3 dir = moveDir;// trans_cam.TransformDirection(moveDir);

        if (!Physics.Linecast(anchor_foot.position, anchor_foot.position + new Vector3(0, -0.65f, 0), ground_mask)&&time_delay<=0)
        {

            databinding.IsGround = false;
          
            if(Physics.Linecast(anchor_foot.position, anchor_foot.position + new Vector3(0, -1f, 0), ground_mask))
            {
                databinding.JumpVelocity = 2;
            }
            else
            {
               
                databinding.JumpVelocity = 1.25f;
            }

        }
        else
        {
            Vector3 dir_anim = trans.TransformDirection(dir);
            databinding.MoveDir = dir_anim;
            databinding.IsGround = true;
           
        }
        dir.y = jump_Y;
        
        characterController_.Move(dir * Time.deltaTime * speed);
        jump_velocity = jump_velocity + a * Time.deltaTime;

    }
}
// 