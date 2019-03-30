using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    BuildManager bm;

    private void Start()
    {
        bm = BuildManager.instance;
    }
    public void PurchaseStandardTurret()
    {
      
        bm.SetTurretToBuild(bm.stdTurretPrefab);
       
    }

    public void PurchaseAnotherTurret() // Make one for each type.
    {
       // bm.SetTurretToBuild(bm.anotherTurretPrefab);
    }
}
