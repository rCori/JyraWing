using UnityEngine;
using System.Collections;

public class BarrierWall : MonoBehaviour {

	public enum sides {Left = 0, Right, Top, Bottom}

	public static float RIGHT_X;

	/// <summary>
	/// The barrier mode. Determine what side it is on
	/// </summary>
	public sides barrierMode;

	// Use this for initialization
	void Start () {
		if (gameObject.name == "Right Barrier") {
			RIGHT_X = transform.position.x;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other){
		//An enemy that passes the left side of the screen should be destoryed.
		if (other.tag == "Enemy"){
			if(barrierMode == sides.Left)
			{
				if(!other.GetComponent<EnemyBehavior>().LeftWallException){
					Destroy(other.gameObject);
				}
			}
		}
		if (other.tag == "PointIcon") {
			other.GetComponent<AwardPoints> ().DestroyPoint ();
		}

		if (other.tag == "PowerUp") {
			Destroy(other.gameObject);
		}
	}
}
