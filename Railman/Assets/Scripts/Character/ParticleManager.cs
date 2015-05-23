using UnityEngine;
using System.Collections;

public class ParticleManager : MonoBehaviour {

	LevelManager manager;
	float birthTime, lifeTime, runTime;
	bool started = false;

	// Use this for initialization
	void Start () {
		manager = (LevelManager) GameObject.Find("oLevelManager").GetComponent(typeof(LevelManager));
		lifeTime = gameObject.GetComponent<ParticleSystem>().duration + gameObject.GetComponent<ParticleSystem>().startLifetime;
		runTime = 0f;
		gameObject.GetComponent<ParticleSystem>().Pause();
	}
	
	// Update is called once per frame
	void Update () {
		//initiate effect when time runs
		if (!manager.getTimeFreeze() && !started) {
			started = true;
			gameObject.GetComponent<ParticleSystem>().Play();
		}

		//When running, increment runtime
		if (!manager.getTimeFreeze()) {
			runTime += Time.deltaTime;
		}

		//Pause if time frozen 
		if (manager.getTimeFreeze() && started) {
			gameObject.GetComponent<ParticleSystem>().Pause();
		}

		//Destroy when done
		if (lifeTime <= runTime){
			DestroyImmediate(gameObject);
		}
	}
}
