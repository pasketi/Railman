﻿using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

	public bool isTimeFreeze, canTimeFreeze;
	public int weaponShots;
	private float freezeTime;
	public float freezeTimeLimit;
	private bool toggled, tLastFrame;

	// Use this for initialization
	void Start () {
		toggled = false;
		tLastFrame = false;
		isTimeFreeze = false;
		canTimeFreeze = true;
		freezeTime = 0f;
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
			tLastFrame = true;
		} else if (isTimeFreeze) {
			isTimeFreeze = false;
			toggled = true;
			tLastFrame = true;
		}
	}

	public void setTimeFreeze(bool boolean){
		if (boolean && !isTimeFreeze && canTimeFreeze){
			isTimeFreeze = boolean;
		} else if (!boolean && isTimeFreeze){
			isTimeFreeze = boolean;
		}
	}

	// Update is called once per frame
	void Update () {

		if (tLastFrame && toggled) tLastFrame = false;
		else if (toggled && !tLastFrame) toggled = false;

		if (isTimeFreeze) {
			freezeTime += Time.deltaTime;
		}
		if (freezeTime >= freezeTimeLimit){
			isTimeFreeze = false;
			canTimeFreeze = false;
			freezeTime = freezeTimeLimit;
			tLastFrame = true;
			toggled = true;
		}
	}
}
