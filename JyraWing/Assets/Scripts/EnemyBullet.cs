using UnityEngine;
using System.Collections;

public class EnemyBullet : MonoBehaviour {

	private bool isActive;

	// Use this for initialization
	void Start () {
		isActive = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other){
		//Player has two collders so we need to check if we are hitting the trigger one.
		if (other.tag == "Player" && other.isTrigger) {
			Player player = other.gameObject.GetComponent<Player>();
			player.TakeDamage();
			GetComponent<Rigidbody2D>().velocity = new Vector2 (0.0f, 0.0f);
			gameObject.transform.position = new Vector2(0,10f);
		}
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
		GetComponent<Rigidbody2D>().velocity = new Vector2 (-5.0f, 0f);

	}

	public void Shoot(Vector2 i_dir){
		isActive = true;
		GetComponent<Rigidbody2D> ().velocity = i_dir;
	}
}
