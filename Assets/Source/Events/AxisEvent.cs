using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AxisEvent : MonoBehaviour {
    public UnityEvent OnLeft;
    public UnityEvent OnRight;

    void FixedUpdate () {
        float direction = Input.GetAxis("Horizontal");
        if (direction < 0) {
            OnLeft.Invoke();
        }

        if (direction > 0) {
            OnRight.Invoke();
        }
    }
}