using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	private bool isActive;

	// Use this for initialization
	void Start () {
		GetComponent<Rigidbody2D>().velocity = new Vector2 (0.0f, 0f);
		gameObject.transform.position = new Vector2(0,10f);
		isActive = false;

	}
	
	
	// Recycle the bullet when it hits the barrier
	public void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "Barrier") {
			GetComponent<Rigidbody2D>().velocity = new Vector2 (0.0f, 0.0f);
			gameObject.transform.position = new Vector2(0,10f);
			isActive = false;
		}
	}


	public bool GetIsActive(){
		return isActive;
	}


	public void Shoot(){
		isActive = true;
		GetComponent<Rigidbody2D>().velocity = new Vector2 (4.0f, 0f);
	}

	/// <summary>
	/// Public interface for getting rid of a bullet.
	/// </summary>
	public void BulletDestroy(){
		GetComponent<Rigidbody2D>().velocity = new Vector2 (0.0f, 0.0f);
		gameObject.transform.position = new Vector2(0,10f);
		isActive = false;
	}

}
