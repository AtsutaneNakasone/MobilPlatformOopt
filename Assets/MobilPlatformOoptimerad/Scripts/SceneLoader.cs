using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
public enum CheckMethod
{
    Distance,
    Trigger
}
*/

public class SceneLoader : MonoBehaviour
{
    public Transform player;
   //public CheckMethod checkMethod;
    //public float loadRange;

    //scene state
    private bool isLoaded;
    private bool shouldLoad;

    void Start()
    {
        if (SceneManager.sceneCount > 0)
        {
            for (int i = 0; i < SceneManager.sceneCount; ++i)
            {
                Scene scene = SceneManager.GetSceneAt(i);
                if (scene.name == gameObject.name)
                {
                    isLoaded = true;
                }
            }
        }
    }

    void Update()
    {
        /*
        if (checkMethod == CheckMethod.Distance) 
        {
            DistanceCheck();
        }
        else if (checkMethod == CheckMethod.Trigger)
        {
            TriggerCheck();
        }
        */

        TriggerCheck();

    }

    /*
    void DistanceCheck()
    {
        if (Vector3.Distance(player.position, transform.position) < loadRange)
        {
            LoadScene();
        }
        else
        {
            UnLoadScene();
        }
    }
    */
    
    void LoadScene()
    {
        if (!isLoaded)
        {
            SceneManager.LoadSceneAsync(gameObject.name, LoadSceneMode.Additive);
            isLoaded = true;
        }
    }
    
    /*
    private void LoadScene()
    {
        if (!isLoaded)
        {
            SceneManager.LoadSceneAsync(gameObject.name, LoadSceneMode.Additive).completed += (AsyncOperation op) =>
            {
                isLoaded = true;
            };
        }
    }
    */
    
    void UnLoadScene()
    {
        if (isLoaded)
        {
            SceneManager.UnloadSceneAsync(gameObject.name);
            {
                isLoaded = false;
            }
        }
    }
    
    /*
    private void UnLoadScene()
    {
        if (isLoaded)
        {
            SceneManager.UnloadSceneAsync(gameObject.name).completed += (AsyncOperation op) =>
            {
                isLoaded = false; // Reset isLoaded when the scene has actually unloaded
            };
        }
    }
    */
    /*
    void UnLoadScene()
    {
        if (isLoaded && SceneManager.GetSceneByName(gameObject.name).isLoaded)
        {
            var unloadOperation = SceneManager.UnloadSceneAsync(gameObject.name);
            if (unloadOperation != null) // Kontrollera att operationen inte är null
            {
                unloadOperation.completed += (AsyncOperation op) =>
                {
                    isLoaded = false; // Reset isLoaded when the scene has actually unloaded
                };
            }
            else
            {
                Debug.LogError("Unload failed: Scene not found or could not be unloaded.");
            }
        }
    }
    */

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            shouldLoad = true;
        }
    }

    /*
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(DelayedUnload());
        }
    }

    IEnumerator DelayedUnload()
    {
        yield return new WaitForSeconds(5);  // Väntar 5 sekunder innan avlastning
        if (!shouldLoad)  // Kontrollera att spelaren fortfarande är utanför trigger-området
        {
            UnLoadScene();
        }
    }
    */

    
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            shouldLoad = false;
        }
    }

    private void TriggerCheck()
    {
        if (shouldLoad)
        {
            LoadScene();
        }
        else
        {
            UnLoadScene();
        }
    }
}
