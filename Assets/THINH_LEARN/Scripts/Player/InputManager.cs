using UnityEngine;
using UnityEngine.Events;

public class InputManager : BYSingletonMono<InputManager>
{
    public Vector3 MoveDirection
    {
        get
        {
            return new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        }
    }

    public UnityEvent IsJump;
    void Start()
    {
        
    }

    
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            IsJump?.Invoke();
        }
    }
}
