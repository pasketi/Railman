using UnityEngine;
using System.Collections;

public class WallpaperManager : MonoBehaviour {

	Vector2 scale;
	float x, y;
	
	// Use this for initialization
	void Start () {
		x = (float) gameObject.renderer.material.mainTexture.height / (float) gameObject.renderer.material.mainTexture.width;
		y = (float) gameObject.transform.localScale.z;
		scale = new Vector2 (x, y);
		gameObject.renderer.material.SetTextureScale("_MainTex", scale);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
