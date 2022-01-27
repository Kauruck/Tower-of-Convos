using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TowerManager : MonoBehaviour
{

    public static Dictionary<Action, int> TickHandler = new Dictionary<Action, int>();

    public static int maxTimeElapsed = 60;

    public int timeElapsed = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timeElapsed += Mathf.FloorToInt(Time.deltaTime);
        if(timeElapsed > maxTimeElapsed){
            timeElapsed = maxTimeElapsed;
        }
        foreach(KeyValuePair<Action, int> current in TickHandler){
            if(timeElapsed % current.Value == 0){
                current.Key.Invoke();
            }
        }
        if(timeElapsed == maxTimeElapsed){
            timeElapsed = 0;
        }
    }
}
