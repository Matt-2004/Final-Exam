using UnityEngine;
using UnityEngine.SceneManagement;

public class InGameMenu : MonoBehaviour
{
    public void Resume()
    {
        LoadPreviousScene();
    }

    public void Restart()
    {
    
        string sceneName = PlayerPrefs.GetString("PreviousScene");

        if (!string.IsNullOrEmpty(sceneName))
        {
            SceneManager.LoadScene(sceneName);
        }
        
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    private void LoadPreviousScene()
    {
        string previousScene =
            PlayerPrefs.GetString("PreviousScene");

        if (!string.IsNullOrEmpty(previousScene))
        {
            SceneManager.LoadScene(previousScene);
        }
        else
        {
            Debug.LogWarning("No previous gameplay scene was saved.");
        }
    }
}