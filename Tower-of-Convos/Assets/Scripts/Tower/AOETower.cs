using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AOETower : MonoBehaviour
{

    public DamageSource damageSource;
    void Start(){
        damageSource.damageTick = new Linear(0f, 0.25f);
    }

    void Update(){

    }

    void OnTriggerEnter2D(Collider2D collider){
        Entity entityComponent = collider.gameObject.GetComponent<Entity>();
        if(entityComponent != null){
            DamageSourceInstance instance = new DamageSourceInstance(this.gameObject, collider.gameObject, damageSource);
            if(!entityComponent.hasDamageSourceFromTower(this.gameObject)){
                entityComponent.addDamageSource(instance);
            }
        }
    }

    void OnTriggerExit2D(Collider2D collider){

    }
}
