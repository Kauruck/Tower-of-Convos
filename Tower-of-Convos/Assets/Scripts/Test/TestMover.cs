using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMover : MonoBehaviour
    
{
    public bool Hud = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 startPos = this.transform.position;
        if(Input.GetKey(KeyCode.W)){
            startPos.y += 0.2f;
        }
        if(Input.GetKey(KeyCode.S)){
            startPos.y -= 0.2f;
        }
        if(Input.GetKey(KeyCode.D)){
            startPos.x += 0.2f;
        }
        if(Input.GetKey(KeyCode.A)){
            startPos.x -= 0.2f;
        }
        this.transform.position = startPos;
    }
}
