using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
     public DamageSource damageSource;

    public float speed = 0.2f;

    GameObject target;

    bool hit = false;

    bool freeze = true;

    Vector3 unitMovementVector;

    // Start is called before the first frame update
    void Start()
    {
        TowerManager.TickHandler.Add(() => this.tick(), 1);
    }

    void Update()
    {
        if(!freeze){
            if(!hit){
                this.transform.position += speed * unitMovementVector;
            }
            else{
                this.transform.position = target.transform.position;
            }
        }
    }


    void tick(){
        if(this == null)
            return;
        if(!freeze){
            if(target == null){
                GameObject.Destroy(this.gameObject);
            }
            if(hit){
                DamageSourceInstance instance = new DamageSourceInstance(this.gameObject, target, damageSource);
                target.GetComponent<Entity>().addDamageSource(instance);
                GameObject.Destroy(this.gameObject);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collider){
        if(collider.gameObject == target){
            hit = true;
        }
    }

    public void setTarget(GameObject target){
        this.target = target;
        this.unitMovementVector = target.transform.position - this.transform.position;
        this.unitMovementVector = Vector3.Normalize(unitMovementVector);
    }

    public void setFreeze(bool freeze){
        this.freeze = freeze;
    }
}
