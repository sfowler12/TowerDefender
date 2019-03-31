using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Shop : MonoBehaviour
{
    BuildManager bm;
    public TextMeshProUGUI playerMoney;
    public int highlightedTurNum;
    public bool turretPurchased;
    public TextMeshProUGUI ItemName;
    public TextMeshProUGUI ItemInfo;
    public TextMeshProUGUI ItemPrice;
    public Image ItemImage;
    

    public TurretBlueprint[] turretBlueprints;
    //-1 = NULL | 0 = stdTurret | 1 = mslTurret | 

     void Start()
    {
        ClearInfo(); // Gets rid of placeholder info

        bm = BuildManager.instance;
    }
    public void Update()
    {
       playerMoney.text = "Funds: $" + PlayerStats.Money.ToString();

    }
    // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
    // Make function for each type of turret 
    public void PurchaseStandardTurret() 
    {
        bm.SelectTurretToBuild(turretBlueprints[0]);
        turretPurchased = true;
    }

    public void PurchaseMissileTurret() 
    {
        bm.SelectTurretToBuild(turretBlueprints[1]);
        turretPurchased = true;
    }
    // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

    //Manages Shop Info 
    public void UpdateInfo(int BlueprintNum) {
        
        if (!turretPurchased)
        {
            highlightedTurNum = BlueprintNum;
            TurretBlueprint tur = turretBlueprints[highlightedTurNum];
            ItemImage.gameObject.SetActive(true);
            ItemName.text = tur.name;
            ItemImage.sprite = turretBlueprints[highlightedTurNum].sprite;
            ItemPrice.text = "$" + tur.price; //.ToString("0000");

            ItemInfo.text = "Type: " + tur.type + "\t\tRange:" + tur.range
                            + "\nPower:" + tur.power + "\t\tCooldown:" + tur.cooldown
                            + "\nDescription:" + tur.description;
        }
    }

    public void ClearInfo()
    {
        if (!turretPurchased)
        {
            ItemImage.gameObject.SetActive(false);
            ItemName.text = "";
            ItemImage.sprite = null;
            ItemPrice.text = "";
            ItemInfo.text = "";
            highlightedTurNum = -1;

        }
    }
}
