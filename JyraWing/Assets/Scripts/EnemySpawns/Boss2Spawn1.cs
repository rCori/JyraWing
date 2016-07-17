using UnityEngine;
using System.Collections;

public class Boss2Spawn1 : EnemySpawner {

	// Use this for initialization
	public override void Spawn(){
		Vector3 spawnPos = gameObject.transform.position;

		LevelControllerBehavior levelControllerBehavior = GameObject.Find ("LevelController").GetComponent<LevelControllerBehavior> ();
		EnemyBulletPool bulletPool = GameObject.Find ("EnemyBulletPool").GetComponent<EnemyBulletPool>();
		EnemyBulletPool shieldableBulletPool = GameObject.Find("EnemyShieldableBulletPool").GetComponent<EnemyBulletPool>();

		GameObject bossBase = (GameObject) Resources.Load ("Enemies/BossEnemies/Enemy_Boss2");
		bossBase.transform.position = new Vector3(spawnPos.x - 2f,
			spawnPos.y,
			spawnPos.z);


		EnemyBoss2Base bossBaseBehavior = bossBase.GetComponent<EnemyBoss2Base> ();
		bossBaseBehavior.TopTurretBehavior.GetComponent<EnemyBehavior> ().bulletPool = bulletPool;
		bossBaseBehavior.TopTurretBehavior.GetComponent<EnemyBehavior> ().shieldableBulletPool = shieldableBulletPool;
		bossBaseBehavior.TopTurretBehavior.GetComponent<EnemyBoss2Turret> ().trackingBulletSpeed = 2.0f;
		bossBaseBehavior.TopTurretBehavior.GetComponent<EnemyBoss2Turret> ().fanningBulletSpeed = 2.0f;


		bossBaseBehavior.MiddleTurretBehavior.GetComponent<EnemyBehavior> ().bulletPool = bulletPool;
		bossBaseBehavior.MiddleTurretBehavior.GetComponent<EnemyBehavior> ().shieldableBulletPool = shieldableBulletPool;
		bossBaseBehavior.MiddleTurretBehavior.GetComponent<EnemyBoss2Turret> ().trackingBulletSpeed = 2.5f;
		bossBaseBehavior.MiddleTurretBehavior.GetComponent<EnemyBoss2Turret> ().fanningBulletSpeed = 2.5f;


		bossBaseBehavior.BottomTurretBehavior.GetComponent<EnemyBehavior> ().bulletPool = bulletPool;
		bossBaseBehavior.BottomTurretBehavior.GetComponent<EnemyBehavior> ().shieldableBulletPool = shieldableBulletPool;
		bossBaseBehavior.BottomTurretBehavior.GetComponent<EnemyBoss2Turret> ().trackingBulletSpeed = 2.0f;
		bossBaseBehavior.BottomTurretBehavior.GetComponent<EnemyBoss2Turret> ().fanningBulletSpeed = 2.0f;


		bossBase = Instantiate (bossBase);
		bossBaseBehavior = bossBase.GetComponent<EnemyBoss2Base> ();
		bossBaseBehavior.TopTurretBehavior.GetComponent<EnemyBehavior> ().SetEnemyHealth (20);
		bossBaseBehavior.MiddleTurretBehavior.GetComponent<EnemyBehavior> ().SetEnemyHealth (35);
		bossBaseBehavior.BottomTurretBehavior.GetComponent<EnemyBehavior> ().SetEnemyHealth (20);
		bossBaseBehavior.levelControllerBehavior = levelControllerBehavior;
	}

}
