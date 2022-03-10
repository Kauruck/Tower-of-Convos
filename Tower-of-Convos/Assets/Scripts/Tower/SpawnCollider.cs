using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCollider : MonoBehaviour
    
{
    
    
    public CircleCollider2D CC;
    public bool checkCollider = false;
    public GameObject f;
    public bool Hud;
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

        /*if (CC.IsTouchingLayers(LayerMask.GetMask("SpawnCollider")) == true)
        {
            return true;
        }
        else
        {
            return false;
        }*/
        
        //Debug.Log(Physics2D.OverlapCircle(pPosition, 2, LayerMask.GetMask("SpawnCollider")).gameObject == this.gameObject);
        ContactFilter2D filter = new ContactFilter2D();
        filter.layerMask = LayerMask.GetMask("SpawnCollider");
        Physics2D.OverlapCircle(pPosition, 2, filter, collisions);
        //Debug.Log(collisions[0].gameObject);
        for(int i = 0; i<collisions.Count;i++)
        if (collisions[i].gameObject != this.gameObject)
        {
            //Debug.Log("false1");
            return true;
           
        }
        return false;

           }
   

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 8 )
        {
            checkCollider = true ;
        }

        if (collision.collider.gameObject.layer == LayerMask.NameToLayer("SpawnCollider"))
        {
            checkCollider = true;
        }
    }
}
