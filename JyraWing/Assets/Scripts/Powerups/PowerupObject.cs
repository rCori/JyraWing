using UnityEngine;
using System.Collections;

public class PowerupObject : MonoBehaviour {


	float moveTimer;
	float moveTimeLimit;
	Vector3 originalPos;
	Vector3 startPos;
	Vector3 destinationPos;

	ShuffleBag bag;
	int pickNum;

	void Start(){
		bag = new ShuffleBag (3);
		bag.Add (1, 1);
		bag.Add (2, 1);
		bag.Add (3, 1);
		pickNum = 0;
		//This will give us a time over imediatly
		moveTimer = 2f;
		moveTimeLimit = 1f;
		originalPos = transform.position;
	}

	// Update is called once per frame
	void Update () {
		//Once time is up pick a new movement pattern.
		if (moveTimer > moveTimeLimit) {
			PickMode ();
		}
		SlerpMovement (startPos, destinationPos); 
	}

	void SlerpMovement(Vector3 start, Vector3 end){
		float timerVal = moveTimer / moveTimeLimit;
		//We want to know the difference between the start and where slerp has gotten us now
		Vector3 diff = start - Vector3.Slerp (start, end, timerVal);
		//Subtract that difference from the original postiion to get a new position for the object.
		transform.position = originalPos - diff;
		moveTimer += Time.deltaTime;
	}

	/// <summary>
	/// Uses a shuffle bad to detemine the next movement
	/// pattern for 
	/// </summary>
	void PickMode(){
		//Pick a random movement pattern
		int result = bag.Next ();
		pickNum++;
		if (pickNum > 2) {
			bag.Add (1, 1);
			bag.Add (2, 1);
			bag.Add (3, 1);
			pickNum = 0;
		}
		//Once picked fill all the values for that pick
		//These values will be same every time
		originalPos = transform.position;
		moveTimer = 0f;
		switch (result) {
		case 1:
			startPos = new Vector3(1f,1f);
			destinationPos = new Vector3(-1f,1f);
			moveTimeLimit = 4.0f;
			break;
		case 2:
			startPos = new Vector3(2f,-1f);
			destinationPos = new Vector3(-3f,-1f);
			moveTimeLimit = 5.0f;
			break;
		case 3:
			startPos = new Vector3(0f,-1f);
			destinationPos = new Vector3(-1.5f,-0f);
			moveTimeLimit = 3.0f;
			break;
		}
	}
}
