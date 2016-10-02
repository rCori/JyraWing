using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyAIDiamondArc : EnemyBehavior {

    [System.Serializable]
    public struct MoveInstruction {
        public EnemyBehavior.MovementStatus type;
        public Vector2 startVelocity;
        public Vector2 endVelocity;
        public float time;
    };

    public List<MoveInstruction> MoveInstructionList;

    private int currentMovementStep;

    // Use this for initialization
    void Awake () {
        EnemyDefaults();
        AudioClip explosionClip = Resources.Load("Audio/SFX/enemyHit") as AudioClip;
        SetExplosionSfx(explosionClip);

        HasAnimations animationsOwned;
        animationsOwned = HasAnimations.Destroy;

        SetAnimations(animationsOwned);

        GivePointObject(0, 0.0f);
    }

    void Update() {
        Movement();
        if (GetIsTimeUp()) {
            BeginNextMovementStep();
        }
    }

    private void BeginNextMovementStep() {
        if (currentMovementStep < MoveInstructionList.Count) {
            if (MoveInstructionList[currentMovementStep].type == EnemyBehavior.MovementStatus.Velocity) {
                StartNewVelocity(MoveInstructionList[currentMovementStep].startVelocity, MoveInstructionList[currentMovementStep].time);
            } else if (MoveInstructionList[currentMovementStep].type == EnemyBehavior.MovementStatus.ArcVelocity) {
                StartArcVelocity(MoveInstructionList[currentMovementStep].startVelocity, MoveInstructionList[currentMovementStep].endVelocity, MoveInstructionList[currentMovementStep].time);
            } else if (MoveInstructionList[currentMovementStep].type == EnemyBehavior.MovementStatus.None) {
                StartStandStill(MoveInstructionList[currentMovementStep].time);
            } else if (MoveInstructionList[currentMovementStep].type == EnemyBehavior.MovementStatus.Lerp) {
                StartNewMovement(MoveInstructionList[currentMovementStep].startVelocity, MoveInstructionList[currentMovementStep].time);
            } else if (MoveInstructionList[currentMovementStep].type == EnemyBehavior.MovementStatus.Slerp) {
                StartNewSphericalMovement(MoveInstructionList[currentMovementStep].startVelocity, MoveInstructionList[currentMovementStep].time);
            }
            currentMovementStep++;
        } else {
            Destroy(gameObject);
        }
    }
}
