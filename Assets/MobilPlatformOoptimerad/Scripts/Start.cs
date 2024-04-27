using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class start : MonoBehaviour
{

    List<AsyncOperation> scenesToLoad = new List<AsyncOperation>();

    private void Start()
    {
        scenesToLoad.Add(SceneManager.LoadSceneAsync("Scene01", LoadSceneMode.Additive));
        scenesToLoad.Add(SceneManager.LoadSceneAsync("Scene02", LoadSceneMode.Additive));
    }
    /*
    public void ShowLoadingScreen()
    {
        loadingInterface.SetActive(true);
    }
    */
    /*
    IEnumerator LoadingScreen()
    {
        float totalProgress = 0;
        for (int i = 0; i < scenesToLoad.Count; ++i)
        {
            while (!scenesToLoad[i].isDone)
            {
                totalProgress += scenesToLoad[i].progress;
                loadingProgressBar.fillAmount = totalProgress / scenesToLoad.Count;
                yield return null;
            }
        }
    }
    */
    /*
    IEnumerator LoadingScreen()
    {
        while (true)
        {
            float totalProgress = 0;
            foreach (var sceneLoadOperation in scenesToLoad)
            {
                totalProgress += sceneLoadOperation.progress;
            }
            loadingProgressBar.fillAmount = totalProgress / scenesToLoad.Count;
            if (scenesToLoad.TrueForAll(t => t.isDone)) // Kontrollera om alla scener är helt laddade
            {
                break;
            }
            yield return null;
        }
    }
    */

}
