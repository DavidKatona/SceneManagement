using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadTrigger : MonoBehaviour
{
    [SerializeField] private string _sceneToLoad;
    [SerializeField] private string _sceneToUnload;

    private void OnTriggerEnter(Collider other)
    {
        if (!string.IsNullOrWhiteSpace(_sceneToLoad))
        {
            StartCoroutine(LoadScene());
        }

        if (!string.IsNullOrWhiteSpace(_sceneToUnload))
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
