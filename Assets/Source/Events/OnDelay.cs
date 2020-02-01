using UnityEngine;
using UnityEngine.Events;

public class DelayToEvent : MonoBehaviour {
	[Header("Triggers")]
	public float Seconds = 5f;

	[Header("Events")]
	public UnityEvent OnDelay;

	private float currentTime = 0;
	private bool canInvoke = false;

	void Awake () {
		currentTime = Time.time;
	}
	
	void Update () {
		CheckForDelay();
	}

	void CheckForDelay () {
		if (!canInvoke) {
			if (Time.time > (Seconds + currentTime)) {
				OnDelay.Invoke ();
				canInvoke = true;
			}
		}
	}
}
