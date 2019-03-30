using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;
    public TurretBlueprint turretToBuild;
    //public GameObject stdTurretPrefab; // Might want to make an array of turrets later.
    //public GameObject mslTurretPrefab;
    public Shop shop;

    //Singleton
    private void Awake()
    {
        if(instance != null)
        {
            Debug.LogError("More than one BuildManager in scene!");
            return;
        }

        instance = this;
    }

    public bool CanBuild { get { return turretToBuild != null; }}

    public bool HasMoney { get { return PlayerStats.Money >= turretToBuild.price; } }

    public void SelectTurretToBuild(TurretBlueprint turretBlue)
    {
        turretToBuild = turretBlue;
    }

    public void BuildTurretOn(Node node) {
        if (PlayerStats.Money < turretToBuild.price) {
            Debug.Log("Not enough money.");
            return;
        }

        PlayerStats.Money -= turretToBuild.price;
        shop.playerMoney.text = "Funds: $" +PlayerStats.Money;

        GameObject turret = (GameObject)Instantiate(turretToBuild.prefab, node.transform.position + turretToBuild.offSet, Quaternion.identity);
        node.turret = turret;

        turretToBuild = null;
        shop.turretPurchased = false;
        shop.ClearInfo();
    }
}
