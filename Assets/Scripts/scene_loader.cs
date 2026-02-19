using UnityEngine;
using UnityEngine.SceneManagement;

public class scene_loader : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private string sceneName = "";
    [SerializeField] private int sceneIndex = -1;

    public void LoadSceneByName()
    {
        if (string.IsNullOrEmpty(sceneName))
        {
            Debug.LogWarning("SceneName not set!");
            return;
        }

        SceneManager.LoadScene(sceneName);
    }

    public void LoadSceneByIndex()
    {
        if (sceneIndex < 0)
        {
            Debug.LogWarning("SceneIndex not set!");
            return;
        }

        SceneManager.LoadScene(sceneIndex);
    }

    public void LoadNextScene()
    {
        int nextIndex = SceneManager.GetActiveScene().buildIndex + 1;

        if (nextIndex >= SceneManager.sceneCountInBuildSettings)
        {
            Debug.LogWarning("Next scene not found!");
            return;
        }

        SceneManager.LoadScene(nextIndex);
    }

    public void ReloadCurrentScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
