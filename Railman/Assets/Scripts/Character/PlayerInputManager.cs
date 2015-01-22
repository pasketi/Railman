using UnityEngine;
using System.Collections;

public class PlayerInputManager : MonoBehaviour {

	LevelManager manager;
	CharacterController player;

	private const int def = 0, target = 8, wall = 9, mirror = 11;
	private Vector3 zero = Vector3.zero;

	public float maxShootSpeed = 5f;
	public AudioSource soundEmitter;
	public GameObject rail, muzzle, lazerHit, hitEffect;
	//Debug
	//public GameObject debugRail;
	
	private Vector3 mid;
	private LineRenderer line;
	//Debug
	//private LineRenderer debugLine;
	private bool hitWall = false;
	private int bounces = 0, maxBounces = 10;

	//Use this for initialization
	void Start () {
		player = (CharacterController) GameObject.Find("FirstPersonController").GetComponent(typeof(CharacterController));
		manager = (LevelManager) GameObject.Find("oLevelManager").GetComponent(typeof(LevelManager));
		line = rail.GetComponent<LineRenderer>();
		//Debug
		//debugLine = debugRail.GetComponent<LineRenderer>();
		mid = new Vector3(Screen.width/2, Screen.height/2);
	}

	void shoot (Vector3 origin, Vector3 reflectDirection){
		Debug.Log (bounces);
		if (bounces < maxBounces){
			int i = 0;
			RaycastHit hit;
			Ray ray;

			if (reflectDirection != zero) ray = new Ray(origin, reflectDirection);
			else ray = Camera.main.ScreenPointToRay (mid);

			while (!hitWall){
				if (Physics.Raycast (ray, out hit)){
					if (hit.transform.gameObject.layer == target) {
						//Debug.Log ("Hit a target! Target destroyed!");
						hit.collider.enabled = false;
						hit.transform.gameObject.tag = "Doomed";
						Instantiate (hitEffect, hit.point, Quaternion.identity);
					} else if (hit.transform.gameObject.layer == def) {
						//Debug.Log ("Hit an object! Object destroyed!");
						hit.collider.enabled = false;
						hit.transform.gameObject.tag = "Doomed";
						Instantiate (hitEffect, hit.point, Quaternion.identity);
					} else if (hit.transform.gameObject.layer == mirror) {
						line.SetPosition(0, origin);
						line.SetPosition(1, hit.point);
						Instantiate (rail);

						// Render the mirrors normalvector
						//debugLine.SetPosition(0, hit.point);
						//debugLine.SetPosition(1, hit.normal);
						//Instantiate (debugRail);

						bounces++;
						shoot(hit.point, Vector3.Reflect((hit.point - origin).normalized, hit.normal));
					} else if (hit.transform.gameObject.layer == wall) {
						Debug.Log (hit.distance + " m away, to " + hit.point);
						Instantiate (hitEffect, hit.point, Quaternion.identity);
						Instantiate (lazerHit, hit.point, hit.transform.rotation);
						line.SetPosition(0, origin);
						line.SetPosition(1, hit.point);
						Instantiate (rail);
						hitWall = true;
					} else {
						//Debug.Log ("Something went wrong. Hit layer: " + hit.transform.gameObject.layer + " hit point: " + hit.point);
						hitWall = true;
					}
				}
				i++;
				if (i > 50 || bounces >= maxBounces){
					hitWall = true;
					Debug.Log ("Something went wrong. Infinite Loop. " + bounces + "/" + maxBounces + " " + i);
				}
			}
		} else Debug.Log ("Maximum number of Bounces reached!");
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0) && manager.getBulletsLeft() != 0 && player.velocity.magnitude <= maxShootSpeed){
			Instantiate (soundEmitter, Camera.main.transform.position, Quaternion.identity);
			Instantiate (muzzle, Camera.main.transform.position, Camera.main.transform.rotation);
			shoot (Camera.main.transform.position, zero);
			hitWall = false;
			bounces = 0;
			manager.useBullet();
		}

		if (Input.GetKeyDown(KeyCode.E)){
			manager.toggleTimeFreeze();
		}
		if (Input.GetKeyDown(KeyCode.Period)){
			manager.freezeTimeLimit += 10;
			manager.canTimeFreeze = true;
		}
		if (Input.GetKeyDown(KeyCode.Comma)){
			manager.weaponShots += 5;
		}
	}
}
