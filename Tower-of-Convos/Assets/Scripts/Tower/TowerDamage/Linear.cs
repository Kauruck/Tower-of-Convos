using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Linear : IHandleDamageTick
{
    private Dictionary<Entity, int> entityDic = new Dictionary<Entity, int>();

    public Linear(float baseDamage, float deltaDamage){
        this.baseDamage = baseDamage;
        this.deltaDamage = deltaDamage;
    }

    public float baseDamage;
    public float deltaDamage;
    public float damageTick(Entity entity){
        if(!entityDic.ContainsKey(entity)){
            entityDic.Add(entity, -1);
        }
        entityDic[entity]++;
        return deltaDamage * entityDic[entity] + baseDamage;
    }

    public int timeBetweenDamage(){
        return 1;
    }
}
