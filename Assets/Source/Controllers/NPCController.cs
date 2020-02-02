using UnityEngine;
using UnityEngine.Events;

public class NPCController : MonoBehaviour {

    public MeshRenderer dialogRender;
    public SpriteRenderer textBox;

	  void Awake () {
		  dialogRender.enabled = false;
      textBox.enabled = false;
	  }
    
    void OnCollisionEnter (Collision other) {
		if (other.gameObject.tag == "Player") {
      dialogRender.enabled = true;
      textBox.enabled = true;
		}
	}

    void OnCollisionExit (Collision other) {
		if (other.gameObject.tag == "Player") {
      dialogRender.enabled = false;
      textBox.enabled = false;
    }
	}

}
