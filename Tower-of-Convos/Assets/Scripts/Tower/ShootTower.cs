using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootTower : MonoBehaviour
{
    List<Entity> entitiesInRange = new List<Entity>();
    public GameObject bullet;

    // Start is called before the first frame update
    void Start()
    {
        TowerManager.TickHandler.Add(() => this.tick(), 1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void tick(){
        int random = Random.Range(0, entitiesInRange.Count);
        Entity entity = entitiesInRange[random];
        GameObject newBullet = GameObject.Instantiate(bullet, this.transform.position, Quaternion.identity);
        Debug.Log(newBullet);        
        Bullet bulletComponent = newBullet.GetComponent<Bullet>();
        bulletComponent.setTarget(entity.gameObject);
        bulletComponent.setFreze(false);
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
