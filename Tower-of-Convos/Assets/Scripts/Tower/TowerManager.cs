using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TowerManager : MonoBehaviour
{

    public static TowerManager INSTANCE;
    public int timeScale = 2;

    public float localTime = 0;
    public static Dictionary<Action, int> TickHandler = new Dictionary<Action, int>();
    public static Dictionary<Action, int> LateTickHandler = new Dictionary<Action, int>();

    public static int maxTimeElapsed = 60;

    public int timeElapsed = 0;
    // Start is called before the first frame update
    void Start()
    {
        INSTANCE = this;
    }

    void tick(){
        timeElapsed += 1;
        if(timeElapsed > maxTimeElapsed){
            timeElapsed = maxTimeElapsed;
        }
        foreach(KeyValuePair<Action, int> current in TickHandler){
            if(timeElapsed % current.Value == 0){
                current.Key.Invoke();
            }
        }
        foreach(KeyValuePair<Action, int> current in LateTickHandler){
            if(timeElapsed % current.Value == 0){
                current.Key.Invoke();
            }
        }
        if(timeElapsed == maxTimeElapsed){
            timeElapsed = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        localTime += Time.deltaTime;
        if(localTime > timeScale){
            tick();
            localTime = 0;
        }
        
    }
}
