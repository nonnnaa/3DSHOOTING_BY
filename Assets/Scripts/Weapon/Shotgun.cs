using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : WeaponBehaviour
{
    public override void Setup()
    {
        base.Setup();
        iwp_Handle = new IShotgun();
        iwp_Handle.OnSetup(this);
    }
}

public class IShotgun : IWeaponHandle
{
    Shotgun weaponBehaviour;
    public void OnFireHandle()
    {
       
    }

    public void OnReloadHandle()
    {
        
    }

    public void OnSetup(WeaponBehaviour wp)
    {
        weaponBehaviour = (Shotgun)wp;
    }
}