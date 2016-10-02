using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PointIconPool : MonoBehaviour {

    public Player player;

	List<GameObject> iconPool;
	List<AwardPoints> iconAwardPointsPool;
	List<PointAttraction> pointAttractionPool;
	int poolSize = 10;

	//Some bad design here done for the sake of effeciency
	//Otherwise GameObject.Find needs to be called far to many times.
	public PauseControllerBehavior pauseControllerBehavior;

	// Use this for initialization
	void Start () {
		iconPool = new List<GameObject> ();
		iconAwardPointsPool = new List<AwardPoints> ();
		pointAttractionPool = new List<PointAttraction> ();
		for (int i = 0; i < poolSize; i++) {
			AddToPool ();
		}
	}


	public void SpawnPointIcon(int pointValueLevel, Vector2 location) {
		for (int i = 0; i < poolSize; i++) {
			if (!iconAwardPointsPool [i].GetIsActive ()) {
				iconAwardPointsPool [i].SetValue (pointValueLevel);
				iconAwardPointsPool [i].MakeActive ();
				pointAttractionPool [i].RemovingAttraction ();
				iconPool [i].transform.position = location;
				return;
			}
		}
		//We need to make a new pointIcon, put it in the pool and call this function again.
		AddToPool();
		poolSize++;
		SpawnPointIcon (pointValueLevel, location);
	}

	private void AddToPool() {
		GameObject icon = Resources.Load ("Pickups/PointIcons/PointIcon") as GameObject;
		icon.transform.position = new Vector2 (0f, 10f);
		icon = Instantiate (icon);
		icon.gameObject.SetActive(true);

		GameObject pointAttractionObject = icon.transform.GetChild (0).gameObject;
		AwardPoints awardPointsBehavior = pointAttractionObject.GetComponent<AwardPoints> ();
        awardPointsBehavior.SetPlayer(player);
		PointAttraction pointAttractionBehavior = pointAttractionObject.transform.parent.GetComponent<PointAttraction> ();
        pointAttractionBehavior.SetPlayer(player);

		iconPool.Add (icon);
		iconAwardPointsPool.Add (awardPointsBehavior);
		pointAttractionPool.Add (pointAttractionBehavior);
	}
}
