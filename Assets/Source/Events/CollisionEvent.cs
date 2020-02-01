using UnityEngine;
using UnityEngine.Events;

public class CollisionEvent : MonoBehaviour {
	[Header("Triggers")]
	public string CollisionName;

	[Header("Events")]
	public UnityEvent OnEnter;
	public UnityEvent OnExit;

	void OnCollisionEnter (Collision other) {
		if (other.gameObject.tag == CollisionName) {
			OnEnter.Invoke ();
		}
	}
	void OnCollisionExit (Collision other) {
		if (other.gameObject.tag == CollisionName) {
			OnExit.Invoke ();
		}
	}


}
