using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

    enum Direction {
        LEFT = -1,
        RIGHT = 1,
    }

    [Header("Models")]
    public Enemy model;
    public Rigidbody body;

    [Header("Constrains")]
    public Transform pointA;
    public Transform pointB;

    [Header("Presets")]
    public float maxSpeed = 1f;

    private Direction direction = Direction.LEFT;

    void FixedUpdate () {
        Walk ();
    }

    public void Walk () {
        body.AddForce (Vector3.right * ((float) direction * model.Speed));
        
        float limitedSpeed = Mathf.Clamp (
            body.velocity.x,
            -maxSpeed,
            maxSpeed
        );

        body.velocity = new Vector3 (
            limitedSpeed,
            body.velocity.y,
            body.velocity.z
        );

        if (body.transform.position.x < pointA.position.x) {
            direction = Direction.RIGHT;
        }

        if (body.transform.position.x > pointB.position.x) {
            direction = Direction.LEFT;
        }
    }

    // > Debug

    void OnDrawGizmos () {
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(pointA.position, pointB.position);

        float cubeSize = 0.035f;
        Vector3 cubeVectorSize = new Vector3 (cubeSize, cubeSize, cubeSize);

        Gizmos.DrawCube(pointA.position, cubeVectorSize);
        Gizmos.DrawCube(pointB.position, cubeVectorSize);
    }
}
