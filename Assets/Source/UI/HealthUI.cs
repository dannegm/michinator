using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour {
    [Header("Models")]
    public Transform Container;
    public GameObject Icon;

    [Header("Values")]
    public int value = 5;

    void Awake () {
        setValue (value);
    }

    public void setValue (int value) {
        this.value = value;

        foreach (Transform child in Container) {
            GameObject.Destroy(child.gameObject);
        }

        for (int i = 0; i < value; i++) {
            GameObject go = Instantiate(Icon) as GameObject;
            go.transform.SetParent(Container);
        }
    }
    
}
