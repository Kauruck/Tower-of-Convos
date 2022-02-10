using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(MovmentHelper))]
public class Bullet : MonoBehaviour
{
    public DamageSource damageSource;

    public float speed = 0.2f;

    GameObject target;

    bool hit = false;

    bool freeze = true;

    private MovmentHelper movmentHelper;

    // Start is called before the first frame update
    void Start()
    {
        this.movmentHelper = this.GetComponent<MovmentHelper>();
        TowerManager.TickHandler.Add(() => this.tick(), 1);
    }

    void Update()
    {

    }


    void tick()
    {
        if(this == null)
            return;
        if(!freeze)
        {
            if(target == null){
                GameObject.Destroy(this.gameObject);
            }
            if(hit)
            {
                DamageSourceInstance instance = new DamageSourceInstance(this.gameObject, target, damageSource);
                target.GetComponent<Entity>().addDamageSource(instance);
                GameObject.Destroy(this.gameObject);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject == target)
        {
            hit = true;
            movmentHelper.frozen = true;
            this.transform.position = target.transform.position;
        }
    }

    public void setTarget(GameObject target)
    {
        if(movmentHelper == null)
        {
            this.movmentHelper = this.GetComponent<MovmentHelper>();
        }
        this.target = target;
        this.movmentHelper.direction = Vector3.Normalize(this.target.transform.position - this.transform.position);
    }

    public void setFreeze(bool freeze){
        this.freeze = freeze;
        this.movmentHelper.frozen = freeze;
    }
}
