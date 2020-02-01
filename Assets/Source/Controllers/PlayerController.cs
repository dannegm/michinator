using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    enum Directions {
        Left = -1,
        Right = 1,
    }

    public Rigidbody body;
    public float Speed = 5f;
    // Start is called before the first frame update
}
