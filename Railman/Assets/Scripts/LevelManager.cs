using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

	public int tilesPerUnit = 10;
	public bool isTimeFreeze, canTimeFreeze;
	public int weaponShots;
	private float freezeTime;
	public float freezeTimeLimit;
	private bool toggled;
	public AudioClip music;
	public AudioSource[] speaker;

	// Use this for initialization
	void Start () {
		toggled = false;
		isTimeFreeze = false;
		canTimeFreeze = true;
		freezeTime = 0f;
		for (int i = 0; i < speaker.Length;i++){
			speaker[i].clip = music;
			speaker[i].loop = true;
			speaker[i].playOnAwake = true;
			speaker[i].Play();
		}
	}

	public bool getToggled(){
		return toggled;
	}

	public int getBulletsLeft() {
		return weaponShots;
	}

	public void useBullet() {
		weaponShots--;
	}

	public float getTimeLeft() {
		return (float) (freezeTimeLimit-freezeTime);
	}

	public bool getTimeFreeze () {
		return isTimeFreeze;
	}

	public void toggleTimeFreeze() {
		if (!isTimeFreeze && canTimeFreeze) {
			isTimeFreeze = true;
			toggled = true;
		} else if (isTimeFreeze) {
			isTimeFreeze = false;
			toggled = true;
		}
	}

	public void setTimeFreeze(bool boolean){
		if (boolean == true && !isTimeFreeze && canTimeFreeze){
			if (isTimeFreeze != boolean){
				toggled = true;
			}
			isTimeFreeze = boolean;
		} else if (boolean == false && isTimeFreeze){
			if (isTimeFreeze != boolean){
				toggled = true;
			}
			isTimeFreeze = boolean;
		}
	}

	// Update is called once per frame
	void Update () {

		if (isTimeFreeze) {
			freezeTime += Time.deltaTime;
			for (int i = 0; i < speaker.Length; i++){
				if (speaker[i] != null){
					if (speaker[i].isPlaying && speaker[i] != null){ 
						speaker[i].Pause();
					}
				}
			}
		} else {
			for (int i = 0; i < speaker.Length; i++){
				if (speaker[i] != null){
					if (!speaker[i].isPlaying){ 
						speaker[i].Play();
					}
				}
			}
		}
		if (freezeTime >= freezeTimeLimit && isTimeFreeze){
			toggleTimeFreeze();
			canTimeFreeze = false;
			freezeTime = freezeTimeLimit;
			for (int i = 0; i < speaker.Length; i++){
				if (speaker[i] != null){
					if (!speaker[i].isPlaying){ 
						speaker[i].Play();
					}
				}
			}
		}
	}

	void LateUpdate () {
		if (toggled) toggled = false;
	}
}
