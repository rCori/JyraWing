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
		GameObject lifeText = Resources.Load("LifeText") as GameObject;
		Text lifeMessageText = lifeText.GetComponent<Text>();
		lifeMessageText.text = "Lives: " + lifeCount;
		lifeText = Instantiate (lifeText);
		lifeText.transform.SetParent(canvas.transform, false);
		lifeText.GetComponent<RectTransform>().position = new Vector2(
			lifeText.GetComponent<RectTransform>().position.x, 
			lifeText.GetComponent<RectTransform>().position.y);
		//We need to set positions at some point
		//Add to the collection
		lifeSpriteCollection.Add(lifeText);

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
