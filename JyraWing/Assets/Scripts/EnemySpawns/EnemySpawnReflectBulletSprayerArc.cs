using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemySpawnReflectBulletSprayerArc : EnemySpawner {

	public Vector2 enemyPosition;

	public List<EnemyAIReflectBulletSprayerArc.MoveInstruction> moveInstructionList;


    public override void Spawn ()
	{
		EnemyBulletPool bulletPool = GameObject.Find ("EnemyBulletPool").GetComponent<EnemyBulletPool> ();
		EnemyBulletPool shieldableBulletPool = GameObject.Find ("EnemyShieldableBulletPool").GetComponent<EnemyBulletPool> ();
		
		GameObject enemy = (GameObject) Resources.Load ("Enemies/ReflectorEnemies/Enemy_ReflectBulletSprayerArc");;
		enemy.transform.position = enemyPosition;
		
		enemy.GetComponent<EnemyBehavior> ().bulletPool = bulletPool;
		enemy.GetComponent<EnemyBehavior> ().shieldableBulletPool= shieldableBulletPool;
		enemy.GetComponent<EnemyBehavior> ().LeftWallException = false;

		enemy = Instantiate (enemy);

		enemy.GetComponent<EnemyAIReflectBulletSprayerArc>().MoveInstructionList = moveInstructionList;
    }
}
