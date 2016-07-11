using UnityEngine;
using System.Collections;

public class AwardPoints : MonoBehaviour {

	public int PointValue = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == "Player") {
			ScoreController.AddToScore (PointValue);
			Destroy (gameObject);
		}
	}
}
