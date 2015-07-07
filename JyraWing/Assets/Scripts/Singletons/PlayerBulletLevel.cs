using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerBulletLevel {

	

	/// <summary>
	/// The bullet level the player is at.
	/// </summary>
	private int bulletLevel;

	/// <summary>
	/// Initializes a new instance of the <see cref="PlayerBulletLevel"/> class.
	/// </summary>
	public PlayerBulletLevel(){
		bulletLevel = 0;
	}

	/// <summary>
	/// Increments the bullet level.
	/// </summary>
	public void IncrementBulletLevel(){
		if (bulletLevel < 3) {
			bulletLevel++;
		}
	}

	public void ResetBulletLevel(){
		bulletLevel = 0;
	}

	public int GetBulletLevel(){
		return bulletLevel;
	}
}
