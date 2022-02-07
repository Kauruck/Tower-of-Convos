using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingBullet : MonoBehaviour
{
    public DamageSource damageSource;

    public float speed = 0.2f;

    GameObject target;

    bool hit = false;

    bool freeze = true;

    public Vector3 nextPos;

    private Vector3 startPos;
    // Start is called before the first frame update
    void Start()
    {
        TowerManager.TickHandler.Add(() => this.tick(), 1);
        nextPos = this.transform.position;
        startPos = this.transform.position;
    }

    void Update()
    {
        if(!hit){
            this.transform.position = Vector3.Lerp(this.startPos, this.nextPos, TowerManager.INSTANCE.localTime / (TowerManager.INSTANCE.timeScale));
        }
        else{
            this.transform.position = Vector3.Lerp(this.transform.position, this.target.transform.position, TowerManager.INSTANCE.localTime / (TowerManager.INSTANCE.timeScale));
        }
    }


    void tick(){
        if(this == null)
            return;
        if(!freeze){
            if(target == null){
                GameObject.Destroy(this.gameObject);
            }
            if(this.transform.position != this.nextPos)
                this.transform.position = nextPos;
            if(hit){
                DamageSourceInstance instance = new DamageSourceInstance(this.gameObject, target, damageSource);
                target.GetComponent<Entity>().addDamageSource(instance);
                GameObject.Destroy(this.gameObject);
            }
            else {
                Vector3 offset = target.transform.position - transform.position;
                offset = Vector3.Normalize(offset);
                this.nextPos = this.transform.position + offset * speed;
                startPos = this.transform.position;
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
    }

    public void setFreeze(bool freeze){
        this.freeze = freeze;
    }
}
