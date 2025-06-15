using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleGun : WeaponBehaviour
{
    public override void Setup()
    {
        base.Setup();
        iwp_Handle = new IHandleGun();
        iwp_Handle.OnSetup(this);
    }
}
public class IHandleGun : IWeaponHandle
{
    HandleGun weaponBehavior;
    public void OnFireHandle()
    {

    }

    public void OnReloadHandle()
    {

    }

    public void OnSetup(WeaponBehaviour wp)
    {
        weaponBehavior = (HandleGun)wp;
    }
}