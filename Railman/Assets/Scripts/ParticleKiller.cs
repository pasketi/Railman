using UnityEngine;
using System.Collections;

public class ParticleKiller : MonoBehaviour {

	float birthTime, lifeTime;

	// Use this for initialization
	void Start () {
		birthTime = Time.time;
		lifeTime = gameObject.particleSystem.duration + gameObject.particleSystem.startLifetime;
	}
	
	// Update is called once per frame
	void Update () {
		if (birthTime + lifeTime <= Time.time){
			Debug.Log (gameObject + " " + (lifeTime + birthTime) + " - " + birthTime);
			Destroy(gameObject);
		}
	}
}
