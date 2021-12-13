using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingInterface : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (!GameManager.manager.RegisterLoader(this))
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }
    public void LoadScene(int sceneId)
    {
        GameManager.manager.layerController.ResetLayers();
        StartCoroutine(SceneLoader(sceneId));
    }
    public void LoadScene(int sceneId, UnityEngine.Events.UnityAction Callback)
    {
        GameManager.manager.layerController.ResetLayers();
        StartCoroutine(SceneLoader(sceneId, Callback));
    }
    private IEnumerator SceneLoader(int sceneId)
    {
        AsyncOperation loadingScene = SceneManager.LoadSceneAsync(sceneId);
        while (!loadingScene.isDone)
        {
            Debug.Log(loadingScene.progress);
            yield return null;
        }
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
