using UnityEngine;
using System.Collections;

public interface IPlayerWeapon {

	bool UpdateAutoFire (float delta);
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
