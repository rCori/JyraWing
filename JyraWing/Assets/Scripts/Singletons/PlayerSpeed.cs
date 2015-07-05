using UnityEngine;
using System.Collections;

public class PlayerSpeed{
	
	private float[] speedList;
	private int speedIndex;
	//What level of speed is allowed to the player.
	private int speedCap;

	public PlayerSpeed(float[] i_speedList){
		speedList = i_speedList;
		speedIndex = 0;
		speedCap = 0;
	}
	

	public void IncreaseSpeed(){
		//Increment speed value
		speedIndex++;
		//handle overflow
		if (speedIndex == speedList.Length || speedIndex > speedCap) {
			speedIndex = 0;
		}
	}

	public float GetCurrentSpeed(){
		return speedList[speedIndex];
	}

	public int GetSpeedLevel()
	{
		return speedIndex;
	}

	public int GetSpeedCap(){
		return speedCap;
	}

	public void IncreaseSpeedCap(){
		//Check if there is any more peed level to allow
		if (speedCap < speedList.Length - 1) {
			speedCap++;
		}
	}
}
