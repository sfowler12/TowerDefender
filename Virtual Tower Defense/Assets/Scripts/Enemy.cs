using UnityEngine;

public class Enemy : MonoBehaviour
{
	public float speed;

	private Transform target;
	private int waypointIndex =0;

	void Start(){
		target = waypoints.points[0];
	}

	void Update(){
		Vector3 dir = target.position - transform.position;
		transform.Translate(dir.normalized * speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, target.position) <= 0.4f) {
            GetNextWaypoint();
        }
	}

    void GetNextWaypoint() {
        if (waypointIndex >= waypoints.points.Length - 1) {
            Destroy(gameObject);
            return;
        }
        waypointIndex++;
        target = waypoints.points[waypointIndex];
    }
}
