using UnityEngine;
using System.Collections;

public class TileManager : MonoBehaviour {

	LevelManager manager;
	public float unitScale = 1;
	Vector2 scale;
	int tilesPerUnit;
	float x, y;

	// Use this for initialization
	void Start () {
		manager = (LevelManager) GameObject.Find("oLevelManager").GetComponent(typeof(LevelManager));
		tilesPerUnit = manager.tilesPerUnit;
		x = gameObject.transform.localScale.x * unitScale;
		y = gameObject.transform.localScale.z * unitScale;
		scale = new Vector2(tilesPerUnit * x, tilesPerUnit * y);
		gameObject.GetComponent<Renderer>().material.SetTextureScale("_MainTex", scale);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
