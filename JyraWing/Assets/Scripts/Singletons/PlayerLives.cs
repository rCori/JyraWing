using UnityEngine;
using System.Collections;

public class PlayerLives {

    private static PlayerLives _instance;

    private int currentLives;

    private PlayerLives() {
        currentLives = SaveData.Instance.livesPerCredit;
    }

    public static PlayerLives Instance {
        get {
            if(_instance == null) {
                _instance = new PlayerLives();
            }
            return _instance;
        }
    }

    public void ResetLives() {
         currentLives = SaveData.Instance.livesPerCredit;
    }

    public int GetCurrentLives() {
         return currentLives;
    }

    public void DecreaseLives() {
        currentLives--;
    }
}
