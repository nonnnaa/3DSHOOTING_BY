using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OOP_Sample : MonoBehaviour
{
    private List<Enemy> ls_enemy = new List<Enemy>();
    // Start is called before the first frame update
    void Start()
    {
       

        Zombie zb = new Zombie();
        zb.damage = 0;
        zb.res_critical = false;
        ls_enemy.Add(zb);

        Ogre og = new Ogre();
        og.damage = 1;
        og.res_critical = true;
        ls_enemy.Add(og);
        // skill 
        for(int i=0;i<ls_enemy.Count;i++)
        {
            ls_enemy[i].OnDamage(1);
        }
        //
        foreach(Enemy e in ls_enemy)
        {
            e.OnDamage(2, 2);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}

public class Enemy
{
    public int hp;
    public int damage;
    public float speed;
    protected bool isSupport;
    public bool res_critical;
    public void Warning()
    {
        Debug.Log(isSupport);
    }
    private void Walk()
    {
    }
    public virtual void OnDamage(int damage)
    {
        Debug.LogError(" enemy ondamge -> " + damage);
    }
    public virtual void OnDamage(int damage,int critical)
    {
        if(!res_critical)// res_critical==false
        {
            Debug.LogError(" enemy ondamage: " + damage*critical);
        }
    }
}
public class Zombie : Enemy
{
    private int toxic = 0;
    
    public void Attack()
    {
        if (isSupport)
        {
            Debug.Log(toxic * damage);
        }
    }
    public override void OnDamage(int damage)
    {
       // base.OnDamage(damage);
        Debug.LogError(" zombie ondamge : " + damage*2);
    }
}
public class Ogre : Enemy
{
    private int attack_speed;
    public override void OnDamage(int damage)
    {
        //  base.OnDamage(damage);
        Debug.LogError(" Ogre ondamge : " + damage );
    }
    
}