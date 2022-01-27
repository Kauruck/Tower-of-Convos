using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Constant : IHandleDamageTick
{

    public float damagePerTick = 2f; 
    public float damageTick(Entity entity){
        return damagePerTick;
    }
}
