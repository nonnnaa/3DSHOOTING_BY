using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponBehaviour : MonoBehaviour
{
    public float rof;
    private float timeFire;
    public float reloadTime;
    public int clips_size;
    private int number_bullet;
    public float accuracy;
    private bool is_fire;
    public IWeaponHandle iwp_Handle;
    public AnimatorOverrideController overrideController;
    private CharacterDatabinding characterDatabinding;
    public virtual void Setup()
    {

        number_bullet = clips_size;
    }
    // Start is called before the first frame update
    void Start()
    {
        Setup();
    }
    public void OnFire(bool isFire)
    {
        is_fire = isFire;
    }
    public void OnShow(CharacterDatabinding characterDatabinding)
    {
        characterDatabinding.ChangeAnim(overrideController);
        characterDatabinding.ShowGun();
        this.characterDatabinding = characterDatabinding;
    }
    public void OnHide()
    {

    }
    public void OnReload()
    {

    }
    // Update is called once per frame
    void Update()
    {
        timeFire += Time.deltaTime;
        if (is_fire)
        {
            if (timeFire >= rof && number_bullet > 0)
            {
                characterDatabinding.Fire();
                timeFire = 0;
            }
        }
    }
}
// implement
public interface IWeaponHandle
{
    void OnSetup(WeaponBehaviour wp);
    void OnFireHandle();
    void OnReloadHandle();
}