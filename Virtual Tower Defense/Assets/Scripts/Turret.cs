using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour{
   
    private Transform target;
    public float range = 12f; // Area of Range.

    public string enemyTag = "Enemy";
    public Transform partToRotate;
    public float turnSpeed = 10f;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f); // Checks for Target every .5 secs instead of every frame.
    }

    void UpdateTarget() {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag); // Adds enemies to a list.
        float shortestDistance = Mathf.Infinity; 
        GameObject nearestEnemy = null;

        foreach (GameObject enemy in enemies) {// For every enemy in the list check if nearest and update nearest enemy.
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance) {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        if (nearestEnemy != null && shortestDistance <= range) { // If nearest enemy is in range target it.
            target = nearestEnemy.transform;
        }else
        {
            target = null;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (target == null) {
            return;
        }

        // Calculates rotation of turret.
        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
        partToRotate.rotation = Quaternion.Euler(0f,rotation.y, 0f);

    }

    void OnDrawGizmosSelected() { // Draws Range in debug.
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
