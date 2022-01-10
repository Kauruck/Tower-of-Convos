using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Towerspawn : MonoBehaviour
{
    public int money = 0;
    public GameObject P1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            {
            if (money > 750)
            {
                Debug.Log(Input.mousePosition);
                object p = Instantiate(P1, Input.mousePosition, this.transform.rotation);
                money = money - 750;
            }
        }
    }
    void FixedUpdate()
    {
        money++;
    }
}
