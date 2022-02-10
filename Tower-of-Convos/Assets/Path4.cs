using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Path4 : MonoBehaviour
{
    private float speed = 10.0f;
    private Vector2 target,target2;
    private Vector2 position;
    private Camera cam;
    private int checkpoint = 0;
    private int tx1,ty1,bob;
    private float step,stomp,stomp2;
    public GameObject Object1,Object2;

    // Start is called before the first frame update



    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(-130, -28, 0);
        target = new Vector2(6.0f, 28.0f);
        position = gameObject.transform.position;
        target = Object1.transform.position;
        target2 = Object2.transform.position;
        step = 1;
        bob = 0; 
    }

    // Update is called once per frame
    void Update()
    {
        if(step<60 && bob<2){
        step++;

        
        //stomp = (2/(step/30)-2);
        //stomp2 =  (step / 10)-2; 
        // Bogen 

        if(bob==0){
        stomp = (2/(step/30)-4);
        stomp2 =  (step / 10)-4; 
        transform.position = Vector2.MoveTowards(transform.position, target, stomp);
        transform.position = Vector2.MoveTowards(transform.position, target2, stomp2);
        }
        
        if(bob==1){
        target = new Vector2(100,-50);
        stomp=5;
        transform.position = Vector2.MoveTowards(transform.position, target, stomp);
        }

       
        }
        else{
            bob++;
            step = 0;
            
        }
    }
}