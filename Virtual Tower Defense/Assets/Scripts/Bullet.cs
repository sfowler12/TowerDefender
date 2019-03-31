using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform target;
    public float speed = 70f;
    public float explosionRadius = 0;
    public GameObject ImpactEffect;
    public PlayerStats ps;
    public Shop shop;

    public void Seek(Transform _target) {
        target = _target;
    }

    void Update(){
        if (target == null) { // Error Handling
            Destroy(gameObject);
            return;
        }

        //Bullet Movement
        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        if (dir.magnitude <= distanceThisFrame) {
            HitTarget();
            return;
        }

        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
        transform.LookAt(target);

    }

    void HitTarget() {// On Collision
        GameObject effectIn = (GameObject)Instantiate(ImpactEffect, transform.position, transform.rotation);
        Destroy(effectIn, 2f);
        FindObjectOfType<AudioManager>().Play("ExplosionSound");
        PlayerStats.Money += 10;    //destroying an enemy gives $10

        if (explosionRadius > 0f) {
            Explode();
        }
        else
        {
            Damage(target);
        }
        Destroy(gameObject);
        
    }

    void Explode() {
       Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);

        foreach(Collider collider in colliders)
        {
            if (collider.tag == "Enemy") {
                Damage(collider.transform);
            }
        }
    }

    void Damage(Transform enemy) {
        Destroy(enemy.gameObject);
    }

    void OnDrawGizmosSelected()
    { // Draws area of explosion if any
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }

}
