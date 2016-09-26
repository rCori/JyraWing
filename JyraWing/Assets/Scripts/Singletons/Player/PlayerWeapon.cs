using UnityEngine;
using System.Collections;

public class PlayerWeapon : IPlayerWeapon {

	float autoFireTimer;
	const float AUTOFIRETIMELIMIT = 1/6f;



	public PlayerWeapon() {
		_weaponLevel = 1;
		_numBullets = 20;
		_isAutoFire = false;
		autoFireTimer = 1f;
	}

	private int _weaponLevel;
	public int WeaponLevel {
		get{
			return _weaponLevel;
		}
		set{
			value = _weaponLevel;
		}
	}

	private int _numBullets;
	public int NumBullets {
		get{
			return _numBullets;
		}
		set{
			value = _numBullets;
		}
	}

	private bool _isAutoFire;
	public bool IsAutoFire {
		get{
			return _isAutoFire;
		}
	}

	public void AutoFire(bool down) {
		_isAutoFire = down;
		//autoFireTimer = 1f;
	}

	public void UpdateAutoFire (float delta) {
		autoFireTimer += delta;

	}

    public bool CanAutoFire() {
        if (autoFireTimer > AUTOFIRETIMELIMIT && _isAutoFire) {
            autoFireTimer = 0f;
            return true;
        }
        return false;
    }
}
