using UnityEngine;
using UnityEngine.SceneManagement;

public enum CheckMethod
{
    Distance,
    Trigger
}

public class SceneLoader : MonoBehaviour
{
    public Transform player;
    public CheckMethod checkMethod;
    public float loadRange;

    //scene state
    private bool isLoaded;
    private bool shouldLoad;

    // Start is called before the first frame update
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

    // Update is called once per frame
    void Update()
    {
        if (checkMethod == CheckMethod.Distance) 
        {
            DistanceCheck();
        }
        else if (checkMethod == CheckMethod.Trigger)
        {
            TriggerCheck();
        }
    }
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

void LoadScene()
    {
        if (!isLoaded)
        {
            SceneManager.LoadSceneAsync(gameObject.name, LoadSceneMode.Additive).completed += (AsyncOperation op) =>
            {
                isLoaded = true; // Set isLoaded when the scene has actually loaded
            };
        }
    }

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
    void UnLoadScene()
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
            if (unloadOperation != null) // Kontrollera att operationen inte �r null
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
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            shouldLoad = false;
        }
    }

    void TriggerCheck()
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
