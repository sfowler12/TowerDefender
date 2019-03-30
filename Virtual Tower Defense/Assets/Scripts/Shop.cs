using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Shop : MonoBehaviour
{
    BuildManager bm;
    public ItemInfo selectedItem;
    public TextMeshProUGUI ItemName;
    public TextMeshProUGUI ItemInfo;
    public TextMeshProUGUI ItemPrice;
    public Image ItemImage;

    private void Start()
    {
        ClearInfo();
        bm = BuildManager.instance;
    }
    public void PurchaseStandardTurret()
    {
        bm.SetTurretToBuild(bm.stdTurretPrefab);
    }

    public void PurchaseMissileTurret() // Make one for each type.
    {
        bm.SetTurretToBuild(bm.mslTurretPrefab);
    }

    public void GetSelectedItemInfo(ItemInfo ItemPassedIn) {
        selectedItem = ItemPassedIn;
        UpdateInfo();
    }
    public void UpdateInfo()
    {
        ItemImage.gameObject.SetActive(true);
        ItemName.text = selectedItem.ItemName;
        ItemImage.sprite = selectedItem.ItemSprite;
        ItemPrice.text = "$" + selectedItem.ItemPrice;
        ItemInfo.text = "Range: " + selectedItem.range + "\nFire Rate:" + selectedItem.fireRate + "\nPower:" + selectedItem.power;
    }

    public void ClearInfo() {
        ItemImage.gameObject.SetActive(false);
        ItemName.text = "";
        ItemImage.sprite = null;
        ItemPrice.text = "";
        ItemInfo.text = "";
    }
}
