using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyAIReflectBulletSprayerA : EnemyBehavior
{
    public List<Vector2> locations;
    public List<float> times;

    public float fireRate = 2.0f;
    private float fireTimer;
    private int currentMovementStep;

    public float bulletSpeed = 0.5f;

    private Vector2[] fireDirections;

	void Awake() {
        EnemyDefaults();
        AudioClip explosionClip = Resources.Load("Audio/SFX/explosion2") as AudioClip;
        SetExplosionSfx(explosionClip);

        HasAnimations animationsOwned;
        animationsOwned = HasAnimations.Hit | HasAnimations.Destroy;

        SetAnimations(animationsOwned);
        SetHitAnimationName("reflectBulletSprayer_hit");

        currentMovementStep = 0;
        fireTimer = 0.0f;

        fireDirections = new Vector2[8];
        fireDirections[0] = new Vector2(1.0f, 0.0f).normalized * bulletSpeed;
        fireDirections[1] = new Vector2(0.5f, 0.5f).normalized * bulletSpeed;
        fireDirections[2] = new Vector2(0.0f, 1.0f).normalized * bulletSpeed;
        fireDirections[3] = new Vector2(-0.5f, 0.5f).normalized * bulletSpeed;
        fireDirections[4] = new Vector2(-1.0f, 0.0f).normalized * bulletSpeed;
        fireDirections[5] = new Vector2(-0.5f, -0.5f).normalized * bulletSpeed;
        fireDirections[6] = new Vector2(0.0f, -1.0f).normalized * bulletSpeed;
        fireDirections[7] = new Vector2(0.5f, -0.5f).normalized * bulletSpeed;

		LeftWallException = true;
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
        if(fireTimer > fireRate){
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
