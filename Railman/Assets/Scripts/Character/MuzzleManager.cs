using UnityEngine;
using System.Collections;

public class MuzzleManager : MonoBehaviour {

	LevelManager manager;
	Light flash;
	private float lifeTime = 0f;
	public float timeToLive = 0.2f, maxIntensity = 2f, maxScaleX = 0.8f, maxScaleY = 0.8f;

	// Use this for initialization
	void Start () {
		manager = (LevelManager) GameObject.Find("oLevelManager").GetComponent(typeof(LevelManager));
		flash = (Light) gameObject.GetComponentInChildren<Light>();
	}
	
	// Update is called once per frame
	void Update () {
		if (!manager.isTimeFreeze) {
			lifeTime += Time.deltaTime;
			float scale = ((timeToLive-lifeTime)/timeToLive);
			gameObject.transform.localScale = new Vector3(maxScaleX * scale, 
			                                              maxScaleY * scale, 
			                                              gameObject.transform.localScale.z);
			flash.intensity = maxIntensity*scale;
		}
		if (lifeTime >= timeToLive) {
			DestroyImmediate(gameObject);
		}
	}
}
