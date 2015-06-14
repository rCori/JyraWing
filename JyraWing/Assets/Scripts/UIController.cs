using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class UIController : MonoBehaviour {

	public Player player;
	private int lifeCount;
	public GameObject canvas;
	public Text gameOverMessage;
	public Image levelEndImage;
	/// <summary>
	/// Store a list of the player sprites so they can be
 	/// taken away and kept up with easily 
	/// </summary>
	private List<GameObject> lifeSpriteCollection;
	// Use this for initialization
	void Start () {
		lifeSpriteCollection = new List<GameObject> ();
		lifeCount = 3;
		InitLives (lifeCount);
	}
	
	// Update is called once per frame
	void Update () {
		//int lives = player.LifeCount();
		//UpdateLives (lives);
	}

	void InitLives(int lives){
		for (int i = 0; i < lives; i++) {
			GameObject lifeSprite = Resources.Load("PlayerLife") as GameObject;
			lifeSprite = Instantiate (lifeSprite);
			lifeSprite.transform.SetParent(canvas.transform, false);
			lifeSprite.GetComponent<RectTransform>().position = new Vector2(
				lifeSprite.GetComponent<RectTransform>().position.x + (i * 100), 
				lifeSprite.GetComponent<RectTransform>().position.y);
			//We need to set positions at some point
			//Add to the collection
			lifeSpriteCollection.Add(lifeSprite);
		}
	}

	/// <summary>
	/// Decrease the number of lives and deactivate a life on the HUD 
	/// </summary>
	/// <param name="i_curLife">The life to removed from HUD.</param>
	private void DecreaseLives(int i_curLife){
		lifeCount--;
		if(lifeCount >= 0)
		{
			lifeSpriteCollection[i_curLife].SetActive(false);
		}
	}


	/// <summary>
	/// Shows game over.
	/// </summary>
	public void ShowGameOver(){
		gameOverMessage.text = "Game Over";
	}

	/// <summary>
	/// Updates the lives.
	/// </summary>
	public void UpdateLives(int i_lives){
		//Remove a life
		if (i_lives == lifeCount - 1) {
			DecreaseLives(i_lives);
		}
	}

	public void ShowLevelComplete(){
		//Set the alpha to max, making it visible.
		Color myColor = levelEndImage.color;
		myColor.a = 255;
		levelEndImage.color = myColor;
	}

}
