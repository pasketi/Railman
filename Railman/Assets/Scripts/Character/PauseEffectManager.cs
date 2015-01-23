using UnityEngine;
using System.Collections;

public class PauseEffectManager : MonoBehaviour {

	LevelManager manager;
	private Renderer[] children;
	
	// Use this for initialization
	void Start () {
		children = gameObject.GetComponentsInChildren<Renderer>();
		manager = (LevelManager) GameObject.Find("oLevelManager").GetComponent(typeof(LevelManager));
	}
	
	// Update is called once per frame
	void Update () {
		if (manager.isTimeFreeze) {
			foreach (Renderer shade in children) {
				if (shade.material.mainTexture != null){
					shade.material.mainTexture = (Texture) Resources.LoadAssetAtPath("Assets/Textures/" + manager.getLevelName() + "/BlackAndWhite/" + shade.material.mainTexture.name + ".png", typeof(Texture));
				}
			}
		} else {
			foreach (Renderer shade in children) {
				if (shade.material.mainTexture != null){
					shade.material.mainTexture = (Texture) Resources.LoadAssetAtPath("Assets/Textures/" + manager.getLevelName() + "/Normal/" + shade.material.mainTexture.name + ".png", typeof(Texture));
				}
			}
		}
	}
}
