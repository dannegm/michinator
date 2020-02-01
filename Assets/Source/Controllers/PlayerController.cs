using UnityEngine;

public class PlayerController : MonoBehaviour {

    public enum Direction {
        LEFT = -1,
        RIGHT = 1,
    }

    [Header("Models")]
    public Player playerModel;
    public Transform playerTransform;
    public Rigidbody playerBody;

    [Header("Presets")]
    public Transform spawnPoint;
    public float maxSpeed = 1f;

    public void Jump () {
        playerBody.AddForce(Vector3.up * playerModel.JumpForce);
    }

    public void Move (Direction direction) {
        playerBody.AddForce(Vector3.right * (float) direction * playerModel.Speed);

        float limitedSpeed = Mathf.Clamp (
            playerBody.velocity.x,
            -maxSpeed,
            maxSpeed
        );
    
        playerBody.velocity = new Vector3 (
            limitedSpeed,
            playerBody.velocity.y,
            playerBody.velocity.z
        );
    }
    public void MoveLeft () {
        Move (Direction.LEFT);
    }
    public void MoveRight () {
        Move (Direction.RIGHT);
    }

    public void Respawn () {
        playerTransform.position = spawnPoint.position;
    }

    // > Collisions
	void OnCollisionEnter (Collision other) {
		if (other.gameObject.tag == "Ground") {
			playerModel.Grounded = true;
		}

		if (other.gameObject.tag == "Platform") {
			playerModel.Grounded = true;
            playerTransform.SetParent(other.transform.parent);
			playerBody.velocity = new Vector3 (0, 0, 0);
		}
	}

	void OnCollisionExit (Collision other) {
		if (other.gameObject.tag == "Ground") {
			playerModel.Grounded = false;
		}

		if (other.gameObject.tag == "Platform") {
			playerModel.Grounded = false;
            playerTransform.SetParent(null);
		}
	}
}
