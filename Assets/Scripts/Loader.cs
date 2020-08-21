using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class Loader
{
    // Just a dummy class on which implements MonoBehaviour.
    private class LoadingMonoBehaviour : MonoBehaviour { }

    public enum Scene
    {
        SceneA,
        SceneB,
        LoadingScene
    }

    private static Action onLoaderCallback;
    private static AsyncOperation _loadingAsyncOperation;

    public static void Load(Scene scene)
    {
        // Before we load the loading scene, we assign an anonymous function to our static onLoaderCallback action, which will be called by the LoaderCallback method.
        onLoaderCallback = () =>
        {
            // We create an empty GameObject which will hold a component that implements MonoBehaviour so we can call StartCoroutine on that object.
            GameObject loadingGameObject = new GameObject("Loading Game Object");
            loadingGameObject.AddComponent<LoadingMonoBehaviour>().StartCoroutine(LoadSceneAsync(scene));
        };

        SceneManager.LoadScene(Scene.LoadingScene.ToString());

    }

    /// <summary>
    /// A coroutine that asynchronously loads a target scene.
    /// </summary>
    /// <param name="scene">Scene to load.</param>
    /// <returns></returns>
    private static IEnumerator LoadSceneAsync(Scene scene)
    {
        yield return null;
        _loadingAsyncOperation = SceneManager.LoadSceneAsync(scene.ToString());

        while (!_loadingAsyncOperation.isDone)
        {
            yield return null;
        }
    }

    public static float GetLoadingProgress()
    {
        if (_loadingAsyncOperation != null)
        {
            return _loadingAsyncOperation.progress;
        }
        else
        {
            return 1f;
        }
    }

    /// <summary>
    /// Invokes the static onLoaderCallback action of the static Loader class if it is not null.
    /// </summary>
    public static void LoaderCallback()
    {
        onLoaderCallback?.Invoke();
    }
}
