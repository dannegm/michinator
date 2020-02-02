using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour {
    [Header("Models")]
    public Player playerModel;

    [Header("Elements")]
    public HealthUI health;
    public ProgressbarUI oxygen;

    public void updateHealth () {
        health.setValue (playerModel.Health);
    }

    public void updateOxygen () {
        oxygen.setValue (playerModel.Oxygen);
    }
}
