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

    [HideInInspector]
    public bool isGameOver = false;

    public void onGameOver () {
        isGameOver = true;
        OnGameOver.Invoke ();
        gameOverUI.SetActive(true);
    }

    public void onTryAgain () {
        isGameOver = false;
        OnTryAgain.Invoke ();
        gameOverUI.SetActive(false);
    }
}
