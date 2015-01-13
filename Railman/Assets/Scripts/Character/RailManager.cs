using UnityEngine;
using System.Collections;

public class RailManager : MonoBehaviour {

	LevelManager manager;
	public float lifeTime = 0.2f, width = 0.5f;
	private float lived = 0f;
	private LineRenderer line;

	// Use this for initialization
	void Start () {
		manager = (LevelManager) GameObject.Find("oLevelManager").GetComponent(typeof(LevelManager));
		line = gameObject.GetComponent<LineRenderer>();
	}
	
	// Update is called once per frame
	void Update () {

		if (lived == 0 && manager.isTimeFreeze) line.SetWidth(0,0);
		else line.SetWidth(width, width);

		if (lived < lifeTime && !manager.isTimeFreeze) {
			line.SetColors(new Color(1f,1f,1f,(lifeTime-lived)/lifeTime), new Color(1f,1f,1f,(lifeTime-lived)/lifeTime));
			lived += Time.deltaTime;
		}
		else if (lived >= lifeTime) {
			DestroyImmediate(gameObject);
		}
	}
}
