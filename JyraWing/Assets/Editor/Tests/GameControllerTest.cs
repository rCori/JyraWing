using System;
using NUnit.Framework;
using UnityEngine;

public class GameControllerTest {

	[Test]
	public void GameControllerIsValid(){
		GameController gameController = Resources.Load<GameObject> ("GameController").GetComponent<GameController>(); 
		//Player player = Resources.Load<GameObject> ("Player").GetComponent<Player>(); 
		//gameController.player = player;
		//player.gameController = gameController;
		//player.RegisterToList ();
		Assert.That (gameController != null);
	}

}
