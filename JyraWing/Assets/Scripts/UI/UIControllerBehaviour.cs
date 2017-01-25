using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class UIControllerBehaviour: MonoBehaviour {

	//const bool ISDEBUG = false;

	//The UI canvas for drawin all of these UI elements
	public GameObject canvas;
	public GameObject playerCanvas;

	//The level of speed the player is at
	//private int speedCount;
	private GameObject gameOverMessage;
	private GameObject levelEndImage;
	private GameObject lifeText;
	private GameObject scoreText;

	// Player speed will be represented by multiple sprites in different states of opacity
	private Slider slider;

	//ISDEBUG
	private GameObject debugFramerate;
	private float deltaTime;

	private IUIController uiController;

	private Color invisibleColor;
	private Color visibleColor;

	// Use this for initialization
	void Start () {

		uiController = new UIController ();

		levelEndImage = Resources.Load("UIObjects/LevelFinishedImage") as GameObject;
		levelEndImage = Instantiate (levelEndImage);
		levelEndImage.transform.SetParent (canvas.transform, false);

		gameOverMessage = Resources.Load("UIObjects/GameOverImage") as GameObject;
		gameOverMessage = Instantiate (gameOverMessage);
		gameOverMessage.transform.SetParent(canvas.transform, false);

		slider = (Resources.Load("UIObjects/PlayerShieldMeter") as GameObject).GetComponent<Slider>();
		slider = Instantiate (slider);
		slider.transform.SetParent(playerCanvas.transform, false);

		Initialize (PlayerLives.Instance.GetCurrentLives());

		visibleColor = new Color (1.0f, 1.0f, 1.0f, 1.0f);
		invisibleColor = new Color (1.0f, 1.0f, 1.0f, 0.0f);

		ScoreController.AddToScoreEvent += UpdateScore;
		CountdownTimer.PlayerContinueEvent += HideGameOver;
		CountdownTimer.PlayerContinueEvent += ResetLives;
		LevelControllerBehavior.FinishLevelEvent += ShowLevelComplete;
		LevelControllerBehavior.GameOverEvent += ShowGameOver;
		PauseControllerBehavior.PauseEvent += PauseMenu;
		Player.TakeDamageEvent += UpdateLives;
		Player.TakeDamageEvent += DisableShieldSlider;
		PlayerShield.SetShieldPercentageEvent += UpdatePlayerShield;
	}
	

	public void Initialize(int i_lifeCount){
		initLives (i_lifeCount);
		initScore ();
	}

	/// <summary>
	/// Create the life counter in the top left.
	/// </summary>
	/// <param name="lives">Lives.</param>
	private void initLives(int lives){
		lifeText = Resources.Load("UIObjects/LifeText") as GameObject;
		Text lifeMessageText = lifeText.GetComponent<Text>();
		lifeMessageText.text = "Lives: " + lives;
		lifeText = Instantiate (lifeText);
		lifeText.transform.SetParent(canvas.transform, false);
		lifeText.GetComponent<RectTransform>().position = new Vector2(
			lifeText.GetComponent<RectTransform>().position.x, 
			lifeText.GetComponent<RectTransform>().position.y);

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
	private void UpdateLives(){
		//uiController.DecreaseLifeCount ();
		Text lifeMessageText = lifeText.GetComponent<Text>();
        //lifeMessageText.text = "Lives: " + uiController.GetLifeCount();
        lifeMessageText.text = "Lives: " + PlayerLives.Instance.GetCurrentLives();
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
	//public void UpdateLives(int i_lives){
	//	//Remove a life
	//	uiController.DecreaseLifeCount();
	//}

	/// <summary>
	/// Shows the level complete graphic.
	/// </summary>
	public void ShowLevelComplete(){
		//Set the alpha to max, making it visible.
		//if (uiController.GetLifeCount() != 0) {
        if (PlayerLives.Instance.GetCurrentLives() != 0) {
			Image levelEndImageComp = levelEndImage.GetComponent<Image> ();
			Color myColor = levelEndImageComp.color;
			myColor.a = 255;
			levelEndImageComp.color = myColor;
		}
	}


	public void UpdatePlayerShield(int shieldPercentage){
		if (slider) {
			if (shieldPercentage == 100.0f && slider.value != 1.0f) {
				slider.gameObject.SetActive (false);
			} else if (shieldPercentage != 100.0f && slider.value == 1.0f) {
				slider.gameObject.SetActive (true);
			}

			slider.enabled = (shieldPercentage != 100.0f);
			uiController.SetShieldPercentage (shieldPercentage);
			slider.value = (float)shieldPercentage / 100.0f;
		}
	}

	public void PauseMenu(){
		GameObject InGameMenu = Resources.Load ("UIObjects/InGameOptionsMenu/InGameOptionsMenu") as GameObject;
		InGameMenu = Instantiate(InGameMenu);
		InGameMenu.transform.SetParent(canvas.transform, false);
	}

	public void UpdateScore(int score) {
		Text scoreMessageText = scoreText.GetComponent<Text> ();
		scoreMessageText.text = "Score: " + score;
	}

	public void ResetLives() {
		uiController.InitializeLifeCount ();
		Text lifeMessageText = lifeText.GetComponent<Text>();
        //lifeMessageText.text = "Lives: " + uiController.GetStartingLifeCount ();
        lifeMessageText.text = "Lives: " + SaveData.Instance.livesPerCredit;
	}

	public void DisableShieldSlider() {
		slider.gameObject.SetActive (false);
	}

	void OnDestroy() {
		ScoreController.AddToScoreEvent -= UpdateScore;
		CountdownTimer.PlayerContinueEvent -= HideGameOver;
		CountdownTimer.PlayerContinueEvent -= ResetLives;
		LevelControllerBehavior.FinishLevelEvent -= ShowLevelComplete;
		LevelControllerBehavior.GameOverEvent -= ShowGameOver;
		PauseControllerBehavior.PauseEvent -= PauseMenu;
		Player.TakeDamageEvent -= UpdateLives;
		Player.TakeDamageEvent -= DisableShieldSlider;
		PlayerShield.SetShieldPercentageEvent -= UpdatePlayerShield;
	}
}
