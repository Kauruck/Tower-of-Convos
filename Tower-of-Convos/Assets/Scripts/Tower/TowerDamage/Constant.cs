using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Constant : IHandleDamageTick
{

    public Constant(int damagePerTick, int timeBetweenDamage){
        this.damagePerTick = damagePerTick;
        this.timeBetweenDamageValue = timeBetweenDamage;
    }
    public float damagePerTick;

    public int timeBetweenDamageValue;
    public float damageTick(Entity entity){
        return damagePerTick;
    }

    public int timeBetweenDamage(){
        return timeBetweenDamageValue;
    }
}
