using UnityEngine;
using System.Collections;

public class TimeFreeze : MonoBehaviour {

	LevelManager manager;

	// Use this for initialization
	void Start () {
		manager = (LevelManager) GameObject.Find("oLevelManager").GetComponent(typeof(LevelManager));
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.E)){
			manager.toggleTimeFreeze();
		}
	}
}
