using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class UIController : MonoBehaviour {

	//const bool ISDEBUG = false;

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

	//private IngameMenu pauseMenu;

	//ISDEBUG
	private GameObject debugFramerate;
	private float deltaTime;

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

		gameOverMessage = Resources.Load("UIObjects/GameOverImage") as GameObject;
		gameOverMessage = Instantiate (gameOverMessage);
		gameOverMessage.transform.SetParent(canvas.transform, false);

//		if (ISDEBUG) {
//			debugFramerate = Resources.Load("UIObjects/DEBUGFramerateText") as GameObject;
//			debugFramerate = Instantiate (debugFramerate);
//			debugFramerate.transform.SetParent(canvas.transform, false);
//			deltaTime = 0.0f;
//		}
	}
	
	// Update is called once per frame
	void Update () {
		//If in debug mode show fps
//		if (ISDEBUG) {
//			deltaTime  += (Time.deltaTime - deltaTime) * 0.1f;
//			Text debugFramerateText = debugFramerate.GetComponent<Text> ();
//			float fps = 1.0f / deltaTime;
//			debugFramerateText.text = "framerate: " + fps.ToString();
//		}
	}

	/// <summary>
	/// Create the life counter in the top left.
	/// </summary>
	/// <param name="lives">Lives.</param>
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
		Image gameOverMessageComp = gameOverMessage.GetComponent<Image> ();
		Color myColor = gameOverMessageComp.color;
		myColor.a = 255;
		gameOverMessageComp.color = myColor;
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

	/// <summary>
	/// Shows the level complete graphic.
	/// </summary>
	public void ShowLevelComplete(){
		//Set the alpha to max, making it visible.
		if (lifeCount != 0) {
			Image levelEndImageComp = levelEndImage.GetComponent<Image> ();
			Color myColor = levelEndImageComp.color;
			myColor.a = 255;
			levelEndImageComp.color = myColor;
		}
	}

	/// <summary>
	/// Inits the speed counter graphics.
	/// </summary>
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

	/// <summary>
	/// Updates the speed markers with how
	/// how many the player can activate.
	/// </summary>
	/// <param name="available">Available.</param>
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

	/// <summary>
	/// Updates the speed markers with how many the
	/// player has active currently..
	/// </summary>
	/// <param name="available">Available.</param>
	/// <param name="speedCap">Speed cap.</param>
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

	public void PauseMenu(){
		GameObject InGameMenu = Resources.Load ("UIObjects/InGameMenu/IngameSelector") as GameObject;
		InGameMenu = Instantiate(InGameMenu);
		InGameMenu.transform.SetParent(canvas.transform, false);
	}
}
