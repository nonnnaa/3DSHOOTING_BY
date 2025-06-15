using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Ingame : BYSingletonMono<UI_Ingame>
{
    public Joystick virtualJoystick;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      
        InputCharacterManager.instance.Move_dir_add = virtualJoystick.Direction;
    }
    public void OnChangeGun()
    {
        InputCharacterManager.instance.ChangeGun();
    }
}
