using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogController : MonoBehaviour {
    public RectTransform dialog;
    public Text text;

    public void showDialog (string chat) {
        text.text = chat;
        dialog.gameObject.SetActive(true);
    }

    public void hideDialog () {
        dialog.gameObject.SetActive(false);
        text.text = "";
    }
}
