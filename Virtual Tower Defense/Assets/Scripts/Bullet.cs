using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform target;
    public float speed = 70f;
    public GameObject ImpactEffect;

    public void Seek(Transform _target) {
        target = _target;
    }

    void Update(){
        if (target == null) {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        if (dir.magnitude <= distanceThisFrame) {
            HitTarget();
            return;
        }

        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
    }

    void HitTarget() {
        GameObject effectIn = (GameObject)Instantiate(ImpactEffect, transform.position, transform.rotation);
        Destroy(effectIn, 2f);
        Destroy(gameObject);
        Destroy(target.gameObject);
    }
}
