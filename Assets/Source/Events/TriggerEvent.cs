using UnityEngine;
using UnityEngine.Events;

public class TriggerEvent : MonoBehaviour {
	[Header("Triggers")]
	public string ColliderName;

	[Header("Events")]
	public UnityEvent OnEnter;
	public UnityEvent OnExit;

	void OnTriggerEnter (Collider other) {
		if (other.name == ColliderName) {
			OnEnter.Invoke ();
		}
	}
	void OnTriggerExit (Collider other) {
		if (other.tag == ColliderName) {
			OnExit.Invoke ();
		}
	}
}
