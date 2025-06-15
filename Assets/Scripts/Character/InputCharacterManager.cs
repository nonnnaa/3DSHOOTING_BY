using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InputCharacterManager : BYSingletonMono<InputCharacterManager>
{
    private Vector3 move_dir;
    public Vector3 Move_dir
    {
        private set
        {
            move_dir = value;
        }
        get
        {
            return move_dir;
        }
    }
    public bool isJump;
    public UnityEvent<bool> OnFire;
    public UnityEvent OnChangeGun;
    private Vector2 move_dir_add;
    public Vector2 Move_dir_add
    {
        set
        {
            move_dir_add = value;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void ChangeGun()
    {
        if (OnChangeGun != null)
        {
            OnChangeGun.Invoke();
        }
    }
    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal")+move_dir_add.x;
        float z = Input.GetAxis("Vertical") + move_dir_add.y;

        Move_dir = new Vector3(x, 0, z);
        if(Input.GetKeyDown(KeyCode.Space))
        {
            isJump = true;
        }
        else
        {
            isJump = false;
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (OnFire != null)
            {
                OnFire.Invoke(true);
            }
        }
        else if (Input.GetKeyUp(KeyCode.F))
        {
            if (OnFire != null)
            {
                OnFire.Invoke(false);
            }
        }
      
        if (Input.GetKeyDown(KeyCode.C))
        {
            if(OnChangeGun!=null)
            {
                OnChangeGun.Invoke();
            }
        }
    }
}
