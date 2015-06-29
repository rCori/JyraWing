using UnityEngine;
using System.Collections;

public class PlayerSpeed{
	
	private float[] speedList;
	private int speedIndex;

	public PlayerSpeed(float[] i_speedList){
		speedList = i_speedList;
		speedIndex = 0;
	}
	

	public void IncreaseSpeed(){
		//Increment speed value
		speedIndex++;
		//handle overflow
		if (speedIndex == speedList.Length) {
			speedIndex = 0;
		}
	}

	public float GetCurrentSpeed(){
		return speedList[speedIndex];
	}
}
