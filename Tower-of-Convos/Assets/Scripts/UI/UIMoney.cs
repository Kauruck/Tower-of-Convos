using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;

public class UIMoney : MonoBehaviour
{

    private TextMeshProUGUI txt;
    private TowerCreator manger;
    private int money;

    // Use this for initialization
    void Start()
    {
        txt = this.GetComponent<TextMeshProUGUI>();
        manger = GameObject.Find("TowerManager").GetComponent<TowerCreator>();
        money = manger.money;
    }

    // Update is called once per frame
    void Update()
    {
        money = manger.money;
        txt.text = "Money: " + money.ToString();
    }
}