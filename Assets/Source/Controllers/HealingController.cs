using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingController : MonoBehaviour {
    [Header("Models")]
    public GameObject prefab;

    [Header("Presets")]
    public int HealthPoints = 1;
    // > Collisions
	void OnTriggerEnter (Collider other) {
		if (other.tag == "Player") {
			PlayerController player = other.GetComponent<PlayerController>();
            player.onHealing(HealthPoints);
            Destroy(prefab);
		}
	}
}
