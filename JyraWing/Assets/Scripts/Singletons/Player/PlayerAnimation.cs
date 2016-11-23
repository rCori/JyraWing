using UnityEngine;
using System.Collections;
using System;

public class PlayerAnimation : MonoBehaviour {

    bool isHit, isBlinking, upHeld, downHeld;
    private Animator animator;
    // Use this for initialization
    

    void Start () {
        animator = gameObject.GetComponent<Animator>();
        PlayerInputController.UpDownEvent += UpdateUpDownAnimation;
        //PlayerInputController.UpButton += UpdateUpAnimation;
        //PlayerInputController.DownButton += UpdateDownAnimation;
        Player.HitEvent += HitAnimation;
        isHit = false;
        isBlinking = false;
        upHeld = false;
        downHeld = false;
        //CountdownTimer.PlayerContinueEvent += ResetHitAnimation;
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void UpdateUpDownAnimation(float value)
    {
        if (animator == null) return;

        int animState = (animator.GetInteger("animState"));
        if (isHit) {
            return;
        }
        if (isBlinking) {
            if (value == 0.0) {
                animState = 7;
            } else if (value == -1.0) {
                animState = 10;
            } else if (value == 1.0) {
                animState = 9;
            }

        } else {
            //If the player is not moving up or down.
            if (value == 0.0) {
                //If you are in down or transition to down, go to transition to neutral
                if ((animState == 3 || animState == 2) && animState != 1) {
                    animState = 1;
                }

                //If you are in down or transition to down, go to transition to neutral
                if ((animState == 5 || animState == 6) && animState != 4) {
                    animState = 4;
                }
            } else if (value == -1.0) {
                if (animState != 3 && animState != 2) {
                    animState = 3;
                }

            } else if (value == 1.0) {
                if (animState != 6 && animState != 5) {
                    animState = 6;
                }
            }
        }
        animator.SetInteger("animState", animState);
    }

    public void UpdateUpAnimation(bool down) {
        if (animator == null) return;

        int animState = (animator.GetInteger("animState"));
        if (isHit) {
            return;
        }
        if (isBlinking) {
            if(down) {
                 animState = 9;
            }
            else {
                animState = 7;
            }
        } else {
            if(down) {
                upHeld = true;
                if(downHeld) {
                    animState = 1;
                }
                else if (animState != 6 && animState != 5) {
                    animState = 6;
                }
            } else {
                upHeld = false;
                //If down is being held when up is release go back into down animation
                if(downHeld) {
                    animState = 3;
                }
                //If you are in down or transition to down, go to transition to neutral
                else if ((animState == 5 || animState == 6) && animState != 4) {
                    animState = 4;
                }
            } 
        }
        animator.SetInteger("animState", animState);
    }

     public void UpdateDownAnimation(bool down) {
        if (animator == null) return;

        int animState = (animator.GetInteger("animState"));
        if (isHit) {
            return;
        }
        if (isBlinking) {
            if(down) {
                animState = 10;
            } else {
                animState = 7;
            }
        } else {
            //If the player is not moving up or down.
            if (down) {
                downHeld = true;
                if(upHeld) {
                    animState = 4;
                }
                else if (animState != 3 && animState != 2) {
                    animState = 3;
                }
            } else {
                downHeld = false;
                //If up is being held when down is release go into up animation.
                if(upHeld) {
                    animState = 6;
                }
                 //If you are in down or transition to down, go to transition to neutral
                else if ((animState == 3 || animState == 2) && animState != 1) {
                    animState = 1;
                }

            } 
        }
        animator.SetInteger("animState", animState);
     }

    private void HitAnimation(Player.TakingDamage takingDamage)
    {
        switch (takingDamage)
        {
            case Player.TakingDamage.EXPLODE:
                isHit = true;
                animator.SetInteger("animState", 8);
                break;
            case Player.TakingDamage.RETURNING:
                animator.SetInteger("animState", 7);
                break;
            case Player.TakingDamage.BLINKING:
                isHit = false;
                isBlinking = true;
                animator.SetInteger("animState", 7);
                break;
            case Player.TakingDamage.NONE:
                isBlinking = false;
                animator.SetInteger("animState", 0);
                break;
            default:
                break;
        }
    }

    public void ResetHitAnimation()
    {
        animator.SetInteger("animState", 0);
    }

    public void TransitionToNeutralToUp()
    {
        if (isHit) {
            return;
        }
        animator.SetInteger("animState", 5);
    }

    public void TransitionToNeutralToDown()
    {
        if (isHit) {
            return;
        }
        animator.SetInteger("animState", 2);
    }

    public void TransitionToDirectionToNeutral()
    {
        animator.SetInteger("animState", 0);
    }

    void OnDestroy() {
        PlayerInputController.UpDownEvent -= UpdateUpDownAnimation;
        Player.HitEvent -= HitAnimation;
        //CountdownTimer.PlayerContinueEvent -= ResetHitAnimation;
    }
}
