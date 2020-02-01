using UnityEngine;
using UnityEngine.Events;

public class KeyEvent : MonoBehaviour {
	public enum KeyState {
		RELEASED = 0,
		PRESSED = 1,
		DOWN = 2,
		UP = 3,
	}

	[Header("Triggers")]
	public KeyCode Key;

	[Header("Events")]
	public UnityEvent OnKeyPress;
	public UnityEvent OnKeyDown;
	public UnityEvent OnKeyUp;

	private KeyState state = KeyState.RELEASED;
	private float currentTime = 0;
	private float pressDelay = 0.3f;

	void Update () {
		CheckForKeyDown ();
		CheckForKeyPress ();
		CheckForKeyUp ();
	}

	void CheckForKeyDown () {
		if (state == KeyState.RELEASED && Input.GetKey (Key)) {
			state = KeyState.DOWN;
			OnKeyDown.Invoke ();
		}

		if (state == KeyState.DOWN && Time.time > currentTime + pressDelay) {
			state = KeyState.PRESSED;
			currentTime = Time.time;
		}
	}

	void CheckForKeyPress () {
		if (state == KeyState.DOWN) {
			state = KeyState.PRESSED;
		}

		if (state == KeyState.PRESSED) {
			OnKeyPress.Invoke ();
		}
	}
	void CheckForKeyUp () {
		if (!Input.GetKey (Key)) {
			if (state == KeyState.DOWN || state == KeyState.PRESSED) {
				state = KeyState.UP;
				OnKeyUp.Invoke ();

				if (Time.time > currentTime + pressDelay) {
					state = KeyState.RELEASED;
					currentTime = Time.time;
				}
			} else {
				state = KeyState.RELEASED;
			}
		}
	}
}
