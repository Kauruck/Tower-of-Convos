using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCollider : MonoBehaviour
{
    
    public GameObject tower;
    private List<Collider2D> collisions = new List<Collider2D>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        

    }
    public bool mCheckCollider(Vector3 pPosition)
    {      
        ContactFilter2D filter = new ContactFilter2D();
        filter.layerMask = LayerMask.GetMask("SpawnCollider");
        Physics2D.OverlapCircle(pPosition, 2, filter, collisions);
        for(int i = 0; i<collisions.Count;i++){
            if (collisions[i].gameObject != this.gameObject)
            {
                return true;
            
            }
        }
        return false;
    }
}
