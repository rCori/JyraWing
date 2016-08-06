using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ExplosionPool : MonoBehaviour {

	private List<GameObject> explosion1List = new List<GameObject> ();
	private List<GameObject> explosion2List = new List<GameObject> ();
	private Vector2 animLocation;
	// Use this for initialization
	void Start () { 
		for (int i = 0; i < 3; i++) {
			GameObject explosion1_1 = Resources.Load ("Effects/Explosion1") as GameObject;
			explosion1_1 = Instantiate (explosion1_1);
			explosion1_1.transform.SetParent (gameObject.transform);
			explosion1List.Add (explosion1_1);
		}
		for (int i = 0; i < 3; i++) {
			GameObject explosion2_1 = Resources.Load ("Effects/Explosion2") as GameObject;
			explosion2_1 = Instantiate (explosion2_1);
			explosion2_1.transform.SetParent (gameObject.transform);
			explosion2List.Add (explosion2_1);
		}
		animLocation = Vector2.zero;
	}

	public void SetXLoc(float x) {
		animLocation = new Vector2 (x, animLocation.y);
	}

	public void SetYLoc(float y) {
		animLocation = new Vector2 (animLocation.x, y);
	}

	public void PlayExplosion1() {
		foreach (GameObject explosionObj in explosion1List) {
			Effect explosion = explosionObj.GetComponent<Effect> ();
			if (!explosion.IsActive ()) {
				explosion.Play (animLocation);
				break;
			}
		}
	}

	public void PlayExplosion2() {
		foreach (GameObject explosionObj in explosion2List) {
			Effect explosion = explosionObj.GetComponent<Effect> ();
			if (!explosion.IsActive ()) {
				explosion.Play (animLocation);
				break;
			}
		}
	}
}
