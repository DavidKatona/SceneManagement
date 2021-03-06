﻿using System.Collections;
using UnityEngine;

public class LoaderCallback : MonoBehaviour
{
    [SerializeField] bool _simulateLoadingTime = true;
    private bool _isFirstUpdate = true;

    // Update is called once per frame
    void Update()
    {
        if (_isFirstUpdate)
        {
            _isFirstUpdate = false;

            if (_simulateLoadingTime)
            {
                StartCoroutine(WaitForLoad());
            }
            else
            {
                Loader.LoaderCallback();
            }

        }
    }

    private IEnumerator WaitForLoad()
    {
        yield return new WaitForSeconds(2.0f);
        Loader.LoaderCallback();
    }
}
