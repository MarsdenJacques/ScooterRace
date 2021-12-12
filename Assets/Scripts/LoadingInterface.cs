using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingInterface : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (GameManager.manager.loader != null && GameManager.manager.loader != this)
        {
            Destroy(gameObject);
        }
        else
        {
            GameManager.manager.loader = this;
        }
        DontDestroyOnLoad(gameObject);
    }
    public void LoadScene(int sceneId, UnityEngine.Events.UnityAction Callback)
    {
        StartCoroutine(SceneLoader(sceneId, Callback));
    }
    private IEnumerator SceneLoader(int sceneId, UnityEngine.Events.UnityAction Callback)
    {
        AsyncOperation loadingScene = SceneManager.LoadSceneAsync(sceneId);
        while (!loadingScene.isDone)
        {
            Debug.Log(loadingScene.progress);
            yield return null;
        }
        Callback();
    }
}
