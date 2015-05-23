using UnityEngine;
using System.Collections;

public class BulletHoleManager : MonoBehaviour {

	LevelManager manager;

	// Use this for initialization
	void Start () {
		manager = (LevelManager) GameObject.Find("oLevelManager").GetComponent(typeof(LevelManager));
		if (manager.isTimeFreeze) gameObject.GetComponent<Renderer>().enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (!manager.isTimeFreeze && gameObject.GetComponent<Renderer>().enabled == false) gameObject.GetComponent<Renderer>().enabled = true;
	}
}
