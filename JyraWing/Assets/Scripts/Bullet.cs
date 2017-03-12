using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Bullet : MonoBehaviour, PauseableItem {

	private bool isActive;

	private bool _paused;
	private Vector2 storedVel;
	private Animator animator;
	private SpriteRenderer renderer;
    private Rigidbody2D rigidBody2D;
    private BoxCollider2D boxCollider2D;

	// Use this for initialization
	void Start () {
		GetComponent<Rigidbody2D>().velocity = new Vector2 (0f, 0f);
		gameObject.transform.position = new Vector2(0,10f);
		isActive = false;
		storedVel = new Vector2 (0f, 0f);
		_paused = false;
		RegisterToList();
		animator = GetComponent<Animator> ();
		renderer = GetComponent<SpriteRenderer> ();
        rigidBody2D = GetComponent<Rigidbody2D>();
        boxCollider2D = GetComponent<BoxCollider2D>();
		renderer.enabled = false;
        boxCollider2D.enabled = false;

        Player.TakeDamageEvent += Recycle;
	}
		

	public void BulletHit() {
		animator.SetInteger ("animState", 1);
		rigidBody2D.velocity = new Vector2 (0f, 0f);
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
		rigidBody2D.velocity = new Vector2 (10.0f, 0f);
        boxCollider2D.enabled = true;
		renderer.enabled = true;

	}

	/// <summary>
	/// Public interface for getting rid of a bullet and setting it inactive
	/// </summary>
	public void Recycle(){
		rigidBody2D.velocity = new Vector2 (0.0f, 0.0f);
		gameObject.transform.position = new Vector2(0,10f);
		animator.SetInteger ("animState", 0);
		isActive = false;
        boxCollider2D.enabled = false;
		renderer.enabled = false;
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
				storedVel = rigidBody2D.velocity;
				rigidBody2D.velocity = new Vector2 (0.0f, 0.0f);
				animator.speed = 0;
			}
			else{
				rigidBody2D.velocity = storedVel;
				animator.speed = 1;
			}
		}
	}
	
    void OnDestroy() {
        Player.TakeDamageEvent -= Recycle;
    }

	public void RegisterToList()
	{
		GameObject.Find ("PauseController").GetComponent<PauseControllerBehavior>().RegisterPauseableItem(this);
	}
	
	public void RemoveFromList()
	{
		GameObject.Find ("PauseController").GetComponent<PauseControllerBehavior>().DelistPauseableItem(this);
	}

}
