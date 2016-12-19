using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EnemyHealthBar : MonoBehaviour {

    float total;
    private EnemyBehavior enemy;
    private Slider healthBar;

	// Use this for initialization
	void Start () {
        total = -1;
        healthBar = GetComponent<Slider>();
	}
	
    public void InitEnemyInfo(EnemyBehavior enemy) {
        this.enemy = enemy;
        enemy.hitPointEvent += UpdateFillArea;
    }

    public void UpdateFillArea(int hitPoints) {
        if(hitPoints == 0) {
            Destroy(gameObject);
        }
        if(total == -1) {
            InitTotalBasedOnFirstHit(hitPoints);
        }
        float hitPointsFloat = hitPoints;
        float percentage = (hitPointsFloat / total);
        Debug.Log("Health percentage is: " + percentage);
        healthBar.value = percentage;
        
    }

    private void InitTotalBasedOnFirstHit(int hitPoints) {
        total = hitPoints + 1f;
    }

    void OnDestroy() {
        enemy.hitPointEvent -= UpdateFillArea;
    }
}
