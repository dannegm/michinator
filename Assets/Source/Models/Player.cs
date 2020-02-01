using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    [Header("Stats")]
    public int Health = 5;
    public float Speed = 5f;
    public float JumpForce = 10f;
    public float Gravity = 9.8f;
    public bool Grounded = false;
}
