using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameOverController : MonoBehaviour {
    [Header("Models")]
    public GameObject gameOverUI;

    [Header("Events")]
    public UnityEvent OnGameOver;
    public UnityEvent OnTryAgain;

    public void onGameOver () {
        OnGameOver.Invoke ();
        Time.timeScale = 0;
        gameOverUI.SetActive(true);
    }

    public void onTryAgain () {
        OnTryAgain.Invoke ();
        Time.timeScale = 1;
        gameOverUI.SetActive(false);
    }
}
