using UnityEngine;
using System.Collections;

public class PlayerAnimation : MonoBehaviour {

	private bool isHit;

	// Use this for initialization
	void Start () {
		isHit = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void MoveUp(){
	}

	public void SetHit(bool isHit) {
		this.isHit = isHit;
	}

	public void MoveDown(){
	}

	public void MoveUpFinal(){
	}

	public void MoveDownFinal() {
	}
}
