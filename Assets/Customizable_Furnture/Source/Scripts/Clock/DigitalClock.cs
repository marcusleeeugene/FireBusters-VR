using UnityEngine;
using System.Collections;

public class DigitalClock : MonoBehaviour {
	public DigitalClockValue hoursDCV;
	public DigitalClockValue minutesDCV;
	public DigitalClockValue secondsDCV;
	public DigitalClockValue pointsDCV;
	public bool pointFlicker=true;
	public float clockSpeed;

	void Start () {

		StartCoroutine ("PlayTime");
		if (pointFlicker && secondsDCV==null)StartCoroutine ("PlayPointFlicker");
	}
	public void SetReverseClock(bool setReverse){
		if (hoursDCV != null)
			hoursDCV.reverse = setReverse;
		if (minutesDCV != null)
			minutesDCV.reverse = setReverse;
		if (secondsDCV != null)
			secondsDCV.reverse = setReverse;
	}

	IEnumerator PlayTime(){
		while (true) {
			if (secondsDCV!=null){
				yield return new WaitForSeconds (1.0f /clockSpeed);
				secondsDCV.ChangeTimeValue ();
				if (pointFlicker)pointsDCV.ChangeTimeValue ();
			}
			else {
				yield return new WaitForSeconds (60.0f/clockSpeed);
				minutesDCV.ChangeTimeValue ();


			}
		}
	}
	IEnumerator PlayPointFlicker(){
		while (pointFlicker) {
			yield return new WaitForSeconds (1.0f /clockSpeed);
			pointsDCV.ChangeTimeValue ();
		}
	}
}
