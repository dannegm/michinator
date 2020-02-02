using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour {
    [Header("Models")]
    public Animator animator;

    public void triggerAnimation (string triggerName) {
        animator.SetTrigger(triggerName);
    }
}
