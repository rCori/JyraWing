using UnityEngine;
using System.Collections;



//Create letterboxing to force aspect ratio
[RequireComponent(typeof(Camera))]
public class Letterboxing : MonoBehaviour 
{
	const float KEEP_ASPECT = 4.0f/3.0f;
	
	void Start()
	{
		float aspectRatio = Screen.width / ((float)Screen.height);
		float percentage = 1 - (aspectRatio / KEEP_ASPECT);
		
		gameObject.GetComponent<Camera>().rect = new Rect(0f, (percentage / 2f), 1f, (1f - percentage));
	}
}