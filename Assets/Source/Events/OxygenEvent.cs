using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OxygenEvent : MonoBehaviour
{
    public UnityEvent loseOxygen;
    public UnityEvent gainOxygen;

    float elapsed = 0f;

    void Update() {
        elapsed += Time.deltaTime;
        if (elapsed >= 1f) {
            elapsed = elapsed % 1f;
            decrease();
        }
    }
    void decrease() {
        loseOxygen.Invoke();
    }
    
    void increase() {
        gainOxygen.Invoke();
    }

}
