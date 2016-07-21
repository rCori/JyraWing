using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour, PauseableItem {

	private bool isActive;

	private bool _paused;
	private Vector2 storedVel;
	private Animator animator;

	// Use this for initialization
	void Start () {
		GetComponent<Rigidbody2D>().velocity = new Vector2 (0f, 0f);
		gameObject.transform.position = new Vector2(0,10f);
		isActive = false;
		storedVel = new Vector2 (0f, 0f);
		_paused = false;
		RegisterToList();
		animator = GetComponent<Animator> ();

	}
		

	///<summary>
	///Recycle the bullet when it hits the barrier
	/// </summary>
	public void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "Barrier") {
			BulletDestroy ();
		}
	}

	public void BulletHit() {
		animator.SetInteger ("animState", 1);
		GetComponent<Rigidbody2D>().velocity = new Vector2 (0f, 0f);
	}

	/// <summary>
	/// Public interface. Determine if the bullet is active or avaialble for reuse now.
	/// </summary>
	/// <returns><c>true</c>, if isActive is true, <c>false</c> otherwise.</returns>
	public bool GetIsActive(){
		return isActive;
	}


	/// <summary>
	/// Shoot the player bullet at a predefined speed
	/// </summary>
	public void Shoot(){
		isActive = true;
		GetComponent<Rigidbody2D>().velocity = new Vector2 (10.0f, 0f);
	}

	/// <summary>
	/// Shoot the player bullet at an upward angle for the spreadshot.
	/// </summary>
	public void ShootUp(){
		isActive = true;
		GetComponent<Rigidbody2D>().velocity = new Vector2 (10.0f, -8f);
	}

	/// <summary>
	/// Shoot the player bullet at an downward angle for the spreadshot.
	/// </summary>
	public void ShootDown(){
		isActive = true;
		GetComponent<Rigidbody2D>().velocity = new Vector2 (10.0f, 8f);
	}

	/// <summary>
	/// Public interface for getting rid of a bullet and setting it inactive
	/// </summary>
	public void BulletDestroy(){
		GetComponent<Rigidbody2D>().velocity = new Vector2 (0.0f, 0.0f);
		gameObject.transform.position = new Vector2(0,10f);
		animator.SetInteger ("animState", 0);
		isActive = false;
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
			}
			else{
				GetComponent<Rigidbody2D>().velocity = storedVel;
			}
		}
	}
	
	public void RegisterToList()
	{
		GameObject.Find ("PauseController").GetComponent<PauseControllerBehavior>().RegisterPauseableItem(this);
	}
	
	public void RemoveFromList()
	{
		GameObject.Find ("GameController").GetComponent<PauseControllerBehavior>().DelistPauseableItem(this);
	}

}
