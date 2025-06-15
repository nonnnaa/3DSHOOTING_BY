using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssaultRifle : WeaponBehaviour
{
    public override void Setup()
    {
        base.Setup();
        iwp_Handle = new IAssaultRifle();
        iwp_Handle.OnSetup(this);
    }
}
public class IAssaultRifle : IWeaponHandle
{
    AssaultRifle weaponBehaviuor;
    public void OnFireHandle()
    {

    }

    public void OnReloadHandle()
    {

    }

    public void OnSetup(WeaponBehaviour wp)
    {
        weaponBehaviuor = (AssaultRifle)wp;
    }
}