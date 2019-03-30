using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class TurretBlueprint{
    public string name;
    public GameObject prefab;
    public Sprite sprite;

    public int price;
   
    public float range;
    public float power;
    public string type;
    public float cooldown;

    public string description;

    public Vector3 offSet;
}
