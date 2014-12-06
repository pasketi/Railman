/*using UnityEngine;
using System.Collections;

public class WeaponScript : MonoBehaviour {

	public GameObject MuzzlePrefab, BeamPrefab, PlayerCamera;
	Vector3 barrelPos = new Vector3(0,0,0.5f);
	int shotLifeTime;
	shot testShot;

	class shot {
		public shot(){
			setBirthTime(Time.time);
		}

		public void setBirthTime(int newBirthTime){
			birthTime = newBirthTime;
		}

		public int getBirthTime(){
			return birthTime;
		}

		public void shoot(GameObject muzzle, GameObject PlayerCam, Vector3 barrel){
			Instantiate (Muzzle, PlayerCam.transform.position, barrel, Quaternion.identity);
			//Instantiate (Beame, PlayerCamera.transform.position + barrelPos, Quaternion.identity);
			setBirthTime(Time.time);
		}

		private int birthTime;
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(1)){
			testShot = new shot();
			testShot.shoot(MuzzlePrefab, PlayerCamera, barrelPos);
		}
		if (testShot.getBirthTime() + 100 >= testShot.getBirthTime()){
			Destroy(testShot);
		}
	}
}
*/