using UnityEngine;
using System.Collections;

public class BulletHoleManager : MonoBehaviour {

	LevelManager manager;

	// Use this for initialization
	void Start () {
		manager = (LevelManager) GameObject.Find("oLevelManager").GetComponent(typeof(LevelManager));
		if (manager.isTimeFreeze) gameObject.renderer.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (!manager.isTimeFreeze && gameObject.renderer.enabled == false) gameObject.renderer.enabled = true;
	}
}
