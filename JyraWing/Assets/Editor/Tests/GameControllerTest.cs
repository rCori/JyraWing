using System;
using NUnit.Framework;
using UnityEngine;

public class GameControllerTest {

	[Test]
	public void GameControllerIsValid(){
		GameController gameController = Resources.Load<GameObject> ("GameController").GetComponent<GameController>(); 
		Assert.That (gameController != null);
	}

	[Test]
	public void EnemyBehaviorIsMovingByLerp(){
		EnemyAI1 enemy = Resources.Load<GameObject> ("Enemy_A").GetComponent<EnemyAI1> ();
		GameObject.Instantiate (enemy);
		enemy.StartNewMovement (new Vector3 (0f, 0f, 0f), 1.0f);
		Assert.That (enemy.GetMovementStatus() == EnemyBehavior.MovementStatus.Velocity);
	}

	[Test]
	public void GameControllerPausesAllItems(){
		//Arrange
		GameControllerTestDouble gameControllerTestDouble = GameObject.Find ("GameController").GetComponent<GameControllerTestDouble> ();
		Player player = GameObject.Find("Player").GetComponent<Player> ();
		gameControllerTestDouble.player = player;
		player.gameController = gameControllerTestDouble;

		//Act
		player.RegisterToList();
		gameControllerTestDouble.PauseAllItems ();
		int totalItemsPaused = gameControllerTestDouble.GetTotalItemsPaused ();

		//Assert
		Assert.That (totalItemsPaused == 1);
	}

	[Test]
	public void GameControllerSpawnsPowerup(){
		//Arrange
		GameControllerTestDouble gameControllerTestDouble = GameObject.Find ("GameController").GetComponent<GameControllerTestDouble> ();

		//Act
		bool assertValue = true;
		int totalSquads = gameControllerTestDouble.GetTotalRegisteredSquads ();
		//Verify one squad is registered before all the enemies are destroyed
		if (totalSquads != 1) {
			assertValue = false;
		}

		//Destroy every enemy in the scene with a bullet
		foreach (var gameObj in GameObject.FindGameObjectsWithTag("Enemy")){
			Bullet bullet = Resources.Load<GameObject>("Bullet").GetComponent<Bullet>();
			Collider2D collider2D = bullet.gameObject.GetComponent<Collider2D>();
			gameObj.GetComponent<EnemyBehavior>().DefaultTrigger(collider2D);
			//GameObject.Destroy(bullet.gameObject);
		}

		//Verify one squad is registered before all the enemies are destroyed
		if (gameControllerTestDouble.GetTotalRegisteredSquads () != 0) {
			assertValue = false;
		}

		//Verify that a powerup was spawned
		if (gameControllerTestDouble.GetWasPowerupSpawned ()) {
			assertValue = false;
		}

		//Assert
		Assert.That (assertValue);
	}

}
