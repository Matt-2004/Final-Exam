
using UnityEngine;
using UnityEngine.SceneManagement;

public class HUDManager : MonoBehaviour
{
    public void MadDriver()
    {
        SceneManager.LoadScene("MadDriver");
        // Debug.Log("Click worked!");
    }
    public void FlyLikeABird()
    {
        SceneManager.LoadScene("FlyLikeABird");
        // Debug.Log("Click worked!");
    }
    public void SumoAndBall()
    {
        SceneManager.LoadScene("SumoAndBall");
        // Debug.Log("Click worked!");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}