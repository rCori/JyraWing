using UnityEngine;
using System.Collections;

public interface IPlayerWeapon {

	bool UpdateAutoFire (float delta);
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
