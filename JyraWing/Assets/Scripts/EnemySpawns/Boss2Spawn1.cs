using UnityEngine;
using System.Collections;

public class Boss2Spawn1 : EnemySpawner {

	// Use this for initialization
	public override void Spawn(){
		Vector3 spawnPos = gameObject.transform.position;

		EnemyBulletPool bulletPool = GameObject.Find ("EnemyBulletPool").GetComponent<EnemyBulletPool>();
		EnemyBulletPool shieldableBulletPool = GameObject.Find("EnemyShieldableBulletPool").GetComponent<EnemyBulletPool>();

		GameObject bossBase = (GameObject) Resources.Load ("Enemies/Enemy_Boss2");
		bossBase.transform.position = new Vector3(spawnPos.x - 4f,
			spawnPos.y,
			spawnPos.z);


		EnemyBoss2Base bossBaseBehavior = bossBase.GetComponent<EnemyBoss2Base> ();
		bossBaseBehavior.TopTurretBehavior.GetComponent<EnemyBehavior> ().bulletPool = bulletPool;
		bossBaseBehavior.TopTurretBehavior.GetComponent<EnemyBehavior> ().shieldableBulletPool = shieldableBulletPool;
		bossBaseBehavior.TopTurretBehavior.GetComponent<EnemyBoss2Turret> ().trackingBulletSpeed = 1.5f;
		bossBaseBehavior.TopTurretBehavior.GetComponent<EnemyBoss2Turret> ().fanningBulletSpeed = 1.5f;

		bossBaseBehavior.MiddleTurretBehavior.GetComponent<EnemyBehavior> ().bulletPool = bulletPool;
		bossBaseBehavior.MiddleTurretBehavior.GetComponent<EnemyBehavior> ().shieldableBulletPool = shieldableBulletPool;
		bossBaseBehavior.MiddleTurretBehavior.GetComponent<EnemyBoss2Turret> ().trackingBulletSpeed = 1.5f;
		bossBaseBehavior.MiddleTurretBehavior.GetComponent<EnemyBoss2Turret> ().fanningBulletSpeed = 1.5f;

		bossBaseBehavior.BottomTurretBehavior.GetComponent<EnemyBehavior> ().bulletPool = bulletPool;
		bossBaseBehavior.BottomTurretBehavior.GetComponent<EnemyBehavior> ().shieldableBulletPool = shieldableBulletPool;
		bossBaseBehavior.BottomTurretBehavior.GetComponent<EnemyBoss2Turret> ().trackingBulletSpeed = 1.5f;
		bossBaseBehavior.BottomTurretBehavior.GetComponent<EnemyBoss2Turret> ().fanningBulletSpeed = 1.5f;


		bossBase = Instantiate (bossBase);
	}

}
