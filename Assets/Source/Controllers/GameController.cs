using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameController : MonoBehaviour {
	public void LoadScene (string SceneName) {
        StartCoroutine(LoadAsyncScene(SceneName));
    }

    public void Quit () {
        Application.Quit ();
    }

	public void OpenURL (string url) {
		Application.OpenURL (url);
	}

    IEnumerator LoadAsyncScene (string SceneName) {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(SceneName);
        while (!asyncLoad.isDone) {
            yield return null;
        }
    }
}

