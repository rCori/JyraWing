using UnityEngine;
using System.Collections;

public class EnemyBullet : MonoBehaviour, PauseableItem {
	
	private bool isActive;
	
	private Vector2 storedVel;
	private bool _paused;
	//This bullet can either be absorbed by a shield or it can't.

	public bool shieldable;

	private readonly float TIME_LIMIT = 7f;
	private float timer = 0f;

	private Animator animator;
	private SpriteRenderer renderer;
    private Rigidbody2D rigidyBody2D;

	// Use this for initialization
	void Start () {
		isActive = false;
		_paused = false;
		timer = 0f;
		animator = GetComponent<Animator> ();
		renderer = GetComponent<SpriteRenderer> ();
        rigidyBody2D = GetComponent<Rigidbody2D>();
		SetRendererEnabled (false);
		RegisterToList();
	}
	
	// Update is called once per frame
	void Update () {
		if (_paused) {
			return;
		}
		if (isActive) {
			timer += Time.deltaTime;
		}
		if (timer > TIME_LIMIT) {
			Recycle ();
		}
	}
	
	void OnTriggerEnter2D(Collider2D other){
		//Player has two collders so we need to check if we are hitting the trigger one.
		if (other.tag == "Player" && other.isTrigger) {
            if(shieldable) {
                StartCoroutine(StartDissapearAnimation());
            } else { 
			    Recycle ();
            }
		}
		if (other.tag == "Barrier") {
            Recycle();
		}
	}
	
	public bool GetIsActive(){
		return isActive;
	}
	
	
	public void Shoot(){
		isActive = true;
		rigidyBody2D.velocity = new Vector2 (-5.0f, 0f);
	}
	
	public void Shoot(Vector2 i_dir){
		isActive = true;
		rigidyBody2D.velocity = i_dir;
	}

	public bool GetIsShieldable(){
		return shieldable;
	}

	public void SetRendererEnabled(bool isEnabled){
		renderer.enabled = isEnabled;
	}

    IEnumerator StartDissapearAnimation() {
        animator.SetInteger("animState", 1);
        rigidyBody2D.velocity = new Vector2 (0.0f, 0.0f);
        yield return new WaitForSeconds(0.3f);
        Recycle();
        animator.SetInteger("animState", 0);
    }

	private void Recycle(){
		rigidyBody2D.velocity = new Vector2 (0.0f, 0.0f);
		gameObject.transform.position = new Vector2(0,10f);
		isActive = false;
		SetRendererEnabled(false);
		timer = 0.0f;
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
				animator.speed = 0f;
				storedVel = GetComponent<Rigidbody2D>().velocity;
				rigidyBody2D.velocity = new Vector2 (0.0f, 0.0f);
			}
			else{
				animator.speed = 1f;
				rigidyBody2D.velocity = storedVel;
			}
		}
	}
	
	public void RegisterToList()
	{
		//GameObject.Find ("GameController").GetComponent<GameControllerBehaviour>().GetGameController().RegisterPauseableItem(this);
		GameObject.Find ("PauseController").GetComponent<PauseControllerBehavior>().RegisterPauseableItem(this);
        _paused = GameObject.Find("PauseController").GetComponent<PauseControllerBehavior>().IsPaused;
	}
	
	public void RemoveFromList()
	{
		//GameObject.Find ("GameController").GetComponent<GameControllerBehaviour>().GetGameController().DelistPauseableItem(this);
		GameObject.Find ("PauseController").GetComponent<PauseControllerBehavior>().DelistPauseableItem(this);
	}
}
