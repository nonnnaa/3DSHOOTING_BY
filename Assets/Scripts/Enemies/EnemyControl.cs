using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : FSMSystem
{
    public float HP;
    public float damage;

    public float detect_range;
    public float attack_rank;
    public float attack_speed;
    public Transform trans;
    public SphereCollider sphereCollider_;
    public float time_count_attack;
    protected override void Awake()
    {
        base.Awake();
        trans = transform;
    }
    public virtual void Setup()
    {

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, detect_range);
        if (sphereCollider_ != null)
            sphereCollider_.radius = detect_range;
    }
    public virtual void OnDamage(int damage)
    {

    }
    public void OnDead()
    {
        Destroy(gameObject);
    }
}
