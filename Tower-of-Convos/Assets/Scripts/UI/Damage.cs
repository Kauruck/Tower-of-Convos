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
    public GameObject hand2;
    private GameObject tower;
    public GameObject P3;
    private Vector3 tempPos;
    private Vector3 worldPosition;
    private Vector2 nWorldPosition;
    private float tempD;

    // Use this for initialization
    void Start()
    {
        txt = this.GetComponent<Text>();
        hand = GameObject.Find("Button");
        tower = hand.GetComponent<TowerCreator>().P3;
        P3 = null;


    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Debug.Log("lmao");
            tempPos = Input.mousePosition;

            tempPos.z = -(Camera.main.transform.position.z);
            worldPosition = Camera.main.ScreenToWorldPoint(tempPos);

            nWorldPosition = new Vector2(worldPosition.x, worldPosition.y);

            RaycastHit2D hit1 = Physics2D.Raycast(nWorldPosition, Vector2.zero, 1f, LayerMask.GetMask("SpawnCollider"));
            hit1.collider.GetComponent<SpawnCollider>().Hud = true;
            P3 = hit1.collider.gameObject;
            P3 = P3.GetComponent<SpawnCollider>().f;
            tempD = P3.GetComponent<ShootTower>().damageSource.amount;
            gameObject.GetComponent<TextMeshProUGUI>().text = tempD.ToString();

        }
        if (P3 != null)
        {
            tempD = P3.GetComponent<ShootTower>().damageSource.amount;
            gameObject.GetComponent<TextMeshProUGUI>().text = "Damage: " + tempD.ToString();
        }
        if (hand.GetComponent<Upgrade>().upgrade == true && P3 != null)
        {
            P3.GetComponent<ShootTower>().damageSource.amount = P3.GetComponent<ShootTower>().damageSource.amount + 5;
            hand.GetComponent<Upgrade>().upgrade = false;
            hand2.GetComponent<TowerCreator>().money = hand2.GetComponent<TowerCreator>().money - 5000;

        }

    }
}