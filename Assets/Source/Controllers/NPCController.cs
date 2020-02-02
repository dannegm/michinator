using UnityEngine;
using UnityEngine.Events;

public class NPCController : MonoBehaviour {

    public MeshRenderer dialogRender;

	  void Awake () {
		  dialogRender.enabled = false;
	  }
    
    void OnCollisionEnter (Collision other) {
		if (other.gameObject.tag == "Player") {
      dialogRender.enabled = true;
		}
	}

    void OnCollisionExit (Collision other) {
		if (other.gameObject.tag == "Player") {
      dialogRender.enabled = false;
    }
	}

}
