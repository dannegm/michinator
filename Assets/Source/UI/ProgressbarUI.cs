using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressbarUI : MonoBehaviour {
    [Header("Models")]
    public RectTransform Container;
    public RectTransform Progress;

    [Header("Values")]
    [Range(0, 100f)]
    public float value;

    [ExecuteInEditMode]
    void FixedUpdate () {
        float progressWidth = Container.rect.width / 100f * value;
        Progress.sizeDelta = new Vector2(progressWidth, 0f);
    }

    public void setValue (float value) {
        this.value = value > 100f ? 100f : value < 0f ? 0f : value;
    }
}
