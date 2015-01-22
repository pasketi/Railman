using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UITimeUpdate : MonoBehaviour {

	LevelManager manager;
	Text UIText;
	
	// Use this for initialization
	void Start () {
		manager = (LevelManager) GameObject.Find("oLevelManager").GetComponent(typeof(LevelManager));
		UIText = gameObject.GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
		UIText.text = manager.getTimeLeft().ToString("0.00");
	}
}
