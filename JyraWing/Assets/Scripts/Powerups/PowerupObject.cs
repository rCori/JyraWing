using UnityEngine;
using System.Collections;

public class PowerupObject : MonoBehaviour {


	float moveTimer;
	float moveTimeLimit;
	Vector3 startPos;
	Vector3 destinationPos;
	Vector3 velocityDir;

	ShuffleBag bag;
	int pickNum;

	float oneOverRootTwo;

	Vector3 lastPos;

	private AudioClip pickupSound;
	private SoundEffectPlayer sfxPlayer;

	void Start(){
		bag = new ShuffleBag (4);
		bag.Add (1, 1);
		bag.Add (2, 1);
		bag.Add (3, 1);
		bag.Add (4, 1);
		pickNum = 0;
		//This will give us a time over immediatly
		moveTimer = 2f;
		moveTimeLimit = 1f;
		oneOverRootTwo = (1.0f / Mathf.Sqrt (2.0f));
		startPos = new Vector3();
		lastPos = new Vector3();
		destinationPos = new Vector3();
		pickupSound = Resources.Load ("Audio/SFX/powerupGet1") as AudioClip;
		sfxPlayer = GameObject.Find ("SoundEffectPlayer").GetComponent<SoundEffectPlayer>();
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
		//Vector3 diff = start - Vector3.Slerp (start, end, timerVal);
		//Subtract that difference from the original postiion to get a new position for the object.
		//transform.position = originalPos - diff;

		//Get the velocity direction and normalize it
		velocityDir = Vector3.Slerp (start, end, timerVal) - lastPos;
		velocityDir.Normalize ();
		velocityDir.Set (velocityDir.x * 1.2f, velocityDir.y * 1.2f, velocityDir.z * 1.2f);
		GetComponent<Rigidbody2D>().velocity = velocityDir;
		lastPos = Vector3.Slerp (start, end, timerVal);
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
		if (pickNum > 3) {
			bag.Add (1, 1);
			bag.Add (2, 1);
			bag.Add (3, 1);
			bag.Add (4, 1);
			pickNum = 0;
		}
		//Once picked fill all the values for that pick
		//These values will be same every time
		moveTimer = 0f;
		switch (result) {
		case 1:
			startPos.Set(1f, 1f, 0f);
			lastPos.Set(1f, 1f, 0f);
			destinationPos.Set (-1f, 1f, 0f);
			moveTimeLimit = 4.0f;
			break;
		case 2:
			startPos.Set (1f, -1f, 0f);
			lastPos.Set (1f, -1f, 0f);
			destinationPos.Set(-1f,-1f, 0f);
			moveTimeLimit = 4.0f;
			break;
		case 3:
			startPos.Set (0f, -1f, 0f);
			lastPos.Set (0f, -1f, 0f);
			destinationPos.Set (-oneOverRootTwo, -oneOverRootTwo, 0f);
			moveTimeLimit = 4.0f;
			break;
		case 4:
			startPos.Set(0f, 1f, 0f);
			lastPos.Set (0f, 1f, 0f);
			destinationPos.Set (-oneOverRootTwo, oneOverRootTwo, 0f);
			moveTimeLimit = 4.0f;
			break;
		}

	}

	void OnDestroy(){
		sfxPlayer.PlayClip(pickupSound);
	}
}
