using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour {

	private const int def = 0, target = 8, wall = 9;
	bool hitWall = false;

	Vector3 mid;
	public GameObject hitEffect;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0)){
			mid = new Vector3(Screen.width/2, Screen.height/2);
			Ray ray = Camera.main.ScreenPointToRay (mid);
			RaycastHit hit;
			int i = 0;
			while (hitWall == false){
				if (Physics.Raycast (ray, out hit)){
					if (hit.transform.gameObject.layer == target) {
						Debug.Log ("Hit a target! Target destroyed!");
						/*if (Time.timeScale != 0){
							DestroyImmediate(hit.transform.gameObject);
						} else {*/
							//Destroy(hit.transform.gameObject);
							hit.collider.enabled = false;
						//}
						Instantiate (hitEffect, hit.point, Quaternion.identity);
					} else if (hit.transform.gameObject.layer == def) {
						Debug.Log ("Hit an object! Object destroyed!");
						/*if (Time.timeScale != 0){
							DestroyImmediate(hit.transform.gameObject);
						} else {*/
							//Destroy(hit.transform.gameObject);
							hit.collider.enabled = false;
						//}
						Instantiate (hitEffect, hit.point, Quaternion.identity);
					} else if (hit.transform.gameObject.layer == wall) {
						Debug.Log (hit.distance + " m away, to " + hit.point);
						Instantiate (hitEffect, hit.point, Quaternion.identity);
						hitWall = true;
					} else {
						Debug.Log ("Something went wrong. Hit layer: "+hit.transform.gameObject.layer + " hit point: " + hit.point);
						Instantiate (hitEffect, hit.point, Quaternion.identity);
						hitWall = true;
					}
				}
				i++;
				if (i > 50){
					hitWall = true;
					Debug.Log ("Something went wrong. Infinite Loop.");
				}
			}
			hitWall = false;
			i = 0;
		}
	}
}
