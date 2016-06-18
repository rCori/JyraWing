using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerWeaponBehaviour : MonoBehaviour{

	IPlayerWeapon playerWeapon;

	private List<GameObject> bulletPool;
	private AudioSource fireSfx;

	// Use this for initialization
	void Start () {
		PlayerInputController.FireButton += ShootBehavior;
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
		fireSfx.clip = Resources.Load ("Audio/SFX/beep3") as AudioClip;
	}

	void Update() {
		if (playerWeapon.IsAutoFire) {
			bool autoFireShot = playerWeapon.UpdateAutoFire (Time.deltaTime);
			if (autoFireShot) {
				ShootBehavior (true);
			}
		}
	}

	public void Shoot(){
		ShootBehavior (true);
	}

	public void ShootBehavior(bool down) {
		if (down) {
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
}
