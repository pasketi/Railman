using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class UIBulletUpdate : MonoBehaviour {

	LevelManager manager;
	Text UIText;
	public GameObject ammoIndicator;
	List<GameObject> ammo = new List<GameObject>();

	void addAmmo(GameObject indicator, int i){
		GameObject newAmmo = (GameObject) Instantiate (ammoIndicator);
		newAmmo.transform.SetParent(gameObject.transform, false);
		newAmmo.transform.position += Vector3.right * (i*16);
		ammo.Add(newAmmo);
	}

	// Use this for initialization
	void Start () {
		manager = (LevelManager) GameObject.Find("oLevelManager").GetComponent(typeof(LevelManager));
		UIText = gameObject.GetComponent<Text>();
		UIText.text = "";
	}
	
	// Update is called once per frame
	void Update () {
		//UIText.text = manager.getBulletsLeft().ToString();
		if (ammo.Count > manager.getBulletsLeft()) {
			DestroyImmediate(ammo[ammo.Count-1]);
			ammo.RemoveAt(ammo.Count-1);
		} else if (ammo.Count < manager.getBulletsLeft()) {
			addAmmo(ammoIndicator, ammo.Count);
		}
	}
}
