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
			gameObject.GetComponent<Rigidbody>().isKinematic = false;
			gameObject.GetComponent<Rigidbody>().angularVelocity = aVelocity;
			gameObject.GetComponent<Rigidbody>().velocity = tVelocity;
		} else if (manager.getTimeFreeze() == true && manager.getToggled()) {
			gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
			gameObject.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
			gameObject.GetComponent<Rigidbody>().isKinematic = true;
		}

		//Velocity updater
		if (!manager.getTimeFreeze()) {
			aVelocity = gameObject.GetComponent<Rigidbody>().angularVelocity;
			tVelocity = gameObject.GetComponent<Rigidbody>().velocity;
		}

		//Destroy object once it has been hit and time is not frozen
		if (gameObject.tag == "Doomed" && !manager.getTimeFreeze()){
			DestroyImmediate(gameObject);
		}
	}
}
