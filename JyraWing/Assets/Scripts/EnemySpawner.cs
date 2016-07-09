using UnityEngine;
using System.Collections;

public abstract class EnemySpawner : MonoBehaviour {

	void Update(){
		if (transform.position.x <= BarrierWall.RIGHT_X) {
			Spawn();
			Destroy (this.gameObject);
		}
	}

	public abstract void Spawn();

}
