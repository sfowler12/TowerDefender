using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
    BuildManager bm;
    private GameObject turret;
    private Renderer rend;
    private Color startColor;

    public Color hoverColor;
    public Vector3 positionOffset;

    private void Start()
    {
        bm = BuildManager.instance;
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
    }

    void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if (bm.GetTurretToBuild() == null) {
            return;
        }

        if (turret != null) { 
            Debug.Log("Can't build there!"); // DISPLAY ON SCREEN LATER...
            return;
        }

        //Build Turret ... UPDATE LATER...
        GameObject turretToBuild = bm.GetTurretToBuild();
        positionOffset = turretToBuild.GetComponent<Turret>().offSet;
        turret = (GameObject) Instantiate(turretToBuild, transform.position + positionOffset, transform.rotation);
        bm.turretToBuild = null;
    }

    // Hover Effect
    void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if (bm.GetTurretToBuild() == null)
        {
            return;
        }

        rend.material.color = hoverColor;
    }

    void OnMouseExit()
    {
        rend.material.color = startColor;
    }
}
