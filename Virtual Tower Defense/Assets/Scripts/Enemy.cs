using UnityEngine;

public class Enemy : MonoBehaviour
{
	public float speed; 

	private Transform target; // The next waypoint its going to travel to.
	private int waypointIndex = 0; // Tracks the current waypoint it's traveling to. 

	void Start(){
		target = waypoints.points[0]; 
	}

	void Update(){ // Updates every Frame.
		Vector3 dir = target.position - transform.position; // Makes a 3d point to travel to. 
		transform.Translate(dir.normalized * speed * Time.deltaTime); // Every frame the enemy travels to the point. 

        if (Vector3.Distance(transform.position, target.position) <= 0.4f) { // If close enough to next point...
            GetNextWaypoint(); 
        }
	}

    void GetNextWaypoint() {// Find the next waypoint if any are left.
        if (waypointIndex >= waypoints.points.Length - 1) { // If at on last point...
            Destroy(gameObject); 
            return;
        }
        waypointIndex++; 
        target = waypoints.points[waypointIndex];  // New target is the next waypoint in the array.
    }
}
