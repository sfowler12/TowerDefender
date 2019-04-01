using UnityEngine.SceneManagement;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public string levelToLoad = "LevelScene";
    public void Play()
    {
        FindObjectOfType<AudioManager>().Stop();
        SceneManager.LoadScene(levelToLoad);
    }

    public void Quit()
    {
        Application.Quit();
        Debug.Log("Quitting");
    }

    public void Settings()
    {
        Debug.Log("Settings");

    }

    public void Store()
    {
        Debug.Log("Store");

    }
}
