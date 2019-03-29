using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;
    private GameObject turretToBuild;
    public GameObject stdTurretPrefab; // Might want to make an array of turrets later.

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

    private void Start()
    {
        turretToBuild = stdTurretPrefab;
    }


    public GameObject GetTurretToBuild()
    {
        return turretToBuild;
    }
}
