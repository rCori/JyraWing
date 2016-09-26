using UnityEngine;
using System.Collections;

public interface IPlayerWeapon {

	void UpdateAutoFire (float delta);
    bool CanAutoFire();
	void AutoFire(bool down);
	int WeaponLevel {
		get;
		set;
	}
	int NumBullets {
		get;
		set;
	}
	bool IsAutoFire {
		get;
	}

}
