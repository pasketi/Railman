using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour {

	//int target = 8;
	int wall = 1 << 9;
	Vector3 mid = new Vector3(Screen.width/2, Screen.height/2);
	public GameObject hitEffect;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0)){
			Ray ray = Camera.main.ScreenPointToRay (mid);
			RaycastHit hit;
			if (Physics.Raycast (ray, out hit, 100, wall)){
				Debug.Log (hit.distance + " m away, to " + hit.point);
				Instantiate (hitEffect, hit.point, Quaternion.identity);
			}
		}
	}
}
