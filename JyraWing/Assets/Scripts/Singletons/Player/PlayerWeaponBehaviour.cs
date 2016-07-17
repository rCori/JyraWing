using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerWeaponBehaviour : MonoBehaviour, PauseableItem{

	IPlayerWeapon playerWeapon;

	private List<GameObject> bulletPool;
	private AudioSource fireSfx;

	public Player player;

	protected bool _paused;

	// Use this for initialization
	void Start () {
		PlayerInputController.FireButton += ShootBehavior;
		PlayerInputController.AutoFireButton += AutoFireBehaviour;
		playerWeapon = new PlayerWeapon ();
		//Bullet pool of player bullets.
		bulletPool = new List<GameObject> ();
		for (int i= 0; i < playerWeapon.NumBullets; i++) {
			//Put all the bullet live in the pool
			GameObject bullet = (GameObject)Resources.Load ("Bullet");
			bullet = Instantiate(bullet);
			bulletPool.Add(bullet);
		}
		fireSfx = gameObject.AddComponent<AudioSource> ();
		//Shot sound
		fireSfx.clip = Resources.Load ("Audio/SFX/shoot3") as AudioClip;
		_paused = false;
		RegisterToList ();
	}

	void Update() {
		if (playerWeapon.IsAutoFire) {
			bool autoFireShot = playerWeapon.UpdateAutoFire (Time.deltaTime);
			if (autoFireShot && !_paused) {
				ShootBehavior (true);
			}
		}
	}

	public void Shoot(){
		if (!_paused) {
			ShootBehavior (true);
		}
	}

	public void ShootBehavior(bool down) {
		if (down && !_paused && !player.IsPlayerTakingDamage()) {
			for (int i = 0; i < playerWeapon.NumBullets; i++) {
				GameObject bulletObj = bulletPool [i];
				Bullet bullet = bulletObj.GetComponent<Bullet> ();
				if (!bullet.GetIsActive ()) {
					bulletObj.transform.position = transform.position;
					bullet.Shoot ();
					fireSfx.Play ();
					return;
				}
			}
		}
	}

	public void AutoFireBehaviour(bool down) {
		playerWeapon.AutoFire (down);
	}

	/* Implementation of PauseableObject */
	public bool paused
	{
		get
		{
			return _paused;
		}

		set
		{
			_paused = value;
		}
	}

	public void RegisterToList()
	{
		if (GameObject.Find ("GameController")) {
			GameObject.Find ("GameController").GetComponent<GameControllerBehaviour>().GetGameController().RegisterPauseableItem(this);
		}
	}

	public void RemoveFromList()
	{
		if (GameObject.Find ("GameController")) {
			GameObject.Find ("GameController").GetComponent<GameControllerBehaviour>().GetGameController().DelistPauseableItem(this);
		}
	}

	void OnDestroy() {
		PlayerInputController.FireButton -= ShootBehavior;
		PlayerInputController.AutoFireButton -= AutoFireBehaviour;
	}
}
