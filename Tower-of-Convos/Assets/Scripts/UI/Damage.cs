using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine;
using System.Collections;
using TMPro;

public class Damage : MonoBehaviour
{

    private Text txt;
    public GameObject hand;
    private GameObject tower;

    // Use this for initialization
    void Start()
    {
        txt = this.GetComponent<Text>();
        hand = GameObject.Find("TowerManager");
        tower = hand.GetComponent<TowerCreator>().P3;
        


    }

    // Update is called once per frame
    void Update()
    {
       
    }
}