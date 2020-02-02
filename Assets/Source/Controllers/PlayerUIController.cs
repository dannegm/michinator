using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUIController : MonoBehaviour {
    [Header("Models")]
    public Player playerModel;

    [Header("Elements")]
    public Slider oxygen;

    public void updateOxygen () {
        oxygen.value = playerModel.Oxygen;
    }
}
