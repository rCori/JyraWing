using UnityEngine;
using System.Collections;

public class EnemyBullet : MonoBehaviour, PauseableItem {
	
	private bool isActive;
	
	private Vector2 storedVel;
	private bool _paused;
	//This bullet can either be absorbed by a shield or it can't.

	public bool shieldable;

	// Use this for initialization
	void Start () {
		isActive = false;
		_paused = false;
		RegisterToList();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnTriggerEnter2D(Collider2D other){
		//Player has two collders so we need to check if we are hitting the trigger one.
		if (other.tag == "Player" && other.isTrigger) {
			Player player = other.gameObject.GetComponent<Player>();
			//If the bullet is a shieldable one and the player has a shield
			//up, do not take damage but reset the bullet.
			if(!shieldable || !player.HasShield())
			{
				player.TakeDamage();
			}
			GetComponent<Rigidbody2D>().velocity = new Vector2 (0.0f, 0.0f);
			gameObject.transform.position = new Vector2(0,10f);
			isActive = false;
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

	public bool GetIsShieldable(){
		return shieldable;
	}

	
	/* Implementation of PauseableItem interface */
	public bool paused
	{
		get
		{
			return _paused;
		}
		
		set
		{
			_paused = value;
			if(_paused)
			{
				storedVel = GetComponent<Rigidbody2D>().velocity;
				GetComponent<Rigidbody2D>().velocity = new Vector2 (0.0f, 0.0f);
				//I am conciously chooosing to have the bullets continue to animate because I think it looks cool.
				//GetComponent<Animator>().speed = 0f;
			}
			else{
				GetComponent<Rigidbody2D>().velocity = storedVel;
				//GetComponent<Animator>().speed = 1f;
			}
		}
	}
	
	public void RegisterToList()
	{
		GameObject.Find ("GameController").GetComponent<GameController>().RegisterPause(this);
	}
	
	public void RemoveFromList()
	{
		GameObject.Find ("GameController").GetComponent<GameController>().DelistPause(this);
	}
}
