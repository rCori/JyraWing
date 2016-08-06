using UnityEngine;
using System.Collections;

public class EnemyBoss2Base : MonoBehaviour {

	public LevelControllerBehavior levelControllerBehavior;

	//Public game objects for the 3 turrets
	public GameObject TopTurretBehavior;
	public GameObject MiddleTurretBehavior;
	public GameObject BottomTurretBehavior;

	public delegate void OnSubSectionDestroy ();
	public OnSubSectionDestroy topTurretDestoryed;

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

		patternTimeLimit = 10.0f;
		patternTimer = 0.0f;

		createShuffleBag ();
		changePattern ();

		TopTurret.TurretDestoyedEvent += CheckAllTurretsAreDestroyed;
		MiddleTurret.TurretDestoyedEvent += CheckAllTurretsAreDestroyed;
		BottomTurret.TurretDestoyedEvent += CheckAllTurretsAreDestroyed;

	}
	
	// Update is called once per frame
	void Update () {
		patternTimer += Time.deltaTime;
		if (patternTimer > patternTimeLimit) {
			//Change fire pattern
			changePattern();
			//reset the timer
			patternTimer = 0.0f;
		}
	}

	public void SetTurrets(EnemyBoss2Turret TopTurret, EnemyBoss2Turret MiddleTurret, EnemyBoss2Turret BottomTurret) {
		this.TopTurret = TopTurret;
		this.MiddleTurret = MiddleTurret;
		this.BottomTurret = BottomTurret;
	}

	void createShuffleBag(){
		shuffleBagCounter = 0;
		bag = new ShuffleBag (3);
		bag.Add (0, 1);
		bag.Add (1, 1);
		bag.Add (2, 1);
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
	}
	public void CheckAllTurretsAreDestroyed(){
		if (TopTurret.GetIsDestroyed () && MiddleTurret.GetIsDestroyed () && BottomTurret.GetIsDestroyed ()) {
			//animator.SetInteger ("animState", 3);
			GameObject obj = GameObject.Find ("GameController");
			//The boss object could be destoryed on account of the level ending.
			//If that happens this object could be null so we check for that.
			if (obj) {
				//Use the new gameController now
				GameController controller = obj.GetComponent<GameControllerBehaviour>().GetGameController();
				levelControllerBehavior.HandleLevelFinished ();
			}
		}
	}
}
