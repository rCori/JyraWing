using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class UIController : MonoBehaviour {

	//The UI canvas for drawin all of these UI elements
	public GameObject canvas;
	//Number of lives the player has
	private int lifeCount;
	//The level of speed the player is at
	private int speedCount;
	private GameObject gameOverMessage;
	private GameObject levelEndImage;
	private GameObject lifeText;
	// Player speed will be represented by multiple sprites in different states of opacity
	private List<GameObject> speedSpriteCollection;
	

	// Use this for initialization
	void Start () {
		//lifeSpriteCollection = new List<GameObject> ();
		lifeCount = 3;
		initLives (lifeCount);

		speedCount = 4;
		speedSpriteCollection = new List<GameObject> ();
		initSpeed ();
		UpdateAvailableSpeed (1);
		UpdateActivatedSpeed (1,1);

		levelEndImage = Resources.Load("UIObjects/LevelFinishedImage") as GameObject;
		levelEndImage = Instantiate (levelEndImage);
		levelEndImage.transform.SetParent (canvas.transform, false);

		gameOverMessage = Resources.Load("UIObjects/GameOverText") as GameObject;
		gameOverMessage = Instantiate (gameOverMessage);
		gameOverMessage.transform.SetParent(canvas.transform, false);
	}
	
	// Update is called once per frame
	void Update () {

	}

	private void initLives(int lives){
		lifeText = Resources.Load("UIObjects/LifeText") as GameObject;
		Text lifeMessageText = lifeText.GetComponent<Text>();
		lifeMessageText.text = "Lives: " + lifeCount;
		lifeText = Instantiate (lifeText);
		lifeText.transform.SetParent(canvas.transform, false);
		lifeText.GetComponent<RectTransform>().position = new Vector2(
			lifeText.GetComponent<RectTransform>().position.x, 
			lifeText.GetComponent<RectTransform>().position.y);
		//We need to set positions at some point
		//Add to the collection
		//lifeSpriteCollection.Add(lifeText);

	}

	/// <summary>
	/// Decrease the number of lives and deactivate a life on the HUD 
	/// </summary>
	/// <param name="i_curLife">The life to removed from HUD.</param>
	private void DecreaseLives(){
		lifeCount--;
		if(lifeCount >= 0)
		{
			Text lifeMessageText = lifeText.GetComponent<Text>();
			lifeMessageText.text = "Lives: " + lifeCount;
		}
	}


	/// <summary>
	/// Shows game over.
	/// </summary>
	public void ShowGameOver(){
		Text gameOverText = gameOverMessage.GetComponent<Text> ();
		gameOverText.text = "Game Over";
	}

	/// <summary>
	/// Updates the lives.
	/// </summary>
	public void UpdateLives(int i_lives){
		//Remove a life
		if (i_lives == lifeCount - 1) {
			DecreaseLives();
		}
	}

	public void ShowLevelComplete(){
		//Set the alpha to max, making it visible.
		Image levelEndImageComp = levelEndImage.GetComponent<Image> ();
		Color myColor = levelEndImageComp.color;
		myColor.a = 255;
		levelEndImageComp.color = myColor;
	}

	private void initSpeed(){
		for (int i = 0; i < speedCount; i++) {
			GameObject speedSprite = Resources.Load ("UIObjects/SpeedCounter") as GameObject;
			speedSprite = Instantiate(speedSprite);
			speedSprite.transform.SetParent(canvas.transform, false);
			speedSprite.transform.position = new Vector3(
				speedSprite.transform.position.x + i*30,
				speedSprite.transform.position.y,
				speedSprite.transform.position.z);
			speedSpriteCollection.Add (speedSprite);
		}
	}

	public void UpdateAvailableSpeed(int available){
		for(int i = 0; i< speedCount; i++){
			GameObject speedSprite = speedSpriteCollection[i];
			Image speedSpriteImage = speedSprite.GetComponent<Image>();
			Color color = new Color();
			color.r = speedSpriteImage.color.r;
			color.g = speedSpriteImage.color.g;
			color.b = speedSpriteImage.color.b;
			if(i < available){
				color.a = 0.5f;
			}
			else{
				color.a = 0.0f;
			}
			speedSpriteImage.color = color;
		}
	}

	public void UpdateActivatedSpeed(int available, int speedCap){
		for (int i = 0; i< speedCap; i++) {
			GameObject speedSprite = speedSpriteCollection [i];
			Image speedSpriteImage = speedSprite.GetComponent<Image> ();
			Color color = new Color();
			color.r = speedSpriteImage.color.r;
			color.g = speedSpriteImage.color.g;
			color.b = speedSpriteImage.color.b;
			if(i < available){
				color.a = 1.0f;
			}
			else{
				color.a = 0.5f;
			}
			speedSpriteImage.color = color;
		}
	}
}
