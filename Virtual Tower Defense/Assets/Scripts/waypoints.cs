using UnityEngine;

public class waypoints : MonoBehaviour{
	public static Transform[] points; // List of all the points on the map.

	void Awake(){ // Runs as the game starts.
		points = new Transform[transform.childCount]; // Makes the array the size of the length of all the child objects.
		for (int i = 0; i < points.Length; i++) {
			points[i] =  transform.GetChild(i); // Populates array with all the child objects.
        }
	}
}
