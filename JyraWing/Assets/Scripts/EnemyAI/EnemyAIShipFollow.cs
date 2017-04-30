using UnityEngine;
using System.Collections;

public class EnemyAIShipFollow : EnemyBehavior
{

    private int FOLLOW_SHIP_HEALTH = 3;

    //Starting at 12o'clock and moving counter clockwise
    private Vector2[] directions;

    private float SPEED = 3.5f;
    private float FIRE_RATE = 0.8f;
    private float firingTimer;

    void Awake()
    {
        EnemyDefaults();
        AudioClip explosionClip = Resources.Load("Audio/SFX/enemyHit") as AudioClip;
        SetExplosionSfx(explosionClip);
        //This enemy is not destoryed by touching the left wall.
        LeftWallException = true;

        HasAnimations animationsOwned;
        animationsOwned =  HasAnimations.Destroy;

        animator = gameObject.GetComponent<Animator>();

        SetAnimations(animationsOwned);

        SetEnemyHealth(FOLLOW_SHIP_HEALTH);

        GivePointObject(1, 0.0f);

        firingTimer = 0f;

        initializeDirections();
        determineDirection(gameController.playerPosition);

        for(int i = 0; i<6; i++) {
            GivePointObject(0, 0.2f);
        }

    }

    // Update is called once per frame
    void Update () {
        if (isDestroyed || _paused)
        {
            return;
        }
        Movement();
        firingTimer += Time.deltaTime;
        if(firingTimer > FIRE_RATE) {
            determineDirection(gameController.playerPosition);
            firingTimer = 0f;
        }
    }

    private void determineDirection(Vector2 playLocation){
        Vector2 curPos = (gameObject.transform.position);
        Vector2 distance =  playLocation - curPos;

        float xyratio = distance.x / distance.y;

        //If the enemy is lined up horizontally with the player
        if (distance.x < 1.5f && distance.x > -1.5f)
        {
            //Enemy is above the player
            if (distance.y >= 0f)
            {
                StartNewVelocity(directions[0], FIRE_RATE);
                animator.SetInteger("animState", 0);
                Shoot(directions[0] * 1.5f);
            }
            //Enemy is below the player
            else
            {
                StartNewVelocity(directions[4], FIRE_RATE);
                animator.SetInteger("animState", 4);
                Shoot(directions[4] * 1.5f);
            }
        }
        //Is x positive above 1. If the enemy is to the right of the player
        else if (distance.x >= 1f)
        {
            //If the enemy is much farther to the right than it is up or down
            if (xyratio >= 2f || xyratio <= -2f)
            {
                StartNewVelocity(directions[2], FIRE_RATE);
                animator.SetInteger("animState", 20);
                Shoot(directions[2] * 1.5f);
            }
            //If the enemy is to the top right of the player
            else if (xyratio <= 2f && xyratio > 0f)
            {
                StartNewVelocity(directions[1], FIRE_RATE);
                animator.SetInteger("animState", 1);
                Shoot(directions[1] * 1.5f);
            }
            //If the enemy is to the bottom right of the player
            else if (xyratio >= -2f && xyratio < 0f)
            {
                StartNewVelocity(directions[3], FIRE_RATE);
                animator.SetInteger("animState", 3);
                Shoot(directions[3] * 1.5f);
            }
            else
            {
                Debug.Log("issue with movement direction");
            }
        }
        //The enemy is to the left of the player
        else
        {
            //If the enemy is much farther to the left than it is up or down
            if (xyratio >= 2f || xyratio <= -2f)
            {
                StartNewVelocity(directions[6], FIRE_RATE);
                animator.SetInteger("animState", 6);
                Shoot(directions[6] * 1.5f);
            }
            //If the enemy is to the left left of the player
            else if (xyratio <= 2f && xyratio > 0f)
            {
                StartNewVelocity(directions[5], FIRE_RATE);
                animator.SetInteger("animState", 5);
                Shoot(directions[5]*1.5f);
            }
            //If the enemy is to the top left of the player
            else if (xyratio >= -2f && xyratio < 0f)
            {
                StartNewVelocity(directions[7], FIRE_RATE);
                Shoot(directions[7]*1.5f);
                animator.SetInteger("animState", 7);
            }
            else
            {
                Debug.Log("issue with movement direction");
            }
        }


    }

    private void initializeDirections()
    {
        directions = new Vector2[8];
        directions[0] = new Vector2(0f, 2f);
        directions[1] = new Vector2(1.5f, 1.5f);
        directions[2] = new Vector2(2f, 0f);
        directions[3] = new Vector2(1.5f, -1.5f);
        directions[4] = new Vector2(0f, -2f);
        directions[5] = new Vector2(-1.5f, -1.5f);
        directions[6] = new Vector2(-2f, 0f);
        directions[7] = new Vector2(-1.5f, 1.5f);
    }

}
