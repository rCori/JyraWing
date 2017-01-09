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
        healthBar.value = 1;
	}
	
    public void InitEnemyInfo(EnemyBehavior enemy) {
        this.enemy = enemy;
        enemy.hitPointEvent += UpdateFillArea;
        enemy.destroyEvent += () => Destroy(gameObject);
    }

    public void UpdateFillArea(int hitPoints) {
        if(total == -1) {
            InitTotalBasedOnFirstHit(hitPoints);
        }
        float hitPointsFloat = hitPoints;
        float percentage = (hitPointsFloat / total);
        healthBar.value = percentage;
    }

    private void InitTotalBasedOnFirstHit(int hitPoints) {
        total = hitPoints + 1f;
    }

    void OnDestroy() {
        enemy.destroyEvent -= () => Destroy(gameObject);
        enemy.hitPointEvent -= UpdateFillArea;
    }
}
