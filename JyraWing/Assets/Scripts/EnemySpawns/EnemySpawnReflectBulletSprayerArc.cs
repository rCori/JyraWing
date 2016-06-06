using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemySpawnReflectBulletSprayerArc : EnemySpawner {

	public Vector2 enemyPosition;

	public int Health;

	/*
    public List<Vector2> initialVelocities;
	public List<Vector2> endVelocities;
    public List<float> times;
	*/
	public List<EnemyAIReflectBulletSprayerArc.MoveInstruction> moveInstructionList;

    public float fireRate;
    public float bulletSpeed;

    public override void Spawn ()
	{
		EnemyBulletPool bulletPool = GameObject.Find ("EnemyBulletPool").GetComponent<EnemyBulletPool> ();
		EnemyBulletPool shieldableBulletPool = GameObject.Find ("EnemyShieldableBulletPool").GetComponent<EnemyBulletPool> ();
		
		GameObject enemy = (GameObject) Resources.Load ("Enemies/Enemy_ReflectBulletSprayerArc");
		enemy.transform.position = enemyPosition;
		
		enemy.GetComponent<EnemyBehavior> ().bulletPool = bulletPool;
		enemy.GetComponent<EnemyBehavior> ().shieldableBulletPool= shieldableBulletPool;
		enemy.GetComponent<EnemyBehavior> ().LeftWallException = false;

		enemy = Instantiate (enemy);

        enemy.GetComponent<EnemyBehavior>().SetEnemyHealth(Health);
		enemy.GetComponent<EnemyAIReflectBulletSprayerArc>().MoveInstructionList = moveInstructionList;
		//enemy.GetComponent<EnemyAIReflectBulletSprayerArc>().endVelocities = endVelocities;
		//enemy.GetComponent<EnemyAIReflectBulletSprayerArc>().times = times;

		enemy.GetComponent<EnemyAIReflectBulletSprayerArc>().fireRate = fireRate;
		enemy.GetComponent<EnemyAIReflectBulletSprayerArc>().bulletSpeed = bulletSpeed;

    }
}
