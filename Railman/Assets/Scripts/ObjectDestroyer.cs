using UnityEngine;
using System.Collections;

public class ObjectDestroyer : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (gameObject.collider.enabled == false && Time.timeScale != 0){
			DestroyImmediate(gameObject);
		}
	}
}
