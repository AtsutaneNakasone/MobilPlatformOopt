using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class start : MonoBehaviour
{



    List<AsyncOperation> scenesToLoad = new List<AsyncOperation>();

    // Start is called before the first frame update
    void Start()
    {
        scenesToLoad.Add(SceneManager.LoadSceneAsync("Stage"));
        scenesToLoad.Add(SceneManager.LoadSceneAsync("Scene01", LoadSceneMode.Additive));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
