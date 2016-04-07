using UnityEngine;
using System.Collections;

public class EnemyBoss2Base : MonoBehaviour {

	//Public game objects for the 3 turrets
	public GameObject TopTurretBehavior;
	public GameObject MiddleTurretBehavior;
	public GameObject BottomTurretBehavior;

	//References from the GameObjects to the EnemyBoss2Turrey EnemyBehavior
	private EnemyBoss2Turret TopTurret;
	private EnemyBoss2Turret MiddleTurret;
	private EnemyBoss2Turret BottomTurret;

	//Timer on the changing on firing patterns
	private float patternTimer;

	private float patternTimeLimit;

	//Shuffle Bag to for selecting patterns
	ShuffleBag bag;

	//Counter for the shuffle bag
	int shuffleBagCounter;

	//The pattern we are currently on
	int pattern;

	// Use this for initialization
	void Start () {
		//Assign EnemyBoss2Turret refrences
		TopTurret = TopTurretBehavior.GetComponent<EnemyBoss2Turret> ();
		MiddleTurret = MiddleTurretBehavior.GetComponent<EnemyBoss2Turret> ();
		BottomTurret = BottomTurretBehavior.GetComponent<EnemyBoss2Turret> ();

		shuffleBagCounter = 0;

		pattern = 0;

		patternTimeLimit = 8.0f;
		patternTimer = 0.0f;
	}
	
	// Update is called once per frame
	void Update () {
		patternTimer += Time.deltaTime;
		if (patternTimer > patternTimeLimit) {
			//Change fire pattern
			changePattern();

			switch(pattern){
			case 0:
				if(TopTurret != null){
					TopTurret.Mode = EnemyBoss2Turret.Boss2TurretMode.TrackShield;
				}
				if(MiddleTurret != null){
					MiddleTurret.Mode = EnemyBoss2Turret.Boss2TurretMode.FanNormal;
				}
				if(BottomTurret != null){
					BottomTurret.Mode = EnemyBoss2Turret.Boss2TurretMode.TrackShield;
				}
				break;
			case 1:
				if(TopTurret != null){
					TopTurret.Mode = EnemyBoss2Turret.Boss2TurretMode.FanNormal;
				}
				if(MiddleTurret != null){
					MiddleTurret.Mode = EnemyBoss2Turret.Boss2TurretMode.TrackShield;
				}
				if(BottomTurret != null){
					BottomTurret.Mode = EnemyBoss2Turret.Boss2TurretMode.FanNormal;
				}
				break;
			case 2:
				if(TopTurret != null){
					TopTurret.Mode = EnemyBoss2Turret.Boss2TurretMode.TrackNormal;
				}
				if(MiddleTurret != null){
					MiddleTurret.Mode = EnemyBoss2Turret.Boss2TurretMode.FanShield;
				}
				if(BottomTurret != null){
					BottomTurret.Mode = EnemyBoss2Turret.Boss2TurretMode.TrackNormal;
				}
				break;
			}

			//reset the timer
			patternTimer = 0.0f;
		}


	}

	void createShuffleBag(){
		shuffleBagCounter = 0;
		bag = new ShuffleBag (4);
		//bag = new ShuffleBag (1);
		bag.Add (0, 1);
		bag.Add (1, 1);
		bag.Add (2, 1);
		//bag.Add (3, 1);
	}

	void changePattern(){
		//Increase the counter on the shuffle bag
		shuffleBagCounter++;
		//Refresh the shuffle bag if it has 
		if (shuffleBagCounter > 2) {
			createShuffleBag ();
		}
		int patternNum = bag.Next ();
		pattern = patternNum;
	}


	//Set the bullet pools of the two turrent bullet pools
	public void SetBulletPools(EnemyBulletPool bulletPool, EnemyBulletPool shieldBulletPool){

	}

	//Set the health of the individual turrents
	public void SetTurretHealth(int bottom, int middle, int top){
	}
}
