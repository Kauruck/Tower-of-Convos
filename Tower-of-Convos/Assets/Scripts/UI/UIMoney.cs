using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine;
using System.Collections;
using TMPro;

public class UIMoney : MonoBehaviour
{

    private Text txt;
    public GameObject hand;
    private int money;

    // Use this for initialization
    void Start()
    {
        txt = this.GetComponent<Text>();
        hand = GameObject.Find("TowerManager");
        money = hand.GetComponent<TowerCreator>().money;
        gameObject.GetComponent<TextMeshProUGUI>().text = money.ToString();


    }

    // Update is called once per frame
    void Update()
    {
        money = hand.GetComponent<TowerCreator>().money;
        gameObject.GetComponent<TextMeshProUGUI>().text = money.ToString();
    }
}