using UnityEngine;
using System.Collections;

public class WallpaperManager : MonoBehaviour {

	Vector2 scale;
	float x, y;
	
	// Use this for initialization
	void Start () {
		y = (float) gameObject.transform.localScale.z;
		x = (float) gameObject.transform.localScale.x * 10;
		scale = new Vector2 (x, y);
		gameObject.renderer.material.SetTextureScale("_MainTex", scale);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
