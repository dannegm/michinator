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

}
