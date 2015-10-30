using UnityEngine;
using System.Collections;

public interface IBullet{

	// Bullets can be active or in a pool
	bool active {
		get;
		set;
	}

	void Shoot();

	void Shoot(Vector2 dir);
}
