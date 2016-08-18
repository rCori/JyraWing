using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[RequireComponent (typeof(Text))]
public class Rollup : MonoBehaviour {

	public int finalVal;
	public float countupRate;
	public int countupIncrement = 1;

	private int timerVal;
	private Text timer;
	IEnumerator increaseTimerInstance;

	public delegate void TimerEndDelegate();
	public event TimerEndDelegate TimerEndEvent;

	void Awake() {
		timerVal = 0;
		timer = GetComponent<Text> ();
	}

	public void BeginTimer() {
		StartCoroutine (IncreaseTimer());
	}

	IEnumerator IncreaseTimer() {
		while (timerVal < finalVal) {
			if ((timerVal + countupIncrement) > finalVal) {
				timerVal = finalVal;
			} else {
				timerVal += countupIncrement;
			}
			timer.text = timerVal + "";
			yield return new WaitForSeconds (countupRate);
		}
		if (TimerEndEvent != null) {
			TimerEndEvent ();
		}
		yield break;
	}
}
