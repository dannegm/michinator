using UnityEngine;
using UnityEngine.Events;

public class NPCController : MonoBehaviour {
    enum Direction {
        LEFT = -1,
        RIGHT = 1,
    }

    [Header("Models")]
    public Transform npcPivot;
    public Transform playerTransform;
    public DialogController dialogController;

    [Header("Visuals")]
    public Vector3 leftDirection;
    public Vector3 rightDirection;
 
    [Header("Presets")]
    [TextArea(3, 5)]
    public string ChatMessage;

    void FixedUpdate () {
        if (playerTransform.position.x < transform.position.x) {
            npcPivot.rotation = Quaternion.Euler(leftDirection);
        } else {
            npcPivot.rotation = Quaternion.Euler(rightDirection);
        }
    }
    
    void OnTriggerEnter (Collider other) {
        if (other.tag == "Player") {
            dialogController.showDialog(ChatMessage);
        }
    }

    void OnTriggerExit (Collider other) {
        if (other.tag == "Player") {
            dialogController.hideDialog();
        }
    }

}
