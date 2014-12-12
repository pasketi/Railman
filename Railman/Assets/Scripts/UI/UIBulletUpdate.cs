using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIBulletUpdate : MonoBehaviour {

	LevelManager manager;
	Text UIText;
	
	// Use this for initialization
	void Start () {
		manager = (LevelManager) GameObject.Find("oLevelManager").GetComponent(typeof(LevelManager));
		UIText = gameObject.GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
		UIText.text = manager.getBulletsLeft().ToString();
	}
}
