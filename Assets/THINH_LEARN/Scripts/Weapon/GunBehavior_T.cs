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
    public bool isReload;
    public AnimatorOverrideController overrideController;

    private DataBinding dataBinding;
    public override void OnSetUp()
    {
        base.OnSetUp();
    }
    public override void OnShow(DataBinding dataBinding)
    {
        isReload = false;
        dataBinding.ChangeAnimator(overrideController);
        dataBinding.DrawWeapon();
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
