using UnityEngine;
public class DamageSourceInstance {
    public GameObject source;
    public GameObject target;
    public DamageSource damageSource;

    public float totaleTime = 0;

    public DamageSourceInstance(GameObject source, GameObject target, DamageSource damageSource){
        this.source = source;
        this.target = target;
        this.damageSource = damageSource;
    }
}