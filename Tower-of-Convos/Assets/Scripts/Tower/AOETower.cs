using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AOETower : MonoBehaviour
{

    List<Entity> entitiesInRange = new List<Entity>();
    public DamageSource damageSource;
    void Start(){
        damageSource.damageTick = new Linear(0f, 0.25f);
        TowerManager.TickHandler.Add(() => this.tick(), 1);
    }

    void Update(){

    }

    void tick(){
        foreach(Entity entity in entitiesInRange){
            DamageSourceInstance instance = new DamageSourceInstance(this.gameObject, entity.gameObject, damageSource);
            if(!entity.hasDamageSourceFromTower(this.gameObject)){
                entity.addDamageSource(instance);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collider){
        Entity entityComponent = collider.gameObject.GetComponent<Entity>();
        if(entityComponent != null){
            entitiesInRange.Add(entityComponent);
            
        }
    }

    void OnTriggerExit2D(Collider2D collider){
        Entity entityComponent = collider.GetComponent<Entity>();
        if(entityComponent != null){
            entitiesInRange.Remove(entityComponent);
        }
    }
}
