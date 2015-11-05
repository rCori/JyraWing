using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public interface IUIController {


	//The available speed levels to the player
	int availableSpeed {
		get;
		set;
	}

	//The current speed level of the player
	int activatedSpeed {
		get;
		set;
	}

	//The message that the life text UI object will display
	string lifeTestString {
		get;
		set;
	}

	//The ui objects that indicate the player's speed
	List<GameObject> speedSpriteUIObjects {
		get;
		set;
	}

	//The ui object that displays how many lives the player has remaining
	GameObject lifeTextUIObject {
		get;
		set;
	}

	//The ui object that displays when the player has died
	GameObject gameOverUIObject {
		get;
		set;
	}

	//The ui object that displays when the player has finished the level
	GameObject levelCompleteUIObject {
		get;
		set;
	}

	//The game object wthat creates the in game pause menu when
	//instantiated
	GameObject inGamePauseUIObject {
		get;
		set;
	}
	
}
