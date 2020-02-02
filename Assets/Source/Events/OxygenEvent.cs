using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OxygenEvent : MonoBehaviour {
    [Header("Pressets")]
    public float Delay = 1f;

    [Header("Events")]
    public UnityEvent OnDecrease;

    float elapsed = 0f;

    void FixedUpdate () {
        elapsed += Time.deltaTime;
        if (elapsed >= Delay) {
            elapsed = elapsed % Delay;
            decrease ();
        }
    }
    void decrease () {
        OnDecrease.Invoke ();
    }

}
