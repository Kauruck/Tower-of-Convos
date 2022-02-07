using UnityEngine;
using System.Collections.Generic;
using TMPro;
public class Entity : MonoBehaviour {

    public List<DamageSourceInstance> damageSources = new List<DamageSourceInstance>();

    public TextMeshProUGUI damageText;

    public float health = 20;

    public int tickSinceLastDamage = 0;

    void OnEnable(){
        TowerManager.LateTickHandler.Add(() => this.tick(), 1);
    }

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

    void tick(){
        ProcessDamage();
        if(tickSinceLastDamage > 0){
            damageText.SetText("");
        }
        tickSinceLastDamage ++;
    }

    void ProcessDamage(){
        List<DamageSourceInstance> toRemove = new List<DamageSourceInstance>();
        float totalDamage = 0;
        foreach(DamageSourceInstance instance in damageSources){
            float damage = 0;
            if(instance.damageSource.isSingle){
                damage = instance.damageSource.amount;
                toRemove.Add(instance);
            }else{
                damage = instance.damageSource.damageTick.damageTick(this);
                instance.totaleTime += 1;
                if(instance.totaleTime > instance.damageSource.duration){
                    toRemove.Add(instance);
                }
            }
            totalDamage += damage; 
        }
        if(totalDamage != 0){
            this.health -= totalDamage;
            tickSinceLastDamage = 0;
            damageText.SetText(totalDamage.ToString());
        }
        foreach(DamageSourceInstance current in toRemove){
            damageSources.Remove(current);
        }
    }
}