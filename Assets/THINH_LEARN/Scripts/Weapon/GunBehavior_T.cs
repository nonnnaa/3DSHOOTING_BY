using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IGun
{
    void OnFireHandle();
    void OnReload();
}
public class GunBehavior_T : WeaponBehavior_T, IGun
{
    public override void OnSetUp()
    {
        base.OnSetUp();
    }
    public void OnFireHandle()
    {
        throw new System.NotImplementedException();
    }

    public void OnReload()
    {
        throw new System.NotImplementedException();
    }
}
