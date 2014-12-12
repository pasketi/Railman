using UnityEngine;
using System.Collections;

public class ObjectHandler : MonoBehaviour {

	LevelManager manager;
	private Vector3 aVelocity, tVelocity;

	// Use this for initialization
	void Start () {
		manager = (LevelManager) GameObject.Find("oLevelManager").GetComponent(typeof(LevelManager));
	}

	// Update is called once per frame
	void Update () {

		//Time toggle -handler
		if (manager.getTimeFreeze() == false && manager.getToggled()) {
			gameObject.rigidbody.isKinematic = false;
			gameObject.rigidbody.angularVelocity = aVelocity;
			gameObject.rigidbody.velocity = tVelocity;
			Debug.Log("Resumed " + manager.getTimeFreeze());
		} else if (manager.getTimeFreeze() == true && manager.getToggled()) {
			gameObject.rigidbody.velocity = Vector3.zero;
			gameObject.rigidbody.angularVelocity = Vector3.zero;
			gameObject.rigidbody.isKinematic = true;
			Debug.Log("Time Paused " + manager.getTimeFreeze());
		}

		//Velocity updater
		if (!manager.getTimeFreeze()) {
			aVelocity = gameObject.rigidbody.angularVelocity;
			tVelocity = gameObject.rigidbody.velocity;
			Debug.Log(gameObject + " Updated : " + gameObject.rigidbody.velocity + " " + gameObject.rigidbody.angularVelocity);
		}

		//Destroy object once it has been hit and time is not frozen
		if (gameObject.tag == "Doomed" && !manager.getTimeFreeze()){
			DestroyImmediate(gameObject);
		}
	}
}
