using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour {
    [Header("Constrains")]
    public Transform target;
    
    [Header("Presets")]
    public float Speed;

    private Vector3 start, end;

    void Start () {
        start = transform.position;
        end = target.position;
    }

    void FixedUpdate () {
        float deltaSpeed = Speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards (
            transform.position,
            target.position,
            deltaSpeed
        );

        if (transform.position == target.position) {
            target.position = target.position == start ? end : start;
        }
    }

    // > Debug

    void OnDrawGizmos () {
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(transform.position, target.position);

        float cubeSize = 0.035f;
        Vector3 cubeVectorSize = new Vector3 (cubeSize, cubeSize, cubeSize);

        Gizmos.DrawCube(transform.position, cubeVectorSize);
        Gizmos.DrawCube(target.position, cubeVectorSize);
    }
}
