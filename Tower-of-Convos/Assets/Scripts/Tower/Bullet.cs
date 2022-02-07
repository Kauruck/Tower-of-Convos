using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public DamageSource damageSource;

    public float speed = 0.2f;

    GameObject target;

    bool hit = false;

    bool freze = true;
    // Start is called before the first frame update
    void Start()
    {
        TowerManager.TickHandler.Add(() => this.tick(), 1);
    }

    // Update is called once per frame
    void Update()
    {
        if(!freze){
            if(target == null){
                GameObject.Destroy(this.gameObject);
            }
            Vector3 offset = target.transform.position - transform.position;
            offset = Vector3.Normalize(offset);
            this.transform.position += offset * speed * Time.deltaTime;
        }
    }

    void tick(){
        if(!freze){
            if(target == null){
                GameObject.Destroy(this.gameObject);
            }
            if(hit){
                DamageSourceInstance instance = new DamageSourceInstance(this.gameObject, target, damageSource);
                target.GetComponent<Entity>().addDamageSource(instance);
                GameObject.Destroy(this.gameObject);
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collider){
        if(collider.gameObject == target){
            hit = true;
        }
    }

    public void setTarget(GameObject target){
        this.target = target;
    }

    public void setFreze(bool freze){
        this.freze = freze;
    }
}
