using UnityEngine;
using System.Collections;

public class AwardPoints : MonoBehaviour, PauseableItem {

	public int PointValue = 0;
	private AudioClip audioClip;
	private SoundEffectPlayer soundEffectPlayer;

	private Animator animator;
	private RuntimeAnimatorController point0Animation;
	private RuntimeAnimatorController point1Animation;
	private RuntimeAnimatorController point2Animation;
	private RuntimeAnimatorController point3Animation;

	private bool isActive;

	private bool _paused;

	public delegate void AwardPointsEvent();
	public event AwardPointsEvent ResetPosition, StartScrolling, EndScrolling;

	private PauseControllerBehavior pauseController;

	// Use this for initialization
	void Awake () {
		soundEffectPlayer = GameObject.Find ("SoundEffectPlayer").GetComponent<SoundEffectPlayer> ();
		audioClip = Resources.Load ("Audio/SFX/pointPickup") as AudioClip;
		animator = GetComponent<Animator> ();
		point0Animation = Resources.Load ("PointIconAnimations/PointIcon0/PointIcon0_0") as RuntimeAnimatorController;
		point1Animation = Resources.Load ("PointIconAnimations/PointIcon1/PointIcon1_0") as RuntimeAnimatorController;
		point2Animation = Resources.Load ("PointIconAnimations/PointIcon2/PointIcon2_0") as RuntimeAnimatorController;
		point3Animation = Resources.Load ("PointIconAnimations/PointIcon3/PointIcon3_0") as RuntimeAnimatorController;
		_paused = false;
		isActive = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == "Player") {
			ScoreController.AddToScore (PointValue);
			if (soundEffectPlayer && audioClip) {
				soundEffectPlayer.PlayClip (audioClip);
			}
			DestroyPoint ();
		}
	}

	//Set what kind of point 
	public void SetValue(int index) {
		switch (index) {
		case 0:
			animator.runtimeAnimatorController = point0Animation;
			PointValue = 10;
			break;
		case 1:
			animator.runtimeAnimatorController = point1Animation;
			PointValue = 20;
			break;
		case 2:
			animator.runtimeAnimatorController = point2Animation;
			PointValue = 50;
			break;
		case 3:
			animator.runtimeAnimatorController = point3Animation;
			PointValue = 100;
			break;
		}
	}

	public bool GetIsActive() {
		return isActive;
	}

	public void MakeActive(){
		isActive = true;
		if (StartScrolling != null) {
			StartScrolling ();
		}
	}

	public void DestroyPoint() {
		isActive = false;
		if (ResetPosition != null) {
			ResetPosition ();
		}
		if (EndScrolling != null) {
			EndScrolling ();
		}
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
				animator.speed = 0;
			}
			else{
				animator.speed = 1;
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

	void OnDestroy() {
		RemoveFromList ();
	}
}
