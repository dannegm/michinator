using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AxisEvent : MonoBehaviour
{
    public UnityEvent onLeft;
    public UnityEvent onRight;

    void Update()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey("left")) {
            onLeft.Invoke();
        }

        if (Input.GetKey(KeyCode.D) || Input.GetKey("right")) {
            onRight.Invoke();
        }
    }
}