using UnityEngine;
using UnityEngine.Events;

public class LoadEvent : MonoBehaviour {
	[Header("Events")]
	public UnityEvent OnStart;
	public UnityEvent OnAwake;
	// Use this for initialization
	void Start () {
		OnStart.Invoke ();
	}

	void Awake () {
		OnAwake.Invoke ();
	}
}
