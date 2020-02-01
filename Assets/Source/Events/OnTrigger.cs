using UnityEngine;
using UnityEngine.Events;

public class TriggerEvents : MonoBehaviour {
	[Header("Triggers")]
	public string ColliderName;

	[Header("Events")]
	public UnityEvent OnEnter;
	public UnityEvent OnExit;

	private bool isEnter = false;

	void OnTriggerEnter (Collider other) {
		if (other.name == ColliderName) {
			OnEnter.Invoke ();
		}
	}
	void OnTriggerExit (Collider other) {
		if (other.name == ColliderName) {
			OnExit.Invoke ();
		}
	}
}
