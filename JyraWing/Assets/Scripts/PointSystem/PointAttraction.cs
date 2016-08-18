using UnityEngine;
using System.Collections;

public class PointAttraction : MonoBehaviour, PauseableItem {

	private float strengthOfAttraction = 5.0f;

	private Collider2D playerCollider;
	private bool startAttraction;
	private Rigidbody2D pointRigidBody;
	private bool _paused;
	private Vector2 storedVel;

	private PauseControllerBehavior pauseController;
	private AwardPoints awardPointsBehavior;

	private Scroll scrollComponent;

	void Awake() {
		startAttraction = false;
		playerCollider = null;
		pointRigidBody = GetComponent<Rigidbody2D> ();
		scrollComponent = GetComponent<Scroll> ();
		_paused = false;
		storedVel = Vector2.zero;
		pauseController = GameObject.Find ("PauseController").GetComponent<PauseControllerBehavior> ();
		GameObject pointAttractionObject = transform.GetChild (0).gameObject;
		awardPointsBehavior = pointAttractionObject.GetComponent<AwardPoints> ();
		awardPointsBehavior.ResetPosition += ResetPosition;
		awardPointsBehavior.StartScrolling += () => {scrollComponent.speed = 1;};
		awardPointsBehavior.EndScrolling += () => {scrollComponent.speed = 0;};
		scrollComponent.speed = 0;
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == "Player") {
			startAttraction = true;
			playerCollider = other;
			Vector3 direction = other.transform.position - transform.position;
			direction.Normalize ();
			pointRigidBody.velocity = (strengthOfAttraction * direction);
		}
	}

	void Update() {
		if (_paused) return;
		if (startAttraction && playerCollider != null) {
			Vector3 direction = playerCollider.transform.position - transform.position;
			direction.Normalize ();
			pointRigidBody.velocity = (strengthOfAttraction * direction);
		}
	}


	public void ResetPosition() {
		startAttraction = false;
		gameObject.transform.position = new Vector2 (0f, 10f);
		pointRigidBody.velocity = Vector2.zero;
		storedVel = Vector2.zero;
	}

	void OnDestroy() {
		RemoveFromList ();
		awardPointsBehavior.ResetPosition -= ResetPosition;
		awardPointsBehavior.StartScrolling -= () => {scrollComponent.speed = 1;};
		awardPointsBehavior.EndScrolling -= () => {scrollComponent.speed = 0;};
	}

	public void SetPauseController(PauseControllerBehavior pauseController) {
		this.pauseController = pauseController;
		RegisterToList ();
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
				storedVel = pointRigidBody.velocity;
				pointRigidBody.velocity = Vector2.zero;
			}
			else{
				pointRigidBody.velocity = storedVel;
			}
		}
	}

	public void RegisterToList()
	{
		if (pauseController != null) {
			pauseController.RegisterPauseableItem (this);
		}
	}

	public void RemoveFromList()
	{
		if (pauseController != null) {
			pauseController.DelistPauseableItem (this);
		}
	}
}
