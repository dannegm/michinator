using UnityEngine;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour {

    public enum Direction {
        LEFT = -1,
        RIGHT = 1,
    }

    [Header("Models")]
    public Player playerModel;
    public Planet planetModel;
    public Transform playerTransform;
    public Transform playerPivot;
    public Rigidbody playerBody;
    public GameOverController gameOverController;

    [Header("Visuals")]
    public Vector3 leftDirection;
    public Vector3 rightDirection;
    public Vector3 deathPosition;
    public Vector3 deathRotation;

    [Header("Presets")]
    public Transform spawnPoint;
    public int maxHealt = 5;
    public float maxSpeed = 1f;
    public float maxGravity = 9.81f;

    [Header("Events")]
    public UnityEvent OnMoveLeft;
    public UnityEvent OnMoveRight;
    public UnityEvent OnJump;
    public UnityEvent OnGround;
    public UnityEvent OnRespawn;
    public UnityEvent OnDeath;
    public UnityEvent OnDamage;
    public UnityEvent OnHealing;
    public UnityEvent OnLosingOxygen;
    public UnityEvent OnGainingOxygen;

    public MeshRenderer dialogRender;

    void Awake () {
        planetModel = GameObject.Find("Planet").GetComponent<Planet>();
    }
    
    private void Move (Direction direction) {
        if (!gameOverController.isGameOver) {
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

            Vector3 poseDirection = direction == Direction.LEFT ? leftDirection : rightDirection;
            playerPivot.rotation = Quaternion.Euler(poseDirection);
        }

    }
    
    public void onMoveLeft () {
        Move (Direction.LEFT);
        OnMoveLeft.Invoke ();
    }
    public void onMoveRight () {
        Move (Direction.RIGHT);
        OnMoveRight.Invoke ();

    }

    public void onJump () {
        if (!gameOverController.isGameOver) {
            float pGravity = maxGravity / planetModel.Gravity * 100;
            float pJumpForce = playerModel.JumpForce / 100 * pGravity;

            playerBody.AddForce(Vector3.up * pJumpForce);
            OnJump.Invoke ();
        }
    }

    public void onDamage (int points) {
        if (!gameOverController.isGameOver) {
            if (playerModel.Health > 0) {
                playerModel.Health -= points;
                OnDamage.Invoke ();
            }

            if (playerModel.Health < 1) {
                onDeath ();
            }
        }
    }

    public void onHealing (int points) {
        if (!gameOverController.isGameOver) {
            if (playerModel.Health < maxHealt) {
                playerModel.Health += points;
                OnHealing.Invoke ();
            }
        }
    }

    public void onLosingOxygen (Planet planet) {
        if (!gameOverController.isGameOver) {
            float oxygenFactor = 100f - planet.Oxygen;
            playerModel.Oxygen -= oxygenFactor;
            OnLosingOxygen.Invoke ();

            if (playerModel.Oxygen <= 25 && playerModel.Oxygen % 5 == 0) {
                onDamage (1);
            }
        }

    }

    public void onGainingOxygen (int oxygen) {
        if (!gameOverController.isGameOver) {
            OnGainingOxygen.Invoke ();
            if (playerModel.Oxygen < 100f) {
                playerModel.Oxygen += oxygen;
            }
        }
    }

    public void onRespawn () {
        playerTransform.position = spawnPoint.position;
        playerModel.reset ();
        playerModel.Alive = true;
        OnRespawn.Invoke ();
    }

    public void onDeath () {
        playerModel.Alive = false;
        OnDeath.Invoke ();

        playerPivot.position = deathPosition;
        playerPivot.rotation = Quaternion.Euler(deathRotation);

        if (playerModel.RespawnOnDeath) {
            onRespawn ();
        }
    }

    // > Collisions
	void OnCollisionEnter (Collision other) {
		if (other.gameObject.tag == "Ground") {
			playerModel.Grounded = true;
            OnGround.Invoke ();
		}

		if (other.gameObject.tag == "Platform") {
			playerModel.Grounded = true;
            OnGround.Invoke ();
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
