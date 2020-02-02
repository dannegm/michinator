using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PauseController : MonoBehaviour {
    [Header("Models")]
    public GameObject pauseMenuUI;

    [Header("Events")]
    public UnityEvent OnPause;
    public UnityEvent OnResume;

    private bool isPaused;

    void Update () {
        if (isPaused) {
            onPause ();
        } else {
            onResume ();
        }
    }

    public void Pause () {
        isPaused = true;
    }

    public void Resume () {
        isPaused = false;
    }

    public void switchPause () {
        isPaused = !isPaused;
    }

    void onPause () {
        OnPause.Invoke ();
        Time.timeScale = 0;
        pauseMenuUI.SetActive(true);
    }

    void onResume () {
        OnResume.Invoke ();
        Time.timeScale = 1;
        pauseMenuUI.SetActive(false);
    }
}
