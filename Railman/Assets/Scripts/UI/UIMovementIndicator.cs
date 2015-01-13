using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIMovementIndicator : MonoBehaviour {

	CharacterController player;
	private Image img;
	public float maxShootSpeed = 5f;

	// Use this for initialization
	void Start () {
		player = (CharacterController) GameObject.Find("FirstPersonController").GetComponent(typeof(CharacterController));
		img = GetComponent<Image>();
	}
	
	// Update is called once per frame
	void Update () {
		if (player.velocity.magnitude >= maxShootSpeed) img.enabled = true;
		else img.enabled = false;
	}
}
