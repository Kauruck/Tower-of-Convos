using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCollider : MonoBehaviour
    
{

    public CircleCollider2D CC;
    public bool checkCollider = false;
    // Start is called before the first frame update
    void Start()
    {
        if (CC.IsTouchingLayers(LayerMask.GetMask("SpawnCollider")) == true)
        { 
        checkCollider = true;
    }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public bool mCheckCollider()
    {

        /*if (CC.IsTouchingLayers(LayerMask.GetMask("SpawnCollider")) == true)
        {
            return true;
        }
        else
        {
            return false;
        }*/

        if (Physics2D.OverlapCircle(this.transform.position, 20000, 6) == null)
        {
            Debug.Log("false1");
            return false;
           
        }
        else
        {
            Debug.Log("true1");
            return true;
            
        }
        Debug.Log("deinemom");
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
