using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class UIControllerBehaviour: MonoBehaviour {

	//const bool ISDEBUG = false;

	//The UI canvas for drawin all of these UI elements
	public GameObject canvas;
	public GameObject playerCanvas;

	//Number of lives the player has
	private int lifeCount;
	//The level of speed the player is at
	private int speedCount;
	private GameObject gameOverMessage;
	private GameObject levelEndImage;
	private GameObject lifeText;
	private GameObject scoreText;

	// Player speed will be represented by multiple sprites in different states of opacity
	private Slider slider;

	//ISDEBUG
	private GameObject debugFramerate;
	private float deltaTime;


	// Use this for initialization
	void Start () {

		levelEndImage = Resources.Load("UIObjects/LevelFinishedImage") as GameObject;
		levelEndImage = Instantiate (levelEndImage);
		levelEndImage.transform.SetParent (canvas.transform, false);

		gameOverMessage = Resources.Load("UIObjects/GameOverImage") as GameObject;
		gameOverMessage = Instantiate (gameOverMessage);
		gameOverMessage.transform.SetParent(canvas.transform, false);

//		shieldText = Resources.Load ("UIObjects/ShieldText") as GameObject;
//		shieldText = Instantiate (shieldText);
//		shieldText.transform.SetParent(canvas.transform, false);

		slider = (Resources.Load("UIObjects/PlayerShieldMeter") as GameObject).GetComponent<Slider>();
		slider = Instantiate (slider);
		slider.transform.SetParent(playerCanvas.transform, false);
		//slider = GameObject.FindWithTag("ShieldMeter").GetComponent<Slider>();

		ScoreController.AddToScoreEvent += UpdateScore;
		CountdownTimer.PlayerContinueEvent += HideGameOver;
		CountdownTimer.PlayerContinueEvent += ResetLives;
//		if (ISDEBUG) {
//			debugFramerate = Resources.Load("UIObjects/DEBUGFramerateText") as GameObject;
//			debugFramerate = Instantiate (debugFramerate);
//			debugFramerate.transform.SetParent(canvas.transform, false);
//			deltaTime = 0.0f;
//		}
	}
	

	public void Initialize(int i_lifeCount){
		//lifeSpriteCollection = new List<GameObject> ();
		lifeCount = i_lifeCount;
		initLives (lifeCount);
		speedCount = 4;
		initScore ();

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

	private void initScore() {
		scoreText = Resources.Load("UIObjects/ScoreText") as GameObject;
		Text scoreMessageText = scoreText.GetComponent<Text> ();
		scoreMessageText.text = "Score: " + ScoreController.GetScore();
		scoreText = Instantiate (scoreText);
		scoreText.transform.SetParent (canvas.transform, false);
		scoreText.GetComponent<RectTransform>().position = new Vector2(
			scoreText.GetComponent<RectTransform>().position.x, 
			scoreText.GetComponent<RectTransform>().position.y);
	}

	/// <summary>
	/// Decrease the number of lives and deactivate a life on the HUD 
	/// </summary>
	/// <param name="i_curLife">The life to removed from HUD.</param>
	private void DecreaseLives(){
		lifeCount--;
		if(lifeCount >= 0) {
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

	public void HideGameOver() {
		Image gameOverMessageComp = gameOverMessage.GetComponent<Image> ();
		Color myColor = gameOverMessageComp.color;
		myColor.a = 0;
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


	public void UpdatePlayerShield(int shieldPercentage){
		if (slider) {
			slider.value = (float)shieldPercentage / 100.0f;
		}
	}

	public void PauseMenu(){
		GameObject InGameMenu = Resources.Load ("UIObjects/InGameMenu/IngameSelector") as GameObject;
		InGameMenu = Instantiate(InGameMenu);
		InGameMenu.transform.SetParent(canvas.transform, false);
	}

	public void UpdateScore(int score) {
		Text scoreMessageText = scoreText.GetComponent<Text> ();
		scoreMessageText.text = "Score: " + score;
	}

	public void ResetLives() {
		lifeCount = 3;
		Text lifeMessageText = lifeText.GetComponent<Text>();
		lifeMessageText.text = "Lives: " + lifeCount;
	}

	void OnDestroy() {
		ScoreController.AddToScoreEvent -= UpdateScore;
		CountdownTimer.PlayerContinueEvent -= HideGameOver;
		CountdownTimer.PlayerContinueEvent -= ResetLives;
	}
}
