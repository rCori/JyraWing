using UnityEngine;
using System.Collections;

public class PlayerShield : MonoBehaviour {

	private bool shieldUp;
	//private float shieldTimeLimit;
	private float shieldTimer;

	// Use this for initialization
	void Start () {
		shieldUp = false;
		//shieldTimeLimit = 10f;
		shieldTimer = 0f;
	}
	
	// Update is called once per frame
	void Update () {
		//Update shield time.
		if (shieldUp) {
			shieldTimer += Time.deltaTime;
		}
	}

	public void ToggleShield(){
		if (shieldUp) {
			DeactivateShield();
		}
		else{
			ActivateShield();
		}
	}

	public void ActivateShield(){
		shieldUp = true;
		Color color = GetComponent<SpriteRenderer> ().color;
		color.a = 0.9f;
		GetComponent<SpriteRenderer> ().color = color;
	}

	public void DeactivateShield(){
		shieldUp = false;
		Color color = GetComponent<SpriteRenderer> ().color;
		color.a = 0.2f;
		GetComponent<SpriteRenderer> ().color = color;
	}

	public bool GetIsActive(){
		return shieldUp;
	}
	
}
