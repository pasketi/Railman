using UnityEngine;
using System.Collections;

public class TimeFreeze : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.E)){
			if (Time.timeScale != 0) {
				Time.timeScale = 0;
			} else Time.timeScale = 1;
		}
	}
}
