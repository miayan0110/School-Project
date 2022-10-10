using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Transition : MonoBehaviour
{
    void Start()
    {
        print("SC1To2");
        StartCoroutine("Load");
    }

    void Update()
    { 
       
    }

    IEnumerator Load()
    {
        yield return null;
        AsyncOperation sceneLoaded = SceneManager.LoadSceneAsync("SC002");
        sceneLoaded.allowSceneActivation = false;
        print("progress = " + sceneLoaded.progress);

        while (!sceneLoaded.isDone)
        {
            print("progress = " + sceneLoaded.progress*100 + "%");
            yield return null;

            if (sceneLoaded.progress >= 0.9f)
            {
                sceneLoaded.allowSceneActivation = true;
            }

            yield return null;
        }
    }
}
