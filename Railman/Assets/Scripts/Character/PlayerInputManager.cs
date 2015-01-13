using UnityEngine;
using System.Collections;

public class PlayerInputManager : MonoBehaviour {

	LevelManager manager;
	CharacterController player;
	public float maxShootSpeed = 5f;
	public GameObject hitEffect;
	public AudioSource soundEmitter;
	public GameObject rail;
	private LineRenderer line;
	public GameObject muzzle;
	public GameObject lazerHit;

	private const int def = 0, target = 8, wall = 9;
	bool hitWall = false;

	Vector3 mid;

	// Use this for initialization
	void Start () {
		player = (CharacterController) GameObject.Find("FirstPersonController").GetComponent(typeof(CharacterController));
		manager = (LevelManager) GameObject.Find("oLevelManager").GetComponent(typeof(LevelManager));
		line = rail.GetComponent<LineRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0) && manager.getBulletsLeft() != 0 && player.velocity.magnitude <= maxShootSpeed){
			Instantiate (soundEmitter, Camera.main.transform.position, Quaternion.identity);
			mid = new Vector3(Screen.width/2, Screen.height/2);
			Ray ray = Camera.main.ScreenPointToRay (mid);
			RaycastHit hit;
			int i = 0;
			while (hitWall == false){
				if (Physics.Raycast (ray, out hit)){
					if (hit.transform.gameObject.layer == target) {
						Debug.Log ("Hit a target! Target destroyed!");
						hit.collider.enabled = false;
						hit.transform.gameObject.tag = "Doomed";
						Instantiate (hitEffect, hit.point, Quaternion.identity);
					} else if (hit.transform.gameObject.layer == def) {
						Debug.Log ("Hit an object! Object destroyed!");
						hit.collider.enabled = false;
						hit.transform.gameObject.tag = "Doomed";
						Instantiate (hitEffect, hit.point, Quaternion.identity);
					} else if (hit.transform.gameObject.layer == wall) {
						Debug.Log (hit.distance + " m away, to " + hit.point);
						Instantiate (hitEffect, hit.point, Quaternion.identity);
						Instantiate (muzzle, Camera.main.transform.position, Camera.main.transform.rotation);
						Instantiate (lazerHit, hit.point, hit.transform.rotation);
						line.SetPosition(0, Camera.main.transform.position);
						line.SetPosition(1, hit.point);
						Instantiate (rail);
						hitWall = true;
					} else {
						Debug.Log ("Something went wrong. Hit layer: "+hit.transform.gameObject.layer + " hit point: " + hit.point);
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
			manager.useBullet();
		}

		if (Input.GetKeyDown(KeyCode.E)){
			manager.toggleTimeFreeze();
		}
		if (Input.GetKeyDown(KeyCode.Period)){
			manager.weaponShots += 5;
			manager.freezeTimeLimit += 10;
			manager.canTimeFreeze = true;
		}
	}
}
