using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineGun : WeaponBehaviour
{
    public override void Setup()
    {
        base.Setup();
        iwp_Handle = new IMachineGun();
        iwp_Handle.OnSetup(this);
    }
}
public class IMachineGun : IWeaponHandle
{
    MachineGun weaponBehaviour;
    public void OnFireHandle()
    {

    }

    public void OnReloadHandle()
    {

    }

    public void OnSetup(WeaponBehaviour wp)
    {
        weaponBehaviour = (MachineGun)wp;
    }
}