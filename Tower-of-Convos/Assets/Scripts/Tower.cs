using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{ private int i = 0;
    
    private BoxCollider2D bc;
    private Rigidbody2D rb;
    public GameObject P1;
    public bool attack = false;
    // Start is called before the first frame update
    void Start()
    {
        
        attack = false;
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
       
        attack = true;
        
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        attack = false;
        
    }
  
    // Update is called once per frame
    void Update()
    {
        
        if (attack == true)
        {
             
            
             
             i++;
                if (i == 100)
                {
                //object p = Instantiate(P1, new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z), this.transform.rotation);
                object p = Instantiate(P1, this.transform.position, this.transform.rotation);
                i = 0;
                }
            

        }
        if (attack == false)
        { }
        
    }

    
}
