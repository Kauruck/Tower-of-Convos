using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Path3 : MonoBehaviour
{
    private float speed = 10.0f;
    private Vector2 target,target2,P1,P2;
    private Vector2 position;
    private Camera cam;
    private int checkpoint = 0;
    private int tx1,ty1;
    private float step,stomp,stomp2;

    // Start is called before the first frame update



    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(-130, 30, 0);
        target = new Vector2(6.0f, 28.0f);
        position = gameObject.transform.position;
        target = new Vector2(50,0);
        target2 = new Vector2(-75,-20);
        step = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if(step<100){
        step++;
        //stomp = (20/step)/2;
        stomp = (2/(step/30)-2);
        stomp2 =  (step / 10)-2; 


        transform.position = Vector2.MoveTowards(transform.position, target, stomp);
        transform.position = Vector2.MoveTowards(transform.position, target2, stomp2);
        }
        else{
            transform.position = Vector2.MoveTowards(transform.position,new Vector2(100,-20), 1);
        }
    }
}
