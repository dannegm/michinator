using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    [Header("Stats")]
    public int Health = 5;
    public float Speed = 5f;
    public float JumpForce = 10f;
    public float Oxygen = 100f;
    public bool Grounded = false;

    public int ItemsFound = 0;
    public bool Alive = true;
    public bool RespawnOnDeath = true;

    private Player originalStats;

    void Awake () {
        originalStats = Player.copy(this);
    }

    public void reset () {
        this.Health = originalStats.Health;
        this.Speed = originalStats.Speed;
        this.JumpForce = originalStats.JumpForce;
        this.Oxygen = originalStats.Oxygen;
    }

    public static Player copy (Player player) {
        Player copyPlayer = new Player ();

        copyPlayer.Health = player.Health;
        copyPlayer.Speed = player.Speed;
        copyPlayer.JumpForce = player.JumpForce;
        copyPlayer.Oxygen = player.Oxygen;

        return copyPlayer;
    }
}
