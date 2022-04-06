using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;

public class Damage : MonoBehaviour
{

    private TextMeshProUGUI txt;
    public Upgrade upgradeButton;
    public TowerCreator towerCreator;
    private GameObject tower;
    public GameObject selectedTower;
    private ShootTower localShootTower;
    private Vector3 tempPos;
    private Vector3 worldPosition;
    private Vector2 nWorldPosition;
    private float tempDamage;

    // Use this for initialization
    void Start()
    {
        txt = this.GetComponent<TextMeshProUGUI>();
        upgradeButton = GameObject.Find("UpgradeButton").GetComponent<Upgrade>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
         
            tempPos = Input.mousePosition;

            tempPos.z = -(Camera.main.transform.position.z);
            worldPosition = Camera.main.ScreenToWorldPoint(tempPos);

            nWorldPosition = new Vector2(worldPosition.x, worldPosition.y);

            RaycastHit2D hit = Physics2D.Raycast(nWorldPosition, Vector2.zero, 1f, LayerMask.GetMask("SpawnCollider"));
            
            if(hit == true)
            {
                selectedTower = hit.collider.gameObject.GetComponent<SpawnCollider>().tower;
                localShootTower = selectedTower.GetComponent<ShootTower>();
                tempDamage = localShootTower.damageSource.amount;
                txt.text = tempDamage.ToString();
            }
            
            

        }
        if (selectedTower != null)
        {
            tempDamage = localShootTower.damageSource.amount;
            txt.text = "Damage: " + tempDamage.ToString();
        }
        if (upgradeButton.upgrade == true && selectedTower != null && towerCreator.money >= 5000)
        {
            localShootTower.damageSource.amount += 5;
            upgradeButton.upgrade = false;
            towerCreator.money -= 5000;
        }

    }
      
}