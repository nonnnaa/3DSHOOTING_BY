using System;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController_T : MonoBehaviour
{
    [SerializeField] private Transform anchorWeapon;


    public List<WeaponBehavior_T> listWeapon;

    public WeaponBehavior_T currentWeapon;

    public Action<WeaponBehavior_T> onWeaponChange;

    [SerializeField] private List<String> weaponNames;

    [SerializeField] private int indexWeapon = 0;

    private void Start()
    {
        foreach (var weapon in weaponNames)
        {
            GameObject go = Instantiate(Resources.Load("Weapon_T/Gun/" + weapon)) as GameObject;
            go.transform.SetParent(anchorWeapon);
            WeaponBehavior_T wp = go.GetComponent<WeaponBehavior_T>();
            wp.OnSetUp();
            listWeapon.Add(wp);

        }
    }
}
