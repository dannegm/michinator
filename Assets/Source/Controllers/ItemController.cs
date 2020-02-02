using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ItemController : MonoBehaviour {
    [Header("Models")]
    public GameObject prefab;

    [Header("Events")]
    public UnityEvent OnCollect;
    // > Collisions
	void OnTriggerEnter (Collider other) {
		if (other.tag == "Player") {
            OnCollect.Invoke ();
			Player player = other.GetComponent<Player>();
            player.ItemsFound += 1;
            Destroy(prefab);
		}
	}
}
