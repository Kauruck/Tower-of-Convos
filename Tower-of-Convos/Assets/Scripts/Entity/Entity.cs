using UnityEngine;
using System.Collections.Generic;
public class Entity : MonoBehaviour {

    public List<DamageSourceInstance> damageSources = new List<DamageSourceInstance>();

    public float health = 20;


    public bool hasDamageSourceFromTower(GameObject tower){
        bool output = false;
        foreach(DamageSourceInstance current in damageSources){
            if(current.source == tower){
                output = true;
                break;
            }
        }
        return output;
    }

    public void addDamageSource(DamageSourceInstance damageSource){
        this.damageSources.Add(damageSource);
    }

    void FixedUpdate(){
        foreach(DamageSourceInstance instance in damageSources){
            float damage = 0;
            if(instance.damageSource.isSingle){
                damage -= instance.damageSource.amount;
            }else{
                damage -= instance.damageSource.damageTick.damageTick(this);
                instance.totaleTime += Time.fixedDeltaTime;
                if(instance.totaleTime > instance.damageSource.duration){
                    damageSources.Remove(instance);
                }
            }
            this.health -= damage;
            Debug.Log(damage);
        }
    }
}