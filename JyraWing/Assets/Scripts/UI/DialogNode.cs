using UnityEngine;
using System.Collections;

public class DialogNode : MonoBehaviour {

    public OnScreenDialog onScreenDialog;
    public string dialog;
	
	// Update is called once per frame
	void Update () {
	    if (transform.position.x <= BarrierWall.RIGHT_X) {
            Debug.Log("showing dialog");
            onScreenDialog.ShowDialog(dialog);
			Destroy (this.gameObject);
		}
	}
}
