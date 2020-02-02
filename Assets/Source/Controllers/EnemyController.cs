using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

    enum Direction {
        LEFT = -1,
        RIGHT = 1,
    }

    [Header("Models")]
    public Enemy enemyModel;
    public Rigidbody enemyBody;
    public Transform enemyPivot;

    [Header("Visuals")]
    public Vector3 leftDirection;
    public Vector3 rightDirection;

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
        enemyBody.AddForce (Vector3.right * ((float) direction * enemyModel.Speed));
        
        float limitedSpeed = Mathf.Clamp (
            enemyBody.velocity.x,
            -maxSpeed,
            maxSpeed
        );

        enemyBody.velocity = new Vector3 (
            limitedSpeed,
            enemyBody.velocity.y,
            enemyBody.velocity.z
        );

        if (enemyBody.transform.position.x < pointA.position.x) {
            direction = Direction.RIGHT;
            enemyPivot.rotation = Quaternion.Euler(rightDirection);
        }

        if (enemyBody.transform.position.x > pointB.position.x) {
            direction = Direction.LEFT;
            enemyPivot.rotation = Quaternion.Euler(leftDirection);
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

    // > Collisions
	void OnCollisionEnter (Collision other) {
		if (other.gameObject.tag == "Player") {
			PlayerController player = other.transform.GetComponent<PlayerController>();
            player.onDamage(enemyModel.Damage);
		}
	}
}
