using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NinjaDatabiding : MonoBehaviour
{
    public Animator animator;
    public float Speed
    {
        
        set
        {
            animator.SetFloat(AK_Speed, value);
        }
    }
    private int AK_Speed;
    private void Awake()
    {
        AK_Speed = Animator.StringToHash("Speed");
    }
}
