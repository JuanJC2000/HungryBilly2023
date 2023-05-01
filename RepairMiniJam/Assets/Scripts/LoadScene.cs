using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Load scene using name, or reload the active scene
/// </summary>
public class LoadScene : MonoBehaviour
{
    //Loads any given scene with string
    public void LoadSceneUsingName(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    //Reloads any given scene with string
    public void ReloadCurrentScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
