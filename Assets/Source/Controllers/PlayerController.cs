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

    public void StopMove () {
        body.velocity = new Vector3(0f, 0f, 0f);
    }

    public void onDamage() {
        model.Health -= 1;
        if (model.Health == 0) {
            print("Game Over Michi!");
        }
    }

    public void onHealing(int amount) {
        model.Health += amount;
    }

    public void onLosingOxygen() {
        model.Oxygen -= 1;
        if (model.Oxygen <= 25 && model.Oxygen % 5 == 0) {
            model.Health -=1;
        }
    }

    public void onGainingOxygen(int oxygen) {
        model.Oxygen += oxygen;
    }

}
