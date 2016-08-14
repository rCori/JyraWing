using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyAIReflectBulletSprayerA : EnemyBehavior
{
    public List<Vector2> locations;
    public List<float> times;

    private float fireTimer;
    private int currentMovementStep;

	private float FIRE_RATE = 1.0f;
    private float BULLET_SPEED = 1.5f;
	private int SPRAYER_HEALTH = 4;


    private Vector2[] fireDirections;

	void Awake() {
        EnemyDefaults();
        AudioClip explosionClip = Resources.Load("Audio/SFX/enemyHit") as AudioClip;
        SetExplosionSfx(explosionClip);

        HasAnimations animationsOwned;
        animationsOwned = HasAnimations.Destroy;

        SetAnimations(animationsOwned);

        currentMovementStep = 0;
        fireTimer = 0.8f;

        fireDirections = new Vector2[8];
		fireDirections[0] = new Vector2(1.0f, 0.0f).normalized * BULLET_SPEED;
		fireDirections[1] = new Vector2(0.5f, 0.5f).normalized * BULLET_SPEED;
		fireDirections[2] = new Vector2(0.0f, 1.0f).normalized * BULLET_SPEED;
		fireDirections[3] = new Vector2(-0.5f, 0.5f).normalized * BULLET_SPEED;
		fireDirections[4] = new Vector2(-1.0f, 0.0f).normalized * BULLET_SPEED;
		fireDirections[5] = new Vector2(-0.5f, -0.5f).normalized * BULLET_SPEED;
		fireDirections[6] = new Vector2(0.0f, -1.0f).normalized * BULLET_SPEED;
		fireDirections[7] = new Vector2(0.5f, -0.5f).normalized * BULLET_SPEED;

		LeftWallException = true;
		SetEnemyHealth (SPRAYER_HEALTH);
    }

    // Update is called once per frame
    void Update()
    {
        if (_paused)
        {
            return;
        }
        Movement();
        if (GetIsTimeUp()){
            if (currentMovementStep < locations.Count){
                StartNewMovement(locations[currentMovementStep], times[currentMovementStep]);
                currentMovementStep++;
            } else {
                Destroy(gameObject);
            }
        }



        fireTimer += Time.deltaTime;
		if(fireTimer > FIRE_RATE){
            Shoot(fireDirections[0], true);
            Shoot(fireDirections[1], true);
            Shoot(fireDirections[2], true);
            Shoot(fireDirections[3], true);
            Shoot(fireDirections[4], true);
            Shoot(fireDirections[5], true);
            Shoot(fireDirections[6], true);
            Shoot(fireDirections[7], true);
            fireTimer = 0.0f;
        }

        HandleHitAnimation();
    }
}
