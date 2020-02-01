using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    [Header("Models")]
    public Player model;

    public Rigidbody body;

    public void Jump () {
        body.AddForce(Vector3.up * model.JumpForce);
    }

    public void MoveLeft() {
        body.AddForce(Vector3.left * model.Speed);
    }

    public void MoveRight() {
        body.AddForce(Vector3.right * model.Speed);
    }
}
