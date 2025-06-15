using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NinjaCharacter : MonoBehaviour
{

    public NinjaDatabiding databiding;
    private Transform trans;
    public float speed = 2f;
    public GameObject attack_obj;
    private float time_atack;
    public LayerMask mask_enemy;
    public List<int> ls_a;
    public List<EnemyControl> ls_e;// generic
    // Start is called before the first frame update
    void Awake()
    {
        trans = transform;
        attack_obj.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // FPS : frame per second: 60 FPS 
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 dir = new Vector3(x, 0, z);
        //set animation 
        databiding.Speed = dir.magnitude;
        if(dir.magnitude>0)
        {
            dir.Normalize();
            // rotate character 
            trans.forward = dir;
            // move character
            trans.Translate(Vector3.forward * Time.deltaTime * speed);
        }
       // List<Collider> ls = new List<Collider>();
        time_atack += Time.deltaTime;
        if(Input.GetKeyDown(KeyCode.Space)&&time_atack>0.5f)
        {
            time_atack = 0;
            attack_obj.SetActive(true);
            Collider[] cols=  Physics.OverlapSphere(trans.position, 2, mask_enemy);//7

            foreach(Collider e in cols)
            {
           
                EnemyControl enemy = e.GetComponent<EnemyControl>();
                if(enemy!=null)
                {
                    enemy.OnDamage(5);
                }
            }
        }
       if(time_atack>0.25f)
        {
            attack_obj.SetActive(false);
        }
    }
    public void OnDamage(EnemyControl e)
    {
        Debug.LogError(" hit: " + e.damage);
    }
}
