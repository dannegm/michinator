using UnityEngine;
using UnityEngine.Events;

public class FallEvent : MonoBehaviour {
    [Header("Triggers")]
    public Transform target;
    public float Depth;

    [Header("Events")]
    public UnityEvent OnFall;

    void Update () {
        if (target.position.y < Depth) {
            OnFall.Invoke ();
        }
    }
}
