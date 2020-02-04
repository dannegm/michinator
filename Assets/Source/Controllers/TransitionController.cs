using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionController : MonoBehaviour {
    [Header("Models")]
    public Animator transition;

    [Header("Presets")]
    public string triggerName;
    public float transitionTime;

    public void LoadScene (string SceneName) {
        StartCoroutine(LoadAsyncScene(SceneName));
    }

    IEnumerator LoadAsyncScene (string SceneName) {
        transition.SetTrigger(triggerName);

        yield return new WaitForSeconds (transitionTime);

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(SceneName);
        while (!asyncLoad.isDone) {
            yield return null;
        }
    }
}
