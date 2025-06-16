using System;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController_T : MonoBehaviour
{
    [SerializeField] private Transform anchorWeapon;


    public List<WeaponBehavior_T> listWeapon;

    public WeaponBehavior_T currentWeapon;

    public Action<WeaponBehavior_T> onWeaponChange;

    [SerializeField] private List<string> weaponNames;

    [SerializeField] private int indexWeapon;

    [SerializeField] private DataBinding dataBingding;

    private void Awake()
    {
        dataBingding = GetComponent<DataBinding>();
    }

    private void Start()
    {
        indexWeapon = -1;
        foreach (var weapon in weaponNames)
        {
            GameObject go = Instantiate(Resources.Load("Weapon_T/Gun/" + weapon)) as GameObject;
            go.SetActive(false);
            go.transform.SetParent(anchorWeapon, false);
            WeaponBehavior_T wp = go.GetComponent<WeaponBehavior_T>();
            wp.OnSetUp();
            listWeapon.Add(wp);

        }
        OnChangeWeapon();
        InputManager.instance.OnChangeWeapon += OnChangeWeapon;
    }



    void OnChangeWeapon()
    {
        indexWeapon = indexWeapon < listWeapon.Count - 1 ? indexWeapon + 1 : 0;
        
        //Debug.Log(indexWeapon);
        if(currentWeapon != null)
        {
            currentWeapon.OnHide();
        }
        currentWeapon = listWeapon[indexWeapon];
        currentWeapon.gameObject.SetActive(true);
        currentWeapon.OnShow(dataBingding);
        onWeaponChange?.Invoke(currentWeapon);
    }
}
