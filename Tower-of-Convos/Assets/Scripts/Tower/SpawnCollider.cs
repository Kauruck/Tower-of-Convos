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

    void OnCollisionEnter2D(Collision2D col)
    {
       
        checkCollider=true;
    }
}
