using UnityEngine;
using UnityEngine.Events;

public class KeyEvent : MonoBehaviour {
	[Header("Triggers")]
	public KeyCode Key;

	[Header("Events")]
	public UnityEvent OnKeyPress;

	void Update () {
		CheckForKey ();
	}

	void CheckForKey () {
		if (Input.GetKey (Key)) {
			OnKeyPress.Invoke ();
		}
	}
}
