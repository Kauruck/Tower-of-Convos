using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MovmentHelper : MonoBehaviour
{

    ///This one should be a normal vector
    public Vector3 direction = Vector3.zero;
    private Vector3 nextPosition;
    private Vector3 startPosition;
    public float speed;
    public Func<Vector3> updateDirection;
    public bool frozen = false;
    private bool startRan = false;
    // Start is called before the first frame update
    public void Start()
    {
        TowerManager.TickHandler.Add(() => this.tick(), 1);
        this.startPosition = this.transform.position;
        startRan = true;
        this.nextPosition = this.transform.position + direction * speed;
        this.startPosition = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(startRan)
        {
            if(!frozen)
                this.transform.position = Vector3.Lerp(this.startPosition, this.nextPosition, TowerManager.INSTANCE.localTime/TowerManager.INSTANCE.timeScale);
        }
    }

    void tick(){
        if(this == null)
            return;
        if(startRan){
            if(!frozen)
            {
                if(updateDirection != null)
                {
                    this.direction = updateDirection.Invoke();
                }
                this.transform.position = nextPosition;
                this.nextPosition = this.transform.position + direction * speed;
                this.startPosition = this.transform.position;
            }
        }
    }

    
}
