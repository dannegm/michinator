using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
    [Header("Models")]
    public Transform target;

    [Header("Boundaeries")]
    public Transform Top;
    public Transform Bottom;
    public Transform Start;
    public Transform End;

    [Header("Tweaks")]
    public float SmoothTime;
    
    private Vector2 velocity;

    private float cameraSize;

    void Awake () {
        Camera camera = GetComponent<Camera>();
        cameraSize = camera.orthographicSize;
    }

    void FixedUpdate () {
        float positionX = Mathf.SmoothDamp (
            transform.position.x,
            target.position.x,
            ref velocity.x,
            SmoothTime
        );

        float positionY = Mathf.SmoothDamp (
            transform.position.y,
            target.position.y,
            ref velocity.y,
            SmoothTime
        );

        transform.position = new Vector3 (
            Mathf.Clamp(positionX, Start.position.x, End.position.x),
            Mathf.Clamp(positionY, Bottom.position.y, Top.position.y),
            transform.position.z
        );
    }

    void OnDrawGizmos () {
        Gizmos.color = Color.yellow;

        // TOP
        Gizmos.DrawLine(
            new Vector3 (
                Start.position.x,
                Top.position.y,
                target.position.z
            ),
            new Vector3 (
                End.position.x,
                Top.position.y,
                target.position.z
            )
        );

        // BOTTOM
        Gizmos.DrawLine(
            new Vector3 (
                Start.position.x,
                Bottom.position.y,
                target.position.z
            ),
            new Vector3 (
                End.position.x,
                Bottom.position.y,
                target.position.z
            )
        );

        // START
        Gizmos.DrawLine(
            new Vector3 (
                Start.position.x,
                Top.position.y,
                target.position.z
            ),
            new Vector3 (
                Start.position.x,
                Bottom.position.y,
                target.position.z
            )
        );

        // END
        Gizmos.DrawLine(
            new Vector3 (
                End.position.x,
                Top.position.y,
                target.position.z
            ),
            new Vector3 (
                End.position.x,
                Bottom.position.y,
                target.position.z
            )
        );
    }
}
