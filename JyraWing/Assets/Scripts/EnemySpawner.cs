using UnityEngine;
using System.Collections;

public abstract class EnemySpawner : MonoBehaviour {


	void OnBecameVisible(){

		Spawn();
		Destroy (this.gameObject);
	}

	public abstract void Spawn();

}
