using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public int i;
    public GameObject P1;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (i == 100)
        {
            object p = Instantiate(P1, this.transform.position, this.transform.rotation);
            i = 0;
        }
        i++;
    }
}
