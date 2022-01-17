using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AOETower : MonoBehaviour
{

    public DamageSource damageSource;
    void Start(){

    }

    void Update(){

    }

    void OnTriggerEnter2D(Collider2D collider){
        Debug.Log(collider.gameObject);
        Entity entityComponent = collider.gameObject.GetComponent<Entity>();
        if(entityComponent != null){
            DamageSourceInstance instance = new DamageSourceInstance(this.gameObject, collider.gameObject, damageSource);
            if(!entityComponent.hasDamageSourceFromTower(this.gameObject)){
                entityComponent.addDamageSource(instance);
                Debug.Log("Added");
            }
        }
    }

    void OnTriggerExit2D(Collider2D collider){

    }
}
