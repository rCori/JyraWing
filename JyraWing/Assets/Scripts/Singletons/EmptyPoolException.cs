using UnityEngine;
using System.Collections;
using System;

public class EmptyPoolException : Exception {

	public EmptyPoolException(){
		Debug.LogError ("Bullet pool out of ammo");
	}
}
