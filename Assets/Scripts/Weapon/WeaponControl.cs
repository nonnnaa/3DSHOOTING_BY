using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponControl : MonoBehaviour
{

    public List<WeaponBehaviour> lsGuns;//=new List<WeaponBehaviour>();
    public WeaponBehaviour cur_gun;
    public Transform anchor_wp;
    public List<string> guns_names;
    private int gun_index = -1;
    public CharacterDatabinding characterDatabinding;
    // Start is called before the first frame update
    void Start()
    {
        //lsGuns = new List<WeaponBehaviour>();
        foreach (string gn in guns_names)
        {
            GameObject go = Instantiate(Resources.Load("Weapon/" + gn, typeof(GameObject))) as GameObject;

            go.transform.SetParent(anchor_wp,false);
            go.SetActive(false);
            lsGuns.Add(go.GetComponent<WeaponBehaviour>());
        }
        OnChangeGun();
        InputCharacterManager.instance.OnChangeGun.AddListener(OnChangeGun);
        InputCharacterManager.instance.OnFire.AddListener(OnFire);
    }
    private void OnChangeGun()
    {
        gun_index++;
        if(gun_index>=lsGuns.Count)
        {
            gun_index = 0;
        }
        if(cur_gun!=null)
        {
            cur_gun.OnHide();
            cur_gun.gameObject.SetActive(false);
        }
        cur_gun = lsGuns[gun_index];
        cur_gun.gameObject.SetActive(true);
        cur_gun.OnShow(characterDatabinding);
    }
    private void OnFire(bool is_Fire)
    {
        if(cur_gun!=null)
        {
            cur_gun.OnFire(is_Fire);
        }
    }
    // Update is called once per frame
  
}
