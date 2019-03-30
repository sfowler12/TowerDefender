using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
    BuildManager bm;
    public GameObject turret;
    private Renderer rend;
    private Color startColor;

    public Color hoverColor;
    public Color notEnoughMoneyColor;
    public Vector3 positionOffset;

    private void Start()
    {
        bm = BuildManager.instance;
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
    }


    void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject()) {return;}
        if (!bm.CanBuild) {return;}
            
        if (turret != null) { 
            Debug.Log("Can't build there!"); // DISPLAY ON SCREEN LATER...
            // error sfx 
            return;
        }

        bm.BuildTurretOn(this);
    }

    // Hover Effect
    void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject()) {return;}
        if (!bm.CanBuild) { return; }

        if (bm.HasMoney)
        {
            rend.material.color = hoverColor;
        }else {
            rend.material.color = notEnoughMoneyColor;
        }
    }

    void OnMouseExit()
    {
        rend.material.color = startColor;
    }
}
