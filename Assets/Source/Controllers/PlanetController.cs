using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetController : MonoBehaviour {
    [Header("Models")]
    public Player model;
    public Planet planetModel;
    public Rigidbody body;

    public void onChangeGravity(float newGravity) {
        model.Gravity = (planetModel.Gravity * model.Gravity) / 100;
        model.JumpForce = (model.Gravity * model.JumpForce) / 100;
    }
}
