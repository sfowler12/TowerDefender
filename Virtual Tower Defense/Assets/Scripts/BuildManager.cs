using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;
    public TurretBlueprint turretToBuild;
    public Shop shop;
    public bool CanBuild;
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

    public bool HasMoney { get { return PlayerStats.Money >= turretToBuild.price; } }

    public void SelectTurretToBuild(TurretBlueprint turretBlue)
    {
        turretToBuild = turretBlue;
        CanBuild = true;
    }

    public void BuildTurretOn(Node node) {
        if (PlayerStats.Money < turretToBuild.price) {
            Debug.Log("Not enough money.");
            return;
        }

        PlayerStats.Money -= turretToBuild.price;
        Debug.Log("Turret build. Money = $" + PlayerStats.Money.ToString());
        GameObject turret = (GameObject)Instantiate(turretToBuild.prefab, node.transform.position + turretToBuild.offSet, Quaternion.identity);
        node.turret = turret;

        CanBuild = false;
        turretToBuild = null;
        shop.turretPurchased = false;
        shop.ClearInfo();
    }
}
