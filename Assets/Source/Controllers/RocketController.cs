using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RocketController : MonoBehaviour {
    
    [Header("Models")]
    public Player playerModel;
    public DialogController dialogController;

    [Header("Presets")]
    public int ItemsNeeded = 1;

    [Header("Messages")]
    [TextArea(3,5)]
    public string GrantMessage;

    [TextArea(3,5)]
    public string DennyMessage;

    [Header("Events")]
    public UnityEvent OnTakeOff;

    private bool inRange = false;

    public bool canTakeOff () {
        return ItemsNeeded <= playerModel.ItemsFound;
    }

    public void TakeOff () {
        if (canTakeOff () && inRange) {
            OnTakeOff.Invoke ();
        }
    }

    void OnTriggerEnter (Collider other) {
        if (other.tag == "Player") {
            inRange = true;
            dialogController.showDialog(
                canTakeOff() ? GrantMessage : DennyMessage
            );
        }
    }

    void OnTriggerExit (Collider other) {
        if (other.tag == "Player") {
            inRange = false;
            dialogController.hideDialog();
        }
    }
}
