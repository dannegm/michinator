using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {
	void LoadScene (string SceneName) {
        StartCoroutine (LoadNewScene(SceneName));
    }

    void Quit () {
        Application.Quit ();
    }

	public void OpenURL (string url) {
		Application.OpenURL (url);
	}

	IEnumerator LoadNewScene (string SceneName) {
		AsyncOperation async = SceneManagement.LoadSceneAsync (SceneName);
		while (!async.isDone) {
			yield return null;
		}
	}
}

