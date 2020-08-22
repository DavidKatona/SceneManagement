using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadTrigger : MonoBehaviour
{
    [SerializeField] private string _sceneToLoad;
    [SerializeField] private string _sceneToUnload;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Player") return;

        if (!string.IsNullOrWhiteSpace(_sceneToLoad) && !SceneManager.GetSceneByName(_sceneToLoad).isLoaded)
        {
            StartCoroutine(LoadScene());
        }

        if (!string.IsNullOrWhiteSpace(_sceneToUnload) && SceneManager.GetSceneByName(_sceneToUnload).isLoaded)
        {
            StartCoroutine(UnloadScene());
        }
    }

    private IEnumerator LoadScene()
    {
        yield return new WaitForSeconds(0.1f);
        GameManager.Instance.Load(_sceneToLoad);
    }

    private IEnumerator UnloadScene()
    {
        yield return new WaitForSeconds(0.1f);
        GameManager.Instance.Unload(_sceneToUnload);
    }
}
