using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyAIReflectBulletSprayerArc : EnemyBehavior
{

	[System.Serializable]
	public struct MoveInstruction {
		public EnemyBehavior.MovementStatus type;
		public Vector2 startVelocity;
		public Vector2 endVelocity;
		public float time;
	};

    private enum BulletPatterns{ 
        cardinal = 0,
        diagonal
    };
    private BulletPatterns bulletPattern;

	public List<MoveInstruction> MoveInstructionList;

    public float fireRate = 0.7f;
    private float fireTimer;
    private int currentMovementStep;

    public float bulletSpeed = 2.0f;

    private Vector2[] fireDirections;

	private int SPRAYER_HEALTH = 6;

	void Awake() {
        EnemyDefaults();
        AudioClip explosionClip = Resources.Load("Audio/SFX/enemyHit") as AudioClip;
        SetExplosionSfx(explosionClip);

        HasAnimations animationsOwned;
        animationsOwned = HasAnimations.Destroy;

        SetAnimations(animationsOwned);

        currentMovementStep = 0;
        fireTimer = 0.55f;

        fireDirections = new Vector2[8];
        fireDirections[0] = new Vector2(1.5f, 0.0f).normalized * bulletSpeed;
        fireDirections[1] = new Vector2(0.75f, 0.75f).normalized * bulletSpeed;
        fireDirections[2] = new Vector2(0.0f, 1.5f).normalized * bulletSpeed;
        fireDirections[3] = new Vector2(-0.75f, 0.75f).normalized * bulletSpeed;
        fireDirections[4] = new Vector2(-1.5f, 0.0f).normalized * bulletSpeed;
        fireDirections[5] = new Vector2(-0.75f, -0.75f).normalized * bulletSpeed;
        fireDirections[6] = new Vector2(0.0f, -1.5f).normalized * bulletSpeed;
        fireDirections[7] = new Vector2(0.75f, -0.75f).normalized * bulletSpeed;

		LeftWallException = true;
		SetEnemyHealth (SPRAYER_HEALTH);


		GivePointObject (0, 0.1f);
		GivePointObject (0, 0.1f);
    }

    // Update is called once per frame
    void Update()
    {
        if (_paused)
        {
            return;
        }
        Movement();
		if (GetIsTimeUp ()) {
	
			if(currentMovementStep < MoveInstructionList.Count) {
				if (MoveInstructionList [currentMovementStep].type == EnemyBehavior.MovementStatus.Velocity) {
					StartNewVelocity (MoveInstructionList [currentMovementStep].startVelocity, MoveInstructionList [currentMovementStep].time);
				} else if (MoveInstructionList [currentMovementStep].type == EnemyBehavior.MovementStatus.ArcVelocity) {
					StartArcVelocity (MoveInstructionList [currentMovementStep].startVelocity, MoveInstructionList [currentMovementStep].endVelocity, MoveInstructionList [currentMovementStep].time);
				} else if (MoveInstructionList [currentMovementStep].type == EnemyBehavior.MovementStatus.None) {
					StartStandStill (MoveInstructionList [currentMovementStep].time);
				} else if (MoveInstructionList [currentMovementStep].type == EnemyBehavior.MovementStatus.Lerp) {
					StartNewMovement (MoveInstructionList [currentMovementStep].startVelocity, MoveInstructionList [currentMovementStep].time);
				} else if (MoveInstructionList [currentMovementStep].type == EnemyBehavior.MovementStatus.Lerp) {
					StartNewSphericalMovement (MoveInstructionList [currentMovementStep].startVelocity, MoveInstructionList [currentMovementStep].time);
				}
				currentMovementStep++;
			} else {
                Destroy(gameObject);
            }
        }



        fireTimer += Time.deltaTime;
        if(fireTimer > fireRate){
            if (bulletPattern == BulletPatterns.cardinal) {
                Shoot(fireDirections[0], true);
                Shoot(fireDirections[2], true);
                Shoot(fireDirections[4], true);
                Shoot(fireDirections[6], true);
                bulletPattern = BulletPatterns.diagonal;
            } else if(bulletPattern == BulletPatterns.diagonal) {
                Shoot(fireDirections[1], true);
                Shoot(fireDirections[3], true);
                Shoot(fireDirections[5], true);
                Shoot(fireDirections[7], true);
                bulletPattern = BulletPatterns.cardinal;
            }
            fireTimer = 0.0f;
        }

        HandleHitAnimation();
    }
}
