using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaController : MonoBehaviour {
    [Header("Models")]
    public Lava lavaModel;

    [Header("Pressets")]
    public float Delay = 1f;
    float elapsed = 0f;
    bool canDoDamage = true;

    void FixedUpdate () {
        elapsed += Time.deltaTime;
        if (elapsed >= Delay) {
            elapsed = elapsed % Delay;
            canDoDamage = true;
        }
    }
    
    // > Collisions
	void OnCollisionStay (Collision other) {
		if (canDoDamage && other.gameObject.tag == "Player") {
            canDoDamage = false;
			PlayerController player = other.transform.GetComponent<PlayerController>();
            player.onDamage(lavaModel.Damage);
		}
	}
}
