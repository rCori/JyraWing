using UnityEngine;
using System.Collections;

public class PointAttraction : MonoBehaviour {

	private float strengthOfAttraction = 30.0f;

	void OnTriggerStay2D(Collider2D other) {
		if (other.tag == "Player") {
			Vector3 direction = other.transform.position - transform.position;
			direction.Normalize ();
			GetComponent<Rigidbody2D>().AddForce(strengthOfAttraction* direction);
		}
	}
}
