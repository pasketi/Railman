using UnityEngine;
using System.Collections;

public class WeaponSoundEmitter : MonoBehaviour {

	LevelManager manager;
	public AudioClip sound;
	public float setPitch;
	AudioSource emitter;
	float playTime = 0f, duration;
	bool played = false;

	// Use this for initialization
	void Start () {
		manager = (LevelManager) GameObject.Find("oLevelManager").GetComponent(typeof(LevelManager));
		emitter = GetComponent<AudioSource>();
		emitter.pitch = setPitch;
		duration = sound.length / emitter.pitch;
		emitter.clip = sound;
	}
	
	// Update is called once per frame
	void Update () {
		if (!manager.getTimeFreeze()){
			if (played == false) {
				emitter.Play();
				playTime = Time.time;
				played = true;
			}
			if (playTime+duration <= Time.time){
				played = true;
				Destroy (gameObject);
			}
		}
	}
}
